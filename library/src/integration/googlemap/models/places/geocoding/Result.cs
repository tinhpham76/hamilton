namespace Core.Libs.Integration.GoogleMap.Models.Places.Geocoding
{
    public class Result<T> where T : class
    {
        public T results { get; set; }
        public string status { get; set; }
    }
}