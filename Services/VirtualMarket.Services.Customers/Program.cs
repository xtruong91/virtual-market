using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using VirtualMarket.Common.Logging;
using VirtualMarket.Common.Metrics;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.Vault;

namespace VirtualMarket.Services.Customers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseVault()
                .UseLockbox()
                .UserAppMetrics();
    }
}
