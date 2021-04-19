using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap;
using Core.Libs.Integration.GoogleMap.Models.Enum.Routes;
using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;

namespace Hamilton.Business
{
    public interface IGoogleMapBusiness
    {
        Task<Direction> Directions(
            string origin,
            string destination,
            string[] waypoints = null,
            string mode = null,
            bool? alternatives = null,
            string avoid = null,
            string language = null,
            string units = null,
            string region = null);
    }

    public class GoogleMapBusiness : IGoogleMapBusiness
    {
        private readonly IGoogleMapClient client;
        public GoogleMapBusiness(
            IGoogleMapClient client)
        {
            this.client = client;
        }

        public async Task<Direction> Directions(
            string origin,
            string destination,
            string[] waypoints,
            string mode,
            bool? alternatives,
            string avoid,
            string language,
            string units,
            string region)
        {
            var request = new DirectionRequest();

            if (!string.IsNullOrEmpty(origin))
                request.origin = origin;

            if (!string.IsNullOrEmpty(destination))
                request.destination = destination;

            if (waypoints != null && waypoints.Length > 0)
                request.waypoints = waypoints;

            if (!string.IsNullOrEmpty(mode))
                if (mode == "driving")
                    request.mode = TravelMode.Driving;
                else if (mode == "walking")
                    request.mode = TravelMode.Walking;
                else if (mode == "bicycling")
                    request.mode = TravelMode.Bicycling;
                else if (mode == "transit")
                    request.mode = TravelMode.Transit;

            if (alternatives.HasValue)
                request.alternatives = alternatives.Value;

            if (!string.IsNullOrEmpty(avoid))
                if (avoid == "tolls")
                    request.avoid = Avoid.Tolls;
                else if (avoid == "ferries")
                    request.avoid = Avoid.Ferries;
                else if (avoid == "highways")
                    request.avoid = Avoid.Highways;
                else if (avoid == "indoor")
                    request.avoid = Avoid.Indoor;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            if (!string.IsNullOrEmpty(units))
                if (units == "imperial")
                    request.units = Unit.Imperial;
                else if (units == "metric")
                    request.units = Unit.Metric;

            if (!string.IsNullOrEmpty(region))
                request.region = region;

            var response = await client.Routes.GetDirection(request);

            return response.Data;
        }
    }
}