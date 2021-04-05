using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Hamilton.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });        
        // Order API
        public const string ORDERS_COUNT = "count";

    }
}
