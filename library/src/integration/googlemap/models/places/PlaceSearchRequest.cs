using Core.Libs.Integration.GoogleMap.Models.Enum.Places;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class PlaceSearchRequest
    {
        public string input { get; set; }
        public InputType? inputtype { get; set; }
        public string language  { get; set; }
        public Field[] fields  { get; set; }
        public string locationbias  { get; set; }
    }
}