using System.Net;

namespace Core.Libs.Utils.Models
{
    public class FetchResponse<T>
    {
        public static FetchResponse<T> Create(
            HttpStatusCode statusCode,
            T data,
            string eTag = null,
            bool isNotModified = false,
            bool isRedirect = false,
            string redirectUrl = null)
        {
            return new FetchResponse<T>()
            {
                StatusCode = statusCode,
                Data = data,
                ETag = eTag,
                IsNotModified = isNotModified,
                IsRedirect = isRedirect,
                RedirectUrl = redirectUrl
            };
        }

        public HttpStatusCode StatusCode { get; private set; }
        public T Data { get; private set; }
        public string ETag { get; private set; }
        public bool IsNotModified { get; private set; }
        public bool IsRedirect { get; private set; }
        public string RedirectUrl { get; private set; }
    }
}