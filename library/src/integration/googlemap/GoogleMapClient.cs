using System.Net.Http;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapClient
    {
        IGoogleMapDistanceMatrix DistanceMatrix { get; }
        IGoogleMapDirection Direction { get; }
        IGoogleMapGeocoding Geocoding { get; }
        IGoogleMapMatrix Matrix { get; }
        IGoogleMapPlace Place { get; }
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
            this.Direction = new GoogleMapDirection(this.httpClient, this.config);
            this.Geocoding = new GoogleMapGeocoding(this.httpClient, this.config);
            this.Matrix = new GoogleMapMatrix(new GoogleMapDirection(this.httpClient, this.config));
            this.Place = new GoogleMapPlace(this.httpClient, this.config);
        }

        public IGoogleMapDistanceMatrix DistanceMatrix { get; }
        public IGoogleMapDirection Direction { get; }
        public IGoogleMapGeocoding Geocoding { get; }
        public IGoogleMapMatrix Matrix { get; }
        public IGoogleMapPlace Place { get; }
    }
}