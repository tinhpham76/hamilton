using System;
using Core.Libs.Integration.GoogleMap.Models.Enum.Routes;

namespace Core.Libs.Integration.GoogleMap.Models.Routes.Directions
{
    public class DirectionRequest
    {
        public string origin { get; set; }
        public string destination { get; set; }
        public TravelMode? mode { get; set; }
        public string[] waypoints { get; set; }
        public bool? alternatives { get; set; }
        public Avoid? avoid { get; set; }
        public string language { get; set; } = "vi";
        public Unit? units { get; set; }
        public string region { get; set; }
        public DateTime? arrival_time { get; set; }
        public DateTime? departure_time { get; set; }

        // Google Maps Platform Premium Plan
        // public string traffic_model { get; set; } 
        // public string transit_mode { get; set; }
        // public string transit_routing_preference { get; set; }
    }
}