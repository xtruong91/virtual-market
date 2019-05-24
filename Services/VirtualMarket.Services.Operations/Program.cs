using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using VirtualMarket.Common.Logging;
using VirtualMarket.Common.Vault;
using VirtualMarket.Common.Metrics;
using VirtualMarket.Common.Mvc;
namespace VirtualMarket.Services.Operations
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
                .UseAppMetrics();
    }
}
