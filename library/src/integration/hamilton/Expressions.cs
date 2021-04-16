using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Libs.Integration.Hamilton
{
    public static class Expressions
    {
        public static IServiceCollection RegisterIntegrationHamilton(
            this IServiceCollection services, IConfiguration configuration)
        {
            services

                .AddSingleton<IHamilton>();

            return services;
        }
    }
}