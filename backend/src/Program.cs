using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Hamilton
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
                    webBuilder.UseUrls("https://localhost:5001", "http://localhost:5000");
                });
        
        // Hamilton
        public const string FIND_HAMILTON = "findhamilton";

        // Routes
        public const string ROUTES_DIRECTIONS = "routes/directions"; 

    }
}
