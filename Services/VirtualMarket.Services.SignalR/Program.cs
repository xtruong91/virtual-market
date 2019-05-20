using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using VirtualMarket.Common.Logging;
using VirtualMarket.Common.Vault;
using VirtualMarket.Common.Mvc;
using VirtualMarket.Common.Metrics;

namespace VirtualMarket.Services.SignalR
{
    public class Prorgram
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseLogging()
            .UseVault()
            .UseLockbox()
            .UseAppMetrics();            
    }
}
