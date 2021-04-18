using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap.Models.Enum.Places;
using Core.Libs.Integration.GoogleMap.Models.Places;
using Core.Libs.Utils.Helpers;
using Core.Libs.Utils.Models;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapPlace
    {
        Task<FetchResponse<PlaceSearch>> PlaceSearch(
            PlaceSearchRequest request);
    }

    public class GoogleMapPlace : IGoogleMapPlace
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        private const string PLACE_SEARCH_URL = "place/findplacefromtext";
        public GoogleMapPlace(
            HttpClient httpClient,
            GoogleMapConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public Task<FetchResponse<PlaceSearch>> PlaceSearch(
            PlaceSearchRequest request)
        {
            if (string.IsNullOrEmpty(config.Key))
                throw new ArgumentNullException(nameof(config.Key));

            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.input))
                @params.Add(("input", request.input));

            if (request.inputtype.HasValue)
                @params.Add(("inputtype", Enum.GetName(typeof(InputType), (int)request.inputtype.Value).ToLower()));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (request.fields != null
                && request.fields.Length > 0)
                @params.Add(("fields", string.Join(",", request.fields.Select( x => Enum.GetName(typeof(Field), x).ToLower()))));

            if (!string.IsNullOrEmpty(request.locationbias))
                @params.Add(("locationbias", request.locationbias));

            return this.httpClient.ExecuteGet<PlaceSearch>(
                Utils.GetApiUrl(
                    PLACE_SEARCH_URL,
                    config.Key,
                    @params));
        }
    }
}