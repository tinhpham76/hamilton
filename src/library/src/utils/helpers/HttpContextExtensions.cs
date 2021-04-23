using System.Net;
using Microsoft.AspNetCore.Http;

namespace Core.Libs.Utils.Helpers
{
    public static class HttpContextExtensions
    {
        public static void SetStatusCode(this HttpContext httpContext, HttpStatusCode statusCode)
        {
            httpContext.Response.StatusCode = (int)statusCode;
        }
        
        public static void SetRedirect(this HttpContext httpContext, string url)
        {
            httpContext.Response.Redirect(url, true);
        }
    }
}