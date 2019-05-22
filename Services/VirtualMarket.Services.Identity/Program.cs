using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using VirtualMarket.Common.Logging;
using VirtualMarket.Common.Vault;
using VirtualMarket.Common.Metrics;
using VirtualMarket.Common.Mvc;


namespace VirtualMarket.Services.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuidler(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuidler(string[] args)
          =>   WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseVault()
                .UseLockbox()
                .UseAppMetrics();       
    }
}
