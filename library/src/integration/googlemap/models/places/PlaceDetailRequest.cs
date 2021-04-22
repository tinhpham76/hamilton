using Core.Libs.Integration.GoogleMap.Models.Enum.Places;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class PlaceDetailRequest
    {
        public string key  { get; set; }
        public string place_id  { get; set; }
        public string language  { get; set; }
        public string region { get; set; }
        public string sessiontoken  { get; set; }
        public Field[] fields { get; set; }
    }
}