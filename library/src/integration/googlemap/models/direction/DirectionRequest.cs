using System;
using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Direction
{
    public class DirectionRequest
    {
        public string origin { get; set; }
        public string destination { get; set; }
        public string mode { get; set; }
        public List<string> waypoints { get; set; }
        public bool? alternatives { get; set; }
        public string language { get; set; } = "vi";
        public string region { get; set; }
        public string avoid { get; set; }
        public string units { get; set; }
        public DateTime? arrival_time { get; set; }
        public DateTime? departure_time { get; set; }
        public string traffic_model { get; set; }
        public string transit_mode { get; set; }
        public string transit_routing_preference { get; set; }
    }
}