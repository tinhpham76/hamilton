using System.Collections.Generic;

namespace Core.Libs.Utils.Models
{
    public class ErrorMessageModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<object> TraceKeys { get; set; }
    }
}