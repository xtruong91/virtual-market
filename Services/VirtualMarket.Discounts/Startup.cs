using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VirtualMarket.Common.Consul;
using VirtualMarket.Common.Jaeger;
using VirtualMarket.Common.Mongo;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Discounts.Services;
using VirtualMarket.Common.RestEase;
using VirtualMarket.Discounts.Metrics;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using VirtualMarket.Common.Dispatchers;
using VirtualMarket.Discounts.Domain;
using VirtualMarket.Common.RabbitMq;

namespace VirtualMarket.Services.Discounts
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
            services.AddInitializers(typeof(IMongoDbInitializer));
            services.AddConsul();
            services.AddJaeger();
            services.RegisterServiceForwarder<IOrderService>("orders-service");
            services.AddTransient<IMetricsRegistry, MetricsRegistry>();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddMongo();
            builder.AddMongoRepository<Customer>("Customers");
            builder.AddMongoRepository<Discount>("Discounts");
            builder.AddRabbitMq();
            Container = builder.Build();
            return new AutofacServiceProvider(Container);

        }
    }
}
