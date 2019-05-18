using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VirtualMarket.Common.Consul;
using VirtualMarket.Common.Jaeger;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.Redis;
using VirtualMarket.Common.Swagger;
using VirtualMarket.Services.Customers.Services;
using VirtualMarket.Common.RestEase;
using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Customers.Domain;

namespace VirtualMarket.Services.Customers
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
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
            services.AddInitializers(typeof(IMongoDbInitializer));
            services.RegisterServiceForwarder<IProductsService>("products-service");

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddMongo();
            builder.AddMongoRepository<Cart>("Carts");
            builder.AddMongoRepository<Customer>("Customers");
            builder.AddMongoRepository<Product>("Products");

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }
    }
}