using Core.Libs.Integration.GoogleMap.Models.Enum.Places;
using Core.Libs.Integration.GoogleMap.Models.Places.Geocoding;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class NearbySearchRequest
    {
        public string input { get; set; }
        public string location { get; set; }
        public long? radius { get; set; }
        public string keyword { get; set; }
        public string language { get; set; }
        public int? minprice { get; set; }
        public int? maxprice { get; set; }
        public string name { get; set; }
        public string opennow { get; set; }
        public Rankby? rankby { get; set; }
        public string type { get; set; }
        public string pagetoken { get; set; }
    }
}