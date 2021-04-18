using System.Collections.Generic;
using Core.Libs.Integration.GoogleMap.Models.Places.Geocoding;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class Candidate
    {
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public double? rating { get; set; }
        public string place_id { get; set; }
    }
}