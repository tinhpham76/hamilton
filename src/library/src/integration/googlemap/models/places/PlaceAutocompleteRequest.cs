namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class PlaceAutocompleteRequest
    {
        public string input { get; set; }
        public string sessiontoken { get; set; }
        public int? offset { get; set; }
        public string origin { get; set; }
        public string location { get; set; }
        public long? radius { get; set; }
        public string language { get; set; }
        public string types { get; set; }
        public string components { get; set; }
        public string strictbounds { get; set; }
    }
}