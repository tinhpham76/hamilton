namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class Prediction<T> where T : class
    {
        public T predictions { get; set; }
        public string status { get; set; }
        public string error_message { get; set; }
    }
}