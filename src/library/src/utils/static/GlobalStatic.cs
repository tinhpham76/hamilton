  
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Libs.Utils.Static
{
    public class GlobalStatic
    {
        public IDictionary<string, string> Errors { get; internal set; }
    }

    public static class GlobalStaticExtensions
    {
        public static IServiceCollection RegisterGlobalStatic(this IServiceCollection services, IDictionary<string, string> errors = null)
        {
            var obj = new GlobalStatic();

            if (errors != null)
                obj.Errors = errors;

            services.AddSingleton<GlobalStatic>(obj);
            
            return services;
        }    
    }
}