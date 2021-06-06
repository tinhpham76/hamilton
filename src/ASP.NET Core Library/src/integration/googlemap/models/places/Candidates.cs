using System.Collections.Generic;
namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class Candidates<T> where T : class
    {
        public List<T> candidates { get; set; }
        public string status { get; set; }
        public string error_message { get; set; }
    }
}