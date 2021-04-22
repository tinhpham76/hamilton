namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class PlaceDetail
    {
        public AddressComponent address_components  { get; set; }
        public string place_id  { get; set; }
        public string language  { get; set; }
        public string region { get; set; }
        public string sessiontoken  { get; set; }
        public string fields { get; set; }
    }
}