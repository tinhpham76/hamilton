using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap.Models.Places.Geocoding;
using Core.Libs.Utils.Helpers;
using Core.Libs.Utils.Models;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapGeocoding
    {
        Task<FetchResponse<Result<List<AddressComponents>>>> GetGeocoding(
            GeocodingRequest request);
    }

    public class GoogleMapGeocoding : IGoogleMapGeocoding
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        private const string GECODING_URLS = "geocode";
        public GoogleMapGeocoding(
            HttpClient httpClient,
            GoogleMapConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public Task<FetchResponse<Result<List<AddressComponents>>>> GetGeocoding(
            GeocodingRequest request)
        {
            var @params = new List<(string, object)>();

            if (string.IsNullOrEmpty(config.Key))
                throw new ArgumentNullException(nameof(config.Key));

            if (!string.IsNullOrEmpty(request.address))
                @params.Add(("address", request.address));

            if (request.components != null
                && request.components.Length > 0)
                @params.Add(("components", string.Join("|", request.components.Select(a => a.ToString()))));

            if (request.bounds != null
                && request.bounds.Length > 0)
                @params.Add(("bounds", string.Join("|", request.bounds.Select(a => a.ToString()))));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (!string.IsNullOrEmpty(request.region))
                @params.Add(("region", request.region));

            return this.httpClient.ExecuteGet<Result<List<AddressComponents>>>(
                Utils.GetApiUrl(
                    GECODING_URLS,
                    config.Key,
                    @params));
        }
    }
}