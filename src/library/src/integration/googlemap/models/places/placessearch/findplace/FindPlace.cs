using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Places.PlaceSearch.FindPlace
{
    public class FindPlace
    {
        public string business_status { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public PlusCode plus_code { get; set; }
        public string[] rating { get; set; }
        public double? user_ratings_total { get; set; }
    }
}