using System.Collections.Generic;

namespace Core.Libs.Client.Models.Json
{
    public class ResponseJsonModel
    {
        public ErrorJsonModel error { get; set; }
    }
    public class ErrorJsonModel
    {
        public string code { get; set; }
        public string message { get; set; }
        public List<object> trace_keys { get; set; }
    }

    public class ResponseJsonModel<T> : ResponseJsonModel where T : class
    {
        public T data { get; set; }
    }
}