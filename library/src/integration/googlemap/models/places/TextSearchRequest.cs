namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class TextSearchRequest
    {
        public string query { get; set; }
        public string region { get; set; }
        public string location { get; set; }
        public string language { get; set; }
        public double? radius { get; set; }
        public int? minprice { get; set; }
        public int? maxprice { get; set; }
        // public string opennow { get; set; }
        // public string pagetoken { get; set; }
        public string type { get; set; }
    }
}