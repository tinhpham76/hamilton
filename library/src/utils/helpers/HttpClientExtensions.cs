using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.Libs.Utils.Models;
using Newtonsoft.Json;

namespace Core.Libs.Utils.Helpers
{
    public static class HttpClientExtensions
    {
        public static Task<FetchResponse<T>> ExecuteGet<T>(
            this HttpClient httpClient,
            string url,
            string etag = null,
            IDictionary<string, string> headers = null,
            bool isCatchRedirect = false,
            object data = null)
        {
            return httpClient.Execute<T>(
                HttpMethod.Get,
                url,
                data: data,
                etag: etag,
                headers: headers,
                isCatchRedirect: isCatchRedirect);
        }

        public static Task<FetchResponse<T>> ExecutePost<T>(
            this HttpClient httpClient,
            string url,
            object data = null,
            string etag = null,
            IDictionary<string, string> headers = null)
        {
            return httpClient.Execute<T>(
                HttpMethod.Post,
                url,
                data: data,
                etag: etag,
                headers: headers);
        }

        public static Task<FetchResponse<T>> ExecutePut<T>(
            this HttpClient httpClient,
            string url,
            object data = null,
            string etag = null,
            IDictionary<string, string> headers = null)
        {
            return httpClient.Execute<T>(
                HttpMethod.Put,
                url,
                data: data,
                etag: etag,
                headers: headers);
        }

        public static Task<FetchResponse<T>> ExecuteDelete<T>(
            this HttpClient httpClient,
            string url,
            object data = null,
            string etag = null,
            IDictionary<string, string> headers = null)
        {
            return httpClient.Execute<T>(
                HttpMethod.Delete,
                url,
                data: data,
                etag: etag,
                headers: headers);
        }

        public static async Task<FetchResponse<T>> Execute<T>(
            this HttpClient httpClient,
            HttpMethod method,
            string url,
            object data = null,
            string etag = null,
            IDictionary<string, string> headers = null,
            bool isCatchRedirect = false)
        {
            
            using (var requestMessage = new HttpRequestMessage(method, url))
            {
                HttpContent content = null;

                if (data != null)
                {
                    if (data is string)
                        content = new StringContent((string)data, Encoding.UTF8, "application/json");
                    else if (data is IDictionary<string, object>)
                    {
                        var formData = new MultipartFormDataContent();

                        foreach (var pair in data as IDictionary<string, object>)
                            if (pair.Value != null)
                            {
                                if (pair.Value is byte[])
                                    formData.Add(new ByteArrayContent(pair.Value as byte[]), pair.Key, pair.Key);
                                else
                                    formData.Add(new StringContent(pair.Value.ToString()), pair.Key);
                            }

                        content = formData;
                    }
                    else
                    {
                        var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });

                        content = new StringContent(json, Encoding.UTF8, "application/json");
                    }

                    requestMessage.Content = content;
                }

                if (etag != null)
                    requestMessage.Headers.Add("If-None-Match", etag);

                if (headers != null && headers.Count > 0)
                    foreach (var a in headers)
                    {
                        if (content != null)
                            if (a.Key == "Content-Type"
                                || a.Key == "Content-Length")
                                continue;

                        requestMessage.Headers.TryAddWithoutValidation(a.Key, a.Value);
                    }

                using (var response = await httpClient.SendAsync(requestMessage).ConfigureAwait(false))
                {
                    if (content != null)
                        content.Dispose();

                    var isRedirect =
                        response.StatusCode == HttpStatusCode.Moved
                        || response.StatusCode == HttpStatusCode.Found;

                    var responseHeaders = response.Headers;

                    if (isRedirect && isCatchRedirect && typeof(T) == typeof(string))
                    {
                        var responseData = response.Headers.Location.AbsoluteUri;

                        return FetchResponse<T>.Create(
                            response.StatusCode,
                            default(T),
                            response.Headers?.ETag?.Tag,
                            isRedirect: true,
                            redirectUrl: responseData);
                    }
                    else if (response.Content != null)
                    {
                        object responseData;

                        if (typeof(T) == typeof(byte[]))
                            responseData = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                        else
                            responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        object resultData;

                        if (typeof(T) == typeof(byte[]))
                            resultData = responseData != null ? responseData as byte[] : new byte[0];
                        else if (typeof(T) == typeof(string))
                            resultData = responseData != null ? responseData as string : string.Empty;
                        else if (typeof(T) == typeof(HttpResponseMessage))
                            resultData = response;
                        else
                            resultData = responseData != null
                                ? JsonConvert.DeserializeObject<T>(responseData as string)
                                : TypeExtensions.GetDefaultValue<T>();

                        return FetchResponse<T>.Create(
                            response.StatusCode,
                            (T)resultData,
                            response.Headers?.ETag?.Tag,
                            isNotModified: response.StatusCode == HttpStatusCode.NotModified);
                    }
                    else
                        throw new Exception($"request to {url} error {response.StatusCode}");
                }
            }
        }
    }
}