using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap.Models.Enum.Places;
using Core.Libs.Integration.GoogleMap.Models.Places;
using Core.Libs.Integration.GoogleMap.Models.Places.Geocoding;
using Core.Libs.Integration.GoogleMap.Models.Places.PlaceSearch;
using Core.Libs.Utils.Helpers;
using Core.Libs.Utils.Models;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapPlaces
    {
        Task<FetchResponse<Candidates<FindPlace>>> FindPlace(
            FindPlaceRequest request,
            string key);

        Task<FetchResponse<Results<NearbySearch>>> NearbySearch(
            NearbySearchRequest request,
            string key);

        Task<FetchResponse<Results<TextSearch>>> TextSearch(
            TextSearchRequest request,
            string key);

        Task<FetchResponse<Result<PlaceDetail>>> PlaceDetail(
            PlaceDetailRequest request,
            string key);

        Task<FetchResponse<Prediction<List<PlaceAutocomplete>>>> PlaceAutocomplete(
            PlaceAutocompleteRequest request,
            string key);

        Task<FetchResponse<Prediction<List<QueryAutocomplete>>>> QueryAutocomplete(
            QueryAutocompleteRequest request,
            string key);

        // Task<FetchResponse<Result<List<Geocoding>>>> GetGeocoding(
        //     GeocodingRequest request,
        //     string key);
    }

    public class GoogleMapPlaces : IGoogleMapPlaces
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        private const string FIND_PLACE_URL = "place/findplacefromtext";
        private const string NEARBY_SEARCH_URL = "place/nearbysearch";
        private const string TEXT_SEARCH_URL = "place/textsearch";
        private const string PLACE_DETAIL_URL = "place/details";
        private const string PLACE_AUTOCOMPLETE_URL = "place/autocomplete";
        private const string QUERY_AUTOCOMPLETE_URL = "place/queryautocomplete";
        private const string GECODING_URLS = "geocode";
        public GoogleMapPlaces(
            HttpClient httpClient,
            GoogleMapConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public Task<FetchResponse<Candidates<FindPlace>>> FindPlace(
            FindPlaceRequest request,
            string key)
        {
            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.input))
                @params.Add(("input", request.input));

            if (!string.IsNullOrEmpty(request.inputtype))
                @params.Add(("inputtype", request.inputtype));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (!string.IsNullOrEmpty(request.fields))
                @params.Add(("fields", request.fields));

            if (!string.IsNullOrEmpty(request.locationbias))
                @params.Add(("locationbias", request.locationbias));

            return this.httpClient.ExecuteGet<Candidates<FindPlace>>(
                Utils.GetApiUrl(FIND_PLACE_URL, key, @params));
        }

        // public Task<FetchResponse<Result<List<Geocoding>>>> GetGeocoding(
        //     GeocodingRequest request,
        //     string key)
        // {
        //     var @params = new List<(string, object)>();

        //     if (!string.IsNullOrEmpty(request.address))
        //         @params.Add(("address", request.address));

        //     if (!string.IsNullOrEmpty(request.components))
        //         @params.Add(("components", request.components));

        //     if (!string.IsNullOrEmpty(request.bounds))
        //         @params.Add(("bounds", request.bounds));

        //     if (!string.IsNullOrEmpty(request.language))
        //         @params.Add(("language", request.language));

        //     if (!string.IsNullOrEmpty(request.region))
        //         @params.Add(("region", request.region));

        //     return this.httpClient.ExecuteGet<Result<List<Geocoding>>>(
        //         Utils.GetApiUrl(
        //             GECODING_URLS,
        //             key,
        //             @params));
        // }

        public Task<FetchResponse<Results<NearbySearch>>> NearbySearch(
            NearbySearchRequest request,
            string key)
        {
            var @params = new List<(string, object)>();

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
                @params.Add(("minprice", request.minprice.Value));

            if (request.maxprice.HasValue)
                @params.Add(("maxprice", request.maxprice.Value));

            if (!string.IsNullOrEmpty(request.name))
                @params.Add(("name", request.name));

            // if (!string.IsNullOrEmpty(request.opennow))
            //     @params.Add(("opennow", request.opennow));

            // if (request.rankby.HasValue)
            //     @params.Add(("rankby", Enum.GetName(typeof(Rankby), (int)request.rankby.Value).ToLower()));

            if (!string.IsNullOrEmpty(request.type))
                @params.Add(("type", request.type));

            // if (!string.IsNullOrEmpty(request.pagetoken))
            //     @params.Add(("pagetoken", request.pagetoken));

            return this.httpClient.ExecuteGet<Results<NearbySearch>>(
                Utils.GetApiUrl(NEARBY_SEARCH_URL, key, @params));
        }

        public Task<FetchResponse<Results<TextSearch>>> TextSearch(
            TextSearchRequest request,
            string key)
        {
            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.query))
                @params.Add(("query", request.query));

            if (!string.IsNullOrEmpty(request.region))
                @params.Add(("region", request.region));

            if (!string.IsNullOrEmpty(request.location))
                @params.Add(("location", request.location));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (request.radius.HasValue)
                @params.Add(("radius", request.radius.Value));

            if (!string.IsNullOrEmpty(request.type))
                @params.Add(("type", request.type));

            return this.httpClient.ExecuteGet<Results<TextSearch>>(
                Utils.GetApiUrl(TEXT_SEARCH_URL, key, @params));
        }

        public Task<FetchResponse<Result<PlaceDetail>>> PlaceDetail(
            PlaceDetailRequest request,
            string key)
        {
            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.place_id))
                @params.Add(("place_id", request.place_id));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (!string.IsNullOrEmpty(request.region))
                @params.Add(("region", request.region));

            if (!string.IsNullOrEmpty(request.sessiontoken))
                @params.Add(("sessiontoken", request.sessiontoken));

            if (!string.IsNullOrEmpty(request.fields))
                @params.Add(("fields", request.fields));

            return this.httpClient.ExecuteGet<Result<PlaceDetail>>(
                Utils.GetApiUrl(PLACE_DETAIL_URL, key, @params));
        }

        public Task<FetchResponse<Prediction<List<PlaceAutocomplete>>>> PlaceAutocomplete(
            PlaceAutocompleteRequest request,
            string key)
        {
            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.input))
                @params.Add(("input", request.input));

            if (!string.IsNullOrEmpty(request.sessiontoken))
                @params.Add(("sessiontoken", request.sessiontoken));

            if (request.offset.HasValue)
                @params.Add(("offset", request.offset.Value));

            if (!string.IsNullOrEmpty(request.origin))
                @params.Add(("origin", request.origin));

            if (!string.IsNullOrEmpty(request.location))
                @params.Add(("location", request.location));

            if (request.radius.HasValue)
                @params.Add(("radius", request.radius.Value));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (!string.IsNullOrEmpty(request.types))
                @params.Add(("types", request.types));

            if (!string.IsNullOrEmpty(request.components))
                @params.Add(("components", request.components));

            if (!string.IsNullOrEmpty(request.strictbounds))
                @params.Add(("strictbounds", request.strictbounds));

            return this.httpClient.ExecuteGet<Prediction<List<PlaceAutocomplete>>>(
                Utils.GetApiUrl(
                    PLACE_AUTOCOMPLETE_URL,
                    key,
                    @params));
        }

        public Task<FetchResponse<Prediction<List<QueryAutocomplete>>>> QueryAutocomplete(
            QueryAutocompleteRequest request,
            string key)
        {
            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.input))
                @params.Add(("input", request.input));

            if (request.offset.HasValue)
                @params.Add(("offset", request.offset.Value));

            if (!string.IsNullOrEmpty(request.location))
                @params.Add(("location", request.location));

            if (request.radius.HasValue)
                @params.Add(("radius", request.radius.Value));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            return this.httpClient.ExecuteGet<Prediction<List<QueryAutocomplete>>>(
                Utils.GetApiUrl(
                    QUERY_AUTOCOMPLETE_URL,
                    key,
                    @params));
        }
    }
}