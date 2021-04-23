using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Core.Libs.Integration.GoogleMap
{
    public static class Expressions
    {
        public static IServiceCollection RegisterIntegrationGoogleMap(
            this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<IntegrationConfig>(configuration.GetSection(IntegrationConfig.ConfigName))

                .AddSingleton<IGoogleMapClient>(provider =>
                    new GoogleMapClient(
                        provider.GetRequiredService<HttpClient>(),
                        provider.GetRequiredService<IOptions<IntegrationConfig>>().Value));

            return services;
        }
    }
}