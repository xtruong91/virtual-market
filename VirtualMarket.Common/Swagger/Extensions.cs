using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace VirtualMarket.Common.Swagger
{
    public static class Extensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            SwaggerOptions options;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                services.Configure<SwaggerOptions>(configuration.GetSection("swagger"));
                options = configuration.GetOptions<SwaggerOptions>("swagger");
            }

            if (!options.Enabled)
            {
                return services;
            }
            return services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc(options.Name, new Info { Title = options.Title, Version = options.Version });
               if (options.IncludeSecurity)
               {
                   c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                   {
                       Description = "JWT Authorization header using the Bearer scheme" +
                       "Example: \"Authorization: Bearer {token}\"",
                       Name = "Authorization",
                       In = "header",
                       Type = "apiKey"
                   });
               }
           });
        }
    }
}
