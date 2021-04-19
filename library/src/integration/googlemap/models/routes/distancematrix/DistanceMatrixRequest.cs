using System;
using Core.Libs.Integration.GoogleMap.Models.Enum.Routes;

namespace Core.Libs.Integration.GoogleMap.Models.Routes.DistanceMatrix
{
    public class DistanceMatrixRequest
    {
        public string[] origins { get; set; }
        public string[] destinations { get; set; }
        public TravelMode? mode { get; set; }
        public string language  { get; set; } = "vi";
        public string region { get; set; }
        public Avoid? avoid { get; set; }
        public Unit? units { get; set; }
        public DateTime? arrival_time { get; set; }
        public DateTime? departure_time  { get; set; }

        // Google Maps Platform Premium Plan
        // public string traffic_model  { get; set; }
        // public string transit_mode  { get; set; }
        // public string transit_routing_preference  { get; set; }
    }
}