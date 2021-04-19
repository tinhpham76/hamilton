using System.Net.Http;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapClient
    {
        IGoogleMapRoutes Routes { get; }
        IGoogleMapPlaces Places { get; }
        IGoogleMapHamilton Hamilton { get; }

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

            this.Routes = new GoogleMapRoutes(this.httpClient, this.config);
            this.Places = new GoogleMapPlaces(this.httpClient, this.config);
            this.Hamilton = new GoogleMapHamilton(new GoogleMapRoutes(this.httpClient, this.config));
            
        }

        public IGoogleMapRoutes Routes { get; }
        public IGoogleMapPlaces Places { get; }
        public IGoogleMapHamilton Hamilton { get; }
    }
}