using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap;
using Core.Libs.Integration.GoogleMap.Models.Enum.Places;
using Core.Libs.Integration.GoogleMap.Models.Enum.Routes;
using Core.Libs.Integration.GoogleMap.Models.Places;
using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;
using Core.Libs.Integration.GoogleMap.Models.Routes.DistanceMatrix;
using Core.Libs.Utils.Models;

namespace Hamilton.Business
{
    public interface IGoogleMapBusiness
    {
        #region Google Map APIs Routes
        Task<FetchResponse<Direction>> Directions(
            string origin,
            string destination,
            string waypoints = null,
            string mode = null,
            bool? alternatives = null,
            string avoid = null,
            string language = null,
            string units = null,
            string region = null);

        Task<FetchResponse<DistanceMatrix>> DistanceMatrix(
            string origins,
            string destinations,
            string mode = null,
            string language = null,
            string region = null,
            string avoid = null,
            string units = null
          );

        #endregion

        #region Google Map APIs Places
        Task<FetchResponse<PlaceSearch>> PlaceSearch(
            string input,
            string inputtype,
            string language = null,
            string fields = null,
            string locationbias = null);

        Task<FetchResponse<Result<PlaceDetail>>> PlaceDetails(
            string place_id,
            string language = null,
            string region = null,
            string sessiontoken = null,
            string fields = null);

        #endregion
    }

    public class GoogleMapBusiness : IGoogleMapBusiness
    {
        private readonly IGoogleMapClient client;
        public GoogleMapBusiness(
            IGoogleMapClient client)
        {
            this.client = client;
        }

        public Task<FetchResponse<Direction>> Directions(
            string origin,
            string destination,
            string waypoints,
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

            return client.Routes.GetDirection(request);
        }

        public Task<FetchResponse<DistanceMatrix>> DistanceMatrix(
            string origins,
            string destinations,
            string mode = null,
            string language = null,
            string region = null,
            string avoid = null,
            string units = null)
        {
            var request = new DistanceMatrixRequest();

            if (!string.IsNullOrEmpty(origins))
                request.origins = origins;

            if (!string.IsNullOrEmpty(destinations))
                request.destinations = destinations;

            if (!string.IsNullOrEmpty(mode))
                if (mode == "driving")
                    request.mode = TravelMode.Driving;
                else if (mode == "walking")
                    request.mode = TravelMode.Walking;
                else if (mode == "bicycling")
                    request.mode = TravelMode.Bicycling;
                else if (mode == "transit")
                    request.mode = TravelMode.Transit;

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

            return client.Routes.GetDistanceMatrix(request);
        }

        public Task<FetchResponse<Result<PlaceDetail>>> PlaceDetails(
            string place_id, 
            string language = null, 
            string region = null, 
            string sessiontoken = null, 
            string fields = null)
        {
            var request = new PlaceDetailRequest();

            if(!string.IsNullOrEmpty(place_id))
                request.place_id = place_id;

            if(!string.IsNullOrEmpty(language))
                request.language = language;

            if(!string.IsNullOrEmpty(region))
                request.region =region;

            if(!string.IsNullOrEmpty(sessiontoken))
                request.sessiontoken = sessiontoken;

            if(!string.IsNullOrEmpty(fields))
                request.fields = fields;

            return client.Places.PlaceDetail(request);
        }

        public Task<FetchResponse<PlaceSearch>> PlaceSearch(
            string input,
            string inputtype,
            string language = null,
            string fields = null,
            string locationbias = null)
        {
            var request = new PlaceSearchRequest();

            if (!string.IsNullOrEmpty(input))
                request.input = input;

            if (!string.IsNullOrEmpty(inputtype))
                if (inputtype == "textquery")
                    request.inputtype = InputType.TextQuery;
                else if (inputtype == "phonenumber")
                    request.inputtype = InputType.PhoneNumber;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            if (!string.IsNullOrEmpty(fields))
                request.fields = fields;

            if (!string.IsNullOrEmpty(locationbias))
                request.locationbias = locationbias;

            return client.Places.PlaceSearch(request);
        }
    }
}