namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class Result<T> where T : class
    {
        public T results { get; set; }
        public string status { get; set; }
        public object[] html_attributions { get; set; }
    }
}