namespace Core.Libs.Integration.GoogleMap.Models.Places.PlaceSearch
{
    public class FindPlaceRequest
    {
        public string input { get; set; }
        public string inputtype { get; set; } = "textquery";
        public string language { get; set; } = "vi";
        public string fields { get; set; } = "business_status,formatted_address,geometry,icon,name,permanently_closed,photos,place_id,plus_code,types,opening_hours,price_level,rating,user_ratings_total";
        public string locationbias { get; set; }
    }
}