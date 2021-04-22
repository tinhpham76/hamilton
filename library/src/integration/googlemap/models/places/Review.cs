namespace Core.Libs.Integration.GoogleMap.Models.Places
{
    public class Review
    {
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public string profile_photo_url { get; set; }
        public double? rating { get; set; }
        public string relative_time_description { get; set; }
        public string text { get; set; }
        public long? time { get; set; }
    }
}