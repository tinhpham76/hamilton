using System.Collections.Generic;
using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;

namespace Core.Libs.Integration.GoogleMap.Models.Hamilton
{
    public class Hamilton
    {
        public string[] hamiltons { get; set; }
        public Distance distance { get; set; }
        public List<HamiltonDetail> detail { get; set; }
    }
}