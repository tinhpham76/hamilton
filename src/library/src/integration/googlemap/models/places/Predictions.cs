using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class Predictions<T> where T : class
    {
        public List<T> predictions { get; set; }
        public string status { get; set; }
        public string error_message { get; set; }
    }
}