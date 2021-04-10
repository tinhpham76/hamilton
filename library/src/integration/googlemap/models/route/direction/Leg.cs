using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Routes.Directions
{
    public class Leg
    {
        public List<Step> steps { get; set; }
        public Duration duration { get; set; }
        public Distance distance { get; set; }
        public Location start_location { get; set; }
        public Location end_location { get; set; }
        public string start_address { get; set; }
        public string end_address { get; set; }
    }
}