namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class PlaceDetailRequest
    {
        public string place_id { get; set; }
        public string language { get; set; } = "vi";
        public string region { get; set; } = "vni";
        public string sessiontoken { get; set; }
        public string fields { get; set; }= "business_status,formatted_address,geometry,icon,name,permanently_closed,photos,place_id,plus_code,types,opening_hours,price_level,rating,user_ratings_total";
    }
}