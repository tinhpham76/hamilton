using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class PlaceDetail
    {
        public List<AddressComponent> address_components { get; set; }
        public string adr_address { get; set; }
        public string language { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public string place_id { get; set; }
        public double? rating { get; set; }
        public string reference { get; set; }
        public List<Review> reviews { get; set; }
        public string[] types { get; set; }
        public string url { get; set; }
        public long? utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public PlusCode plus_code { get; set; }
        public double? user_ratings_total { get; set; }
    }
}