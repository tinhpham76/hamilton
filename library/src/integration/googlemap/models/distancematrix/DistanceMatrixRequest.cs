using System;
using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.DistanceMatrix
{
    public class DistanceMatrixRequest
    {
        public List<string> origins { get; set; }
        public List<string> destinations { get; set; }
        public string mode { get; set; }
        public string language  { get; set; } = "vi";
        public string region { get; set; }
        public string avoid { get; set; }
        public string units { get; set; }
        public DateTime? arrival_time { get; set; }
        public DateTime? departure_time  { get; set; }
        public string traffic_model  { get; set; }
        public string transit_mode  { get; set; }
        public string transit_routing_preference  { get; set; }
    }
}