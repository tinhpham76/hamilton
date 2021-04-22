using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap.Models.Enum.Places;
using Core.Libs.Integration.GoogleMap.Models.Places;
using Core.Libs.Integration.GoogleMap.Models.Places.Geocoding;
using Core.Libs.Utils.Helpers;
using Core.Libs.Utils.Models;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapPlaces
    {
        Task<FetchResponse<PlaceSearch>> PlaceSearch(
            PlaceSearchRequest request);

        Task<FetchResponse<Result<List<NearbySearch>>>> NearbySearch(
            NearbySearchRequest request);

        Task<FetchResponse<Result<List<TextSearch>>>> TextSearch(
            TextSearchRequest request);

        Task<FetchResponse<Result<List<AddressComponents>>>> GetGeocoding(
            GeocodingRequest request);
    }

    public class GoogleMapPlaces : IGoogleMapPlaces
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        private const string PLACE_SEARCH_URL = "place/findplacefromtext";
        private const string NEARBY_SEARCH_URL = "place/nearbysearch";
        private const string TEXT_SEARCH_URL = "place/textsearch";
        private const string GECODING_URLS = "geocode";
        public GoogleMapPlaces(
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
                @params.Add(("fields", string.Join(",", request.fields.Select(x => Enum.GetName(typeof(Field), x).ToLower()))));

            if (!string.IsNullOrEmpty(request.locationbias))
                @params.Add(("locationbias", request.locationbias));

            return this.httpClient.ExecuteGet<PlaceSearch>(
                Utils.GetApiUrl(
                    PLACE_SEARCH_URL,
                    config.Key,
                    @params));
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

        public Task<FetchResponse<Result<List<NearbySearch>>>> NearbySearch(
            NearbySearchRequest request)
        {
            var @params = new List<(string, object)>();

            if (string.IsNullOrEmpty(config.Key))
                throw new ArgumentNullException(nameof(config.Key));

            if (!string.IsNullOrEmpty(request.input))
                @params.Add(("input", request.input));

            if (!string.IsNullOrEmpty(request.location))
                @params.Add(("location", request.location));

            if (request.radius.HasValue)
                @params.Add(("radius", request.radius));

            if (!string.IsNullOrEmpty(request.keyword))
                @params.Add(("keyword", request.keyword));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (request.minprice.HasValue)
                @params.Add(("minprice", request.minprice));

            if (request.maxprice.HasValue)
                @params.Add(("maxprice", request.maxprice));

            if (!string.IsNullOrEmpty(request.name))
                @params.Add(("name", request.name));

            if (!string.IsNullOrEmpty(request.opennow))
                @params.Add(("opennow", request.opennow));

            if (request.rankby.HasValue)
                @params.Add(("rankby", Enum.GetName(typeof(Rankby), (int)request.rankby.Value).ToLower()));

            if (!string.IsNullOrEmpty(request.type))
                @params.Add(("type", request.type));

            if (!string.IsNullOrEmpty(request.pagetoken))
                @params.Add(("pagetoken", request.pagetoken));

            return this.httpClient.ExecuteGet<Result<List<NearbySearch>>>(
                Utils.GetApiUrl(
                    NEARBY_SEARCH_URL,
                    config.Key,
                    @params));
        }

        public Task<FetchResponse<Result<List<TextSearch>>>> TextSearch(
            TextSearchRequest request)
        {
            var @params = new List<(string, object)>();

            if (string.IsNullOrEmpty(config.Key))
                throw new ArgumentNullException(nameof(config.Key));

            if (!string.IsNullOrEmpty(request.query))
                @params.Add(("query", request.query));

            if (!string.IsNullOrEmpty(request.region))
                @params.Add(("region", request.region));

            if (!string.IsNullOrEmpty(request.location))
                @params.Add(("location", request.location));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (request.radius.HasValue)
                @params.Add(("radius", request.radius));

            if (request.minprice.HasValue)
                @params.Add(("minprice", request.minprice));

            if (request.maxprice.HasValue)
                @params.Add(("maxprice", request.maxprice));

            if (!string.IsNullOrEmpty(request.opennow))
                @params.Add(("opennow", request.opennow));

            if (!string.IsNullOrEmpty(request.pagetoken))
                @params.Add(("pagetoken", request.pagetoken));

            if (!string.IsNullOrEmpty(request.type))
                @params.Add(("type", request.type));

            return this.httpClient.ExecuteGet<Result<List<TextSearch>>>(
                Utils.GetApiUrl(
                    TEXT_SEARCH_URL,
                    config.Key,
                    @params));
        }
    }
}