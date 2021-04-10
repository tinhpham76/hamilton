using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Routes.Directions
{
    public class Route
    {
        public string summary { get; set; }
        public List<Leg> legs { get; set; }
    }
}