using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap.Models.Enum.Routes.DistanceMatrix;
using Core.Libs.Utils.Helpers;
using Core.Libs.Utils.Models;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapDistanceMatrix
    {
        Task<FetchResponse<Models.Routes.DistanceMatrix.DistanceMatrix>> GetDistanceMatrix(
            Models.Routes.DistanceMatrix.DistanceMatrixRequest request);
    }

    public class GoogleMapDistanceMatrix : IGoogleMapDistanceMatrix
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        private const string DISTANCEMATRIX_URLS = "distancematrix";
        public GoogleMapDistanceMatrix(
            HttpClient httpClient,
            GoogleMapConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public Task<FetchResponse<Models.Routes.DistanceMatrix.DistanceMatrix>> GetDistanceMatrix(
            Models.Routes.DistanceMatrix.DistanceMatrixRequest request)
        {
            var @params = new List<(string, object)>();

            if(string.IsNullOrEmpty(config.Key))
                throw new ArgumentNullException(nameof(config.Key));

            if (request.origins != null
                && request.origins.Length > 0)
                @params.Add(new("origins", string.Join("|", request.origins.Select(a => a.ToString()))));

            if (request.destinations != null
                && request.destinations.Length > 0)
                @params.Add(new("destinations", string.Join("|", request.destinations.Select(a => a.ToString()))));

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
                @params.Add(("arrival_time", request.arrival_time));

            if (request.departure_time.HasValue)
                @params.Add(("departure_time", request.departure_time));

            return this.httpClient.ExecuteGet<Models.Routes.DistanceMatrix.DistanceMatrix>(
                Utils.GetApiUrl(
                    DISTANCEMATRIX_URLS,
                    config.Key,
                    @params));
        }
    }
}