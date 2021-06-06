using System.Collections.Generic;
using System.Linq;

namespace Core.Libs.Integration.GoogleMap
{
    public class Utils
    {
        private const string GoogleMapUrl = "https://maps.googleapis.com/maps/api";

        public static string GetApiUrl(string path, string key, List<(string Key, object Value)> queries = null)
        {
            if (!path.StartsWith("/"))
                path = "/" + path;

            var url = Utils.GoogleMapUrl + path + "/json";

            if (queries != null && queries.Count > 0)
            {
                url += url.Contains("?") ? "&" : "?";
                url += string.Join(
                    "&",
                    // queries.Select(a => $"{a.Key}={WebUtility.UrlEncode(a.Value.ToString())}"));
                    queries.Select(a => $"{a.Key}={a.Value.ToString()}"));
            }

            url += "&";
            url += $"key={key}";

            return url;
        }
    }
}