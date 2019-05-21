using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using VirtualMarket.Common;
using VirtualMarket.Common.Authentication;
using VirtualMarket.Common.Consul;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Common.Jaeger;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Redis;
using VirtualMarket.Common.Swagger;
using VirtualMarket.Services.SignalR.Framework;
using VirtualMarket.Services.SignalR.Hubs;
using VirtualMarket.Services.SignalR.Messages.Events;

namespace VirtualMarket.Services.SignalR
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public IContainer Container { get; set; }
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
            services.AddJwt();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                    cors.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            AddSignalR(services);
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddRabbitMq();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        private void AddSignalR(IServiceCollection services)
        {
            var options = Configuration.GetOptions<SignalrOptions>("signalr");
            services.AddSingleton(options);
            var builder = services.AddSignalR();

            if (!options.Backplane.Equals("redis", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
            var redisOptions = Configuration.GetOptions<RedisOptions>("refis");
            builder.AddRedis(redisOptions.ConnectionString);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, SignalrOptions signalrOptions,
            IConsulClient client, IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseAllForwardedHeaders();
            app.UseStaticFiles();
            app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseAuthentication();
            app.UseAccessTokenValidator();
            app.UseServiceId();
            app.UseSignalR(routes => 
            {
                routes.MapHub<VirtualMarketHub>($"/{signalrOptions.Hub}");
            });
            app.UseMvc();
            app.UseRabbitMq()
                .SubscribeEvent<OperationPending>(@namespace: "operations")
                .SubscribeEvent<OperationCompleted>(@namespace: "operations")
                .SubscribeEvent<OperationRejected>(@namespace: "operations");
                
            var consulServiceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                client.Agent.ServiceDeregister(consulServiceId);
                Container.Dispose();
            });

            (startupInitializer as StartupInitializer).InitializeAsync();
        }
    }
}
