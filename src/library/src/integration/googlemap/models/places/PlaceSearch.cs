using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class PlaceSearch
    {
        public List<Candidate> candidates { get; set; }
        public string status { get; set; }
        public string error_message { get; set; }
    }
}