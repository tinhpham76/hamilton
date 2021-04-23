namespace Core.Libs.Integration.GoogleMap
{
    public class IntegrationConfig
    {
        public const string ConfigName = "Integration";
        public GoogleMapConfig GoogleMap { get; set; }
    }

    public class GoogleMapConfig
    {
        public const string ConfigName = "GoogleMap";
        public string Key { get; set; }
    }
}