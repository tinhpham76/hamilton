using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Libs.Utils.Helpers;
using Core.Libs.Utils.Models;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapDirection
    {
        Task<FetchResponse<Models.Direction.Direction>> GetDirection(
            Models.Direction.DirectionRequest request);

    }

    public class GoogleMapDirection : IGoogleMapDirection
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        public GoogleMapDirection(
            HttpClient httpClient,
            GoogleMapConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public Task<FetchResponse<Models.Direction.Direction>> GetDirection(
            Models.Direction.DirectionRequest request)
        {
            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.origin))
                @params.Add(("origin", request.origin));

            if (!string.IsNullOrEmpty(request.destination))
                @params.Add(("destination", request.destination));

            return this.httpClient.ExecuteGet<Models.Direction.Direction>(
                Utils.GetApiUrl(
                    "directions",
                    config.Key,
                    @params));
        }

    }
}