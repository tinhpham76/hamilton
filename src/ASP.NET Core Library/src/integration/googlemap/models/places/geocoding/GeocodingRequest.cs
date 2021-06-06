namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class GeocodingRequest
    {
        public string address { get; set; }
        public string components { get; set; }
        public string bounds { get; set; }
        public string language { get; set; } = "vi";
        public string region { get; set; } = "vni";
    }
}