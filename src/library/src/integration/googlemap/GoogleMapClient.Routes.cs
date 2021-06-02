using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap.Models.Enum.Routes;
using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;
using Core.Libs.Integration.GoogleMap.Models.Routes.DistanceMatrix;
using Core.Libs.Utils.Helpers;
using Core.Libs.Utils.Models;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapRoutes
    {
        Task<FetchResponse<Direction>> GetDirection(
            DirectionRequest request,
            string key);

        Task<FetchResponse<DistanceMatrix>> GetDistanceMatrix(
            DistanceMatrixRequest request,
            string key);
    }

    public class GoogleMapRoutes : IGoogleMapRoutes
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        private const string DIRECTION_URLS = "directions";
        private const string DISTANCEMATRIX_URLS = "distancematrix";
        public GoogleMapRoutes(
            HttpClient httpClient,
            GoogleMapConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public Task<FetchResponse<Direction>> GetDirection(
            DirectionRequest request,
            string key)
        {
            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.origin))
                @params.Add(("origin", request.origin));

            if (!string.IsNullOrEmpty(request.destination))
                @params.Add(("destination", request.destination));

            if (request.mode.HasValue)
                @params.Add(("model", Enum.GetName(typeof(TravelMode), (int)request.mode.Value).ToLower()));

            if (request.waypoints != null
                && request.waypoints.Length > 0)
                @params.Add(("waypoints", request.waypoints));

            if (request.alternatives.HasValue)
                @params.Add(("alternatives", request.alternatives.Value));

            if (request.avoid.HasValue)
                @params.Add(("avoid", Enum.GetName(typeof(Avoid), (int)request.avoid.Value).ToLower()));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (request.units.HasValue)
                @params.Add(("units", Enum.GetName(typeof(Unit), request.units.Value).ToLower()));

            if (!string.IsNullOrEmpty(request.region))
                @params.Add(("region", request.region));

            if (request.arrival_time.HasValue)
                @params.Add(("arrival_time", request.arrival_time.Value));

            if (request.departure_time.HasValue)
                @params.Add(("departure_time", request.departure_time.Value));

            return this.httpClient.ExecuteGet<Direction>(
                Utils.GetApiUrl(DIRECTION_URLS, key, @params));
        }

        public Task<FetchResponse<DistanceMatrix>> GetDistanceMatrix(
            DistanceMatrixRequest request,
            string key)
        {
            var @params = new List<(string, object)>();

            if (!string.IsNullOrEmpty(request.origins))
                @params.Add(("origins", request.origins));

            if (!string.IsNullOrEmpty(request.destinations))
                @params.Add(("destinations", request.destinations));

            if (request.mode.HasValue)
                @params.Add(("mode", Enum.GetName(typeof(TravelMode), (int)request.mode.Value).ToLower()));

            if (!string.IsNullOrEmpty(request.language))
                @params.Add(("language", request.language));

            if (!string.IsNullOrEmpty(request.region))
                @params.Add(("region", request.region));

            if (request.avoid.HasValue)
                @params.Add(("avoid", Enum.GetName(typeof(Avoid), (int)request.avoid.Value).ToLower()));

            if (request.units.HasValue)
                @params.Add(("units", Enum.GetName(typeof(Unit), (int)request.units.Value).ToLower()));

            if (request.arrival_time.HasValue)
                @params.Add(("arrival_time", request.arrival_time.Value));

            if (request.departure_time.HasValue)
                @params.Add(("departure_time", request.departure_time));

            return this.httpClient.ExecuteGet<Models.Routes.DistanceMatrix.DistanceMatrix>(
                Utils.GetApiUrl(DISTANCEMATRIX_URLS, key, @params));
        }
    }
}