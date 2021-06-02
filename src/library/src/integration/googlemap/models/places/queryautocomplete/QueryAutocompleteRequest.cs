namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class QueryAutocompleteRequest
    {
        public string input { get; set; }
        public int? offset { get; set; }
        public string location { get; set; }
        public long? radius { get; set; }
        public string language { get; set; } = "vi";
    }
}