using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class Results<T> where T : class
    {
        public List<T> results { get; set; }
        public string status { get; set; }
        public string[] html_attributions { get; set; }
        public string error_message { get; set; }
    }
}