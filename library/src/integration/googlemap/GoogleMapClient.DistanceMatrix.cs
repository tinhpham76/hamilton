using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Libs.Utils.Helpers;
using Core.Libs.Utils.Models;

namespace Core.Libs.Integration.GoogleMap
{
    public interface IGoogleMapDistanceMatrix
    {
        Task<FetchResponse<Models.DistanceMatrix.DistanceMatrix>> GetDistanceMatrix(
            Models.DistanceMatrix.DistanceMatrixRequest request);

    }

    public class GoogleMapDistanceMatrix : IGoogleMapDistanceMatrix
    {
        private readonly HttpClient httpClient;
        private readonly GoogleMapConfig config;
        public GoogleMapDistanceMatrix(
            HttpClient httpClient,
            GoogleMapConfig config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public Task<FetchResponse<Models.DistanceMatrix.DistanceMatrix>> GetDistanceMatrix(
            Models.DistanceMatrix.DistanceMatrixRequest request)
        {
            var @params = new List<(string, object)>();

            if (request.origins != null
                && request.origins.Count > 0)
                @params.Add(new("origins", string.Join("|", request.origins.Select(a => a.ToString()))));

            if (request.destinations != null
                && request.destinations.Count > 0)
                @params.Add(new("destinations", string.Join("|", request.destinations.Select(a => a.ToString()))));

            return this.httpClient.ExecuteGet<Models.DistanceMatrix.DistanceMatrix>(
                Utils.GetApiUrl(
                    "distancematrix",
                    config.Key,
                    @params));
        }

    }
}