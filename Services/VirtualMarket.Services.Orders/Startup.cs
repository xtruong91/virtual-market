using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using VirtualMarket.Common;
using VirtualMarket.Common.Consul;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Common.Jaeger;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.RestEase;
using VirtualMarket.Common.Swagger;
using VirtualMarket.Services.Orders.Messages.Commands;
using VirtualMarket.Services.Orders.Messages.Events;
using VirtualMarket.Services.Orders.Domain;
using VirtualMarket.Services.Orders.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VirtualMarket.Services.Orders
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddSwaggerDocs();
            services.AddConsul();
            services.AddJaeger();
            services.AddOpenTracing();
            services.AddInitializers(typeof(IMongoDbInitializer));
            services.RegisterServiceForwarder<IProductsService>("products-service");
            services.RegisterServiceForwarder<ICustomersService>("customers-service");

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddMongo();
            builder.AddMongoRepository<Order>("Orders");
            builder.AddMongoRepository<OrderItem>("OrderItems");
            builder.AddMongoRepository<Customer>("Customers");

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, IConsulClient client,
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAllForwardedHeaders();
            app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseServiceId();
            app.UseMvc();
            app.UseRabbitMq()
                .SubscribeCommand<CreateOrder>(onError: (c, e) =>
                    new CreateOrderRejected(c.Id, c.CustomerId, e.Message, e.Code))
                .SubscribeCommand<ApproveOrder>(onError: (c, e) =>
                    new ApproveOrderRejected(c.Id, e.Message, e.Code))
                .SubscribeCommand<CancelOrder>(onError: (c, e) =>
                    new CancelOrderRejected(c.Id, c.CustomerId, e.Message, e.Code))
                .SubscribeCommand<RevokeOrder>(onError: (c, e) =>
                    new RevokeOrderRejected(c.Id, c.CustomerId, e.Message, e.Code))
                .SubscribeCommand<CompleteOrder>(onError: (c, e) =>
                    new CompleteOrderRejected(c.Id, c.CustomerId, e.Message, e.Code))
                .SubscribeCommand<CreateOrderDiscount>()
                .SubscribeEvent<CustomerCreated>(@namespace: "customers");

            var consulServiceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                client.Agent.ServiceDeregister(consulServiceId);
                Container.Dispose();
            });

            startupInitializer.InitializeAsync();
        }
    }
}
