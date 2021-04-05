using System.Net.Http;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapClient
    {
        IGoogleMapDistanceMatrix DistanceMatrix { get; }
    }

    public class GoogleMapClient : IGoogleMapClient
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        public GoogleMapClient(
            HttpClient httpClient,
            IntegrationConfig config)
        {
            this.httpClient = httpClient;
            this.config = config.GoogleMap;

            this.DistanceMatrix = new GoogleMapDistanceMatrix(this.httpClient, this.config);
        }
        
        public IGoogleMapDistanceMatrix DistanceMatrix { get; }
    }
}