using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
                    // webBuilder.UseUrls("https://localhost:5001", "http://localhost:5000");
                });

        // Hamilton
        public const string FIND_HAMILTON = "findhamilton";

        // Routes
        public const string ROUTES_DIRECTIONS = "routes/directions";
        public const string ROUTES_DISTANCEMATRIX = "routes/distancematrix";

        // Places
        public const string PLACES_FIND_PLACE_FROM_TEXT = "places/findplacefromtext";
        public const string PLACES_NEARBY_SEARCH = "places/nearbysearch";
        public const string PLACES_TEXT_SEARCH = "places/textsearch";
        public const string PLACES_DETAIL = "places/details";
        public const string PLACES_AUTO_COMPLETE = "places/autocomplete";
        public const string PLACES_QUERY_AUTO_COMPLETE = "places/queryautocomplete";
        public const string PLACES_GEOCODE = "geocode";
    }
}
