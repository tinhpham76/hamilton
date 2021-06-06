using System;
using Microsoft.AspNetCore.Http;

namespace Core.Libs.Utils.Helpers
{
    public static class RequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");
                
            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
                
            return false;
        }

        public static string GetIP(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            string ip = null;

            if (string.IsNullOrWhiteSpace(ip)
                && request.Headers.ContainsKey("X-Forwarded-For"))
                ip = request.Headers["X-Forwarded-For"];

            if (string.IsNullOrWhiteSpace(ip)
                && request.HttpContext?.Connection?.RemoteIpAddress != null)
                ip = request.HttpContext.Connection.RemoteIpAddress.ToString();
                
            if (string.IsNullOrWhiteSpace(ip)
                && request.Headers.ContainsKey("REMOTE_ADDR"))
                ip = request.Headers["REMOTE_ADDR"];

            return ip;
        }
    }
}