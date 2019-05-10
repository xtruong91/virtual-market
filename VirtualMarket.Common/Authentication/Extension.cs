using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VirtualMarket.Common.Authentication
{
    public static class Extension
    {
        private static readonly string SectionName = "jwt";
        public static void AddJwt(this IServiceCollection services)
        {
            IConfiguration configuration;
            using(var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }
            var section = configuration.GetSection(SectionName);
            var options = configuration.GetOptions<JwtOptions>(SectionName);

            services.Configure<JwtOptions>(section);
            services.AddSingleton(options);
            services.AddSingleton<IJwtHandler, JwtHandler>();
        }
    }
}
