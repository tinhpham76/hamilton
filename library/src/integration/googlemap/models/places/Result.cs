namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class Result<T> where T : class
    {
        public T results { get; set; }
        public T result { get; set; }
        public string status { get; set; }
        public string[] html_attributions { get; set; }
    }
}