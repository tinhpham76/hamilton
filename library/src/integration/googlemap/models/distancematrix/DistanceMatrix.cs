using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.DistanceMatrix
{
    public class DistanceMatrix
    {
        public string[] destination_addresses { get; set; }
        public string[] origin_addresses { get; set; }
        public List<Row> rows { get; set; }
        public string status { get; set; }
    }
}