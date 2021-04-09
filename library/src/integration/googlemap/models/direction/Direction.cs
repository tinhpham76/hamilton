using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Direction
{
    public class Direction
    {
        public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
        public string status { get; set; }
        public string error_message { get; set; }
        public List<Route> routes { get; set; }
        public string copyrights { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
        public string[] available_travel_modes  { get; set; }
        public int[] waypoint_order { get; set; }
        public Bound bounds { get; set; }
    }
}