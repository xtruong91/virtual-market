using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Chronicle;
using Consul;
using VirtualMarket.Common;
using VirtualMarket.Common.Consul;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Jaeger;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Redis;
using VirtualMarket.Common.Swagger;
using VirtualMarket.Services.Operations.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VirtualMarket.Services.Operations
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
            services.AddChronicle();
            services.AddInitializers(typeof(IMongoDbInitializer));

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddMongo();
            builder.RegisterGeneric(typeof(GenericEventHandler<>))
                .As(typeof(IEventHandler<>));
            builder.RegisterGeneric(typeof(GenericCommandHandler<>))
                .As(typeof(ICommandHandler<>));

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
                .SubscribeAllMessages();

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
