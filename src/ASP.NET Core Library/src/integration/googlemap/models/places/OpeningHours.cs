using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class OpeningHours
    {
        public bool? open_now { get; set; }
        public List<Period> periods { get; set; }
        public string[] weekday_text { get; set; }
    }
}