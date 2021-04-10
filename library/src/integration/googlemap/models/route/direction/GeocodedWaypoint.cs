using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Routes.Directions
{
    public class GeocodedWaypoint
    {
       public string geocoder_status { get; set; }
       public string place_id { get; set; }
       public string[] types { get; set; }
    }
}