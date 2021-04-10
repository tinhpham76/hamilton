using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Routes.Directions
{
    public class Step
    {
        public string travel_mode { get; set; }
        public Location start_location { get; set; }
        public Location end_location { get; set; }
        public Polyline polyline { get; set; }
        public Duration duration { get; set; }
        public string html_instructions { get; set; }
        public Distance distance { get; set; }
    }
}