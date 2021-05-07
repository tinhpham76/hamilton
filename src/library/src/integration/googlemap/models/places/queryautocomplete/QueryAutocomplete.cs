using System.Collections.Generic;

namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class QueryAutocomplete
    {
        public string description { get; set; }
        public List<MatchedSubstring> matched_substrings { get; set; }
        public StructuredFormatting structured_formatting { get; set; }
        public List<Term> terms { get; set; }
        public string place_id  { get; set; }
        public string reference { get; set; }
        public string[] types { get; set; }
    }
}