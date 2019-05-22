using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using VirtualMarket.Common;
using VirtualMarket.Common.Consul;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Redis;
using VirtualMarket.Common.Swagger;
using VirtualMarket.Services.Notifications.Serviecs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualMarket.Common.RestEase;
using VirtualMarket.Common.MailKit;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Common.Jaeger;
using VirtualMarket.Services.Notifications.Messages.Commands;
using VirtualMarket.Services.Notifications.Messages.Events;
namespace VirtualMarket.Services.Notifications
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
            services.AddRedis();
            services.RegisterServiceForwarder<ICustomersService>("customers-service");

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddMongo();
            builder.AddMailKit();

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
                .SubscribeCommand<SendEmailNotification>()
                .SubscribeEvent<OrderCreated>(@namespace: "orders");

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
