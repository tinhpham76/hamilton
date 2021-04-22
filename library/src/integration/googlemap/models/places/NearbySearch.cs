using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class NearbySearch
    {
        public string business_status { get; set; }
        public Geometry status { get; set; }
        public string icon { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public PlusCode plus_code { get; set; }
        public double? rating { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public string[] types { get; set; }
        public double? user_ratings_total { get; set; }
        public string vicinity { get; set; }
    }
}