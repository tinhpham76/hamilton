namespace Core.Libs.Integration.GoogleMap.Models.Places.PlaceSearch
{
    public class TextSearchRequest
    {
        public string query { get; set; }
        public string region { get; set; } = "vni";
        public string location { get; set; }
        public string language { get; set; } = "vi";
        public double? radius { get; set; }
        public string type { get; set; }
    }
}