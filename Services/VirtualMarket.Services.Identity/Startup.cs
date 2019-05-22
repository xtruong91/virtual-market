using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VirtualMarket.Common;
using VirtualMarket.Common.Authentication;
using VirtualMarket.Common.Consul;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Common.Jaeger;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Redis;
using VirtualMarket.Common.Swagger;
using VirtualMarket.Services.Identity.Domain;

namespace VirtualMarket.Services.Identity
{
    public class Startup
    {
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count" };
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
            services.AddJwt();
            services.AddJaeger();
            services.AddOpenTracing();
            services.AddRedis();
            services.AddInitializers(typeof(IMongoDbInitializer));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                    cors.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders(Headers));
            });
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddMongo();
            builder.AddMongoRepository<RefreshToken>("RefreshTokens");
            builder.AddMongoRepository<User>("Users");
            builder.AddRabbitMq();
            builder.AddDispatchers();
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>();
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
            app.UseCors("CorsPolicy");
            app.UseAllForwardedHeaders();
            app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseAuthentication();
            app.UseAccessTokenValidator();
            app.UseServiceId();
            app.UseMvc();
            app.UseRabbitMq();

            var consulServiceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                client.Agent.ServiceDeregister(consulServiceId);
                Container.Dispose();
            });
            startupInitializer .InitializeAsync();
        }
    }
}
