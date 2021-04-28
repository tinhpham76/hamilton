using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;

namespace Core.Libs.Integration.GoogleMap.Models.Hamilton
{
    public class HamiltonDetail
    {
        public Distance distance { get; set; }
        public string origin { get; set; }
        public string destination  { get; set; }
    }
}