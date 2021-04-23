namespace Core.Libs.Client.Models.Json
{
    public class ResponseRedirectJsonModel : ResponseJsonModel
    {
        public ResponseRedirectJsonModel(string redirectUrl)
        {
            this.redirect_url = redirectUrl;
        }

        public string redirect_url { get; set; }
    }
}