using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Libs.Integration.GoogleMap;
using Core.Libs.Integration.GoogleMap.Models.Enum.Routes;
using Core.Libs.Integration.GoogleMap.Models.Places;
using Core.Libs.Integration.GoogleMap.Models.Places.PlaceSearch;
using Core.Libs.Integration.GoogleMap.Models.Routes.Directions;
using Core.Libs.Integration.GoogleMap.Models.Routes.DistanceMatrix;
using Core.Libs.Utils.Models;

namespace Hamilton.Business
{
    public interface IGoogleMapBusiness
    {
        #region Google Map APIs Routes
        Task<FetchResponse<Direction>> Direction(
            string origin,
            string destination,
            string key,
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
            string key,
            string mode = null,
            string language = null,
            string region = null,
            string avoid = null,
            string units = null
          );

        #endregion

        #region Google Map APIs Places
        Task<FetchResponse<Candidates<FindPlace>>> FindPlace(
            string input,
            string inputtype,
            string key,
            string language = null,
            string fields = null,
            string locationbias = null);

        Task<FetchResponse<Results<NearbySearch>>> NearbySearch(
            string location,
            long? radius,
            string key,
            string keyword = null,
            string language = null,
            string name = null,
            string type = null);

        Task<FetchResponse<Results<TextSearch>>> TextSearch(
            string query,
            long? radius,
            string key,
            string region = null,
            string location = null,
            string language = null,
            string type = null);

        Task<FetchResponse<Result<PlaceDetail>>> PlaceDetail(
            string place_id,
            string key,
            string language = null,
            string region = null,
            string sessiontoken = null,
            string fields = null);

        Task<FetchResponse<Predictions<PlaceAutocomplete>>> PlaceAutocomplete(
            string input,
            int? offset,
            long? radius,
            string key,
            string sessiontoken = null,
            string origin = null,
            string location = null,
            string language = null,
            string types = null,
            string components = null,
            string strictbounds = null);

        Task<FetchResponse<Predictions<QueryAutocomplete>>> QueryAutocomplete(
            string input,
            int? offset,
            long? radius,
            string key,
            string location = null,
            string language = null);

        Task<FetchResponse<Results<Geocoding>>> Geocoding(
            string address,
            string key,
            string components = null,
            string bounds = null,
            string language = null,
            string region = null);

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

        public Task<FetchResponse<Direction>> Direction(
            string origin,
            string destination,
            string key,
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

            return client.Routes.GetDirection(request, key);
        }

        public Task<FetchResponse<DistanceMatrix>> DistanceMatrix(
            string origins,
            string destinations,
            string key,
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

            return client.Routes.GetDistanceMatrix(request, key);
        }

        public Task<FetchResponse<Results<Geocoding>>> Geocoding(
            string address,
            string key,
            string components = null,
            string bounds = null,
            string language = null,
            string region = null)
        {
            var request = new GeocodingRequest();

            if (!string.IsNullOrEmpty(address))
                request.address = address;

            if (!string.IsNullOrEmpty(components))
                request.components = components;

            if (!string.IsNullOrEmpty(bounds))
                request.bounds = bounds;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            if (!string.IsNullOrEmpty(region))
                request.region = region;

            return client.Places.Geocoding(request, key);
        }

        public Task<FetchResponse<Results<NearbySearch>>> NearbySearch(
            string location,
            long? radius,
            string key,
            string keyword = null,
            string language = null,
            string name = null,
            string type = null)
        {
            var request = new NearbySearchRequest();

            if (!string.IsNullOrEmpty(location))
                request.location = location;

            if (radius.HasValue)
                request.radius = radius.Value;

            if (!string.IsNullOrEmpty(keyword))
                request.keyword = keyword;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            if (!string.IsNullOrEmpty(name))
                request.name = name;

            if (!string.IsNullOrEmpty(type))
                request.type = type;

            return client.Places.NearbySearch(request, key);
        }

        public Task<FetchResponse<Predictions<PlaceAutocomplete>>> PlaceAutocomplete(
            string input,
            int? offset,
            long? radius,
            string key,
            string sessiontoken = null,
            string origin = null,
            string location = null,
            string language = null,
            string types = null,
            string components = null,
            string strictbounds = null)
        {
            var request = new PlaceAutocompleteRequest();

            if (!string.IsNullOrEmpty(input))
                request.input = input;

            if (offset.HasValue)
                request.offset = offset.Value;

            if (radius.HasValue)
                request.radius = request.radius;

            if (!string.IsNullOrEmpty(sessiontoken))
                request.sessiontoken = sessiontoken;

            if (!string.IsNullOrEmpty(origin))
                request.origin = origin;

            if (!string.IsNullOrEmpty(location))
                request.location = location;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            if (!string.IsNullOrEmpty(types))
                request.types = types;

            if (!string.IsNullOrEmpty(components))
                request.components = components;

            if (!string.IsNullOrEmpty(strictbounds))
                request.strictbounds = strictbounds;

            return client.Places.PlaceAutocomplete(request, key);
        }

        public Task<FetchResponse<Result<PlaceDetail>>> PlaceDetail(
            string place_id,
            string key,
            string language = null,
            string region = null,
            string sessiontoken = null,
            string fields = null)
        {
            var request = new PlaceDetailRequest();

            if (!string.IsNullOrEmpty(place_id))
                request.place_id = place_id;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            if (!string.IsNullOrEmpty(region))
                request.region = region;

            if (!string.IsNullOrEmpty(sessiontoken))
                request.sessiontoken = sessiontoken;

            if (!string.IsNullOrEmpty(fields))
                request.fields = fields;

            return client.Places.PlaceDetail(request, key);
        }

        public Task<FetchResponse<Candidates<FindPlace>>> FindPlace(
            string input,
            string inputtype,
            string key,
            string language = null,
            string fields = null,
            string locationbias = null)
        {
            var request = new FindPlaceRequest();

            if (!string.IsNullOrEmpty(input))
                request.input = input;

            if (!string.IsNullOrEmpty(inputtype))
                request.inputtype = inputtype;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            if (!string.IsNullOrEmpty(fields))
                request.fields = fields;

            if (!string.IsNullOrEmpty(locationbias))
                request.locationbias = locationbias;

            return client.Places.FindPlace(request, key);
        }

        public Task<FetchResponse<Predictions<QueryAutocomplete>>> QueryAutocomplete(
            string input,
            int? offset,
            long? radius,
            string key,
            string location = null,
            string language = null)
        {
            var request = new QueryAutocompleteRequest();

            if (!string.IsNullOrEmpty(input))
                request.input = input;

            if (offset.HasValue)
                request.offset = offset.Value;

            if (radius.HasValue)
                request.radius = radius.Value;

            if (!string.IsNullOrEmpty(location))
                request.location = location;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            return client.Places.QueryAutocomplete(request, key);
        }

        public Task<FetchResponse<Results<TextSearch>>> TextSearch(
            string query,
            long? radius,
            string key,
            string region = null,
            string location = null,
            string language = null,
            string type = null)
        {
            var request = new TextSearchRequest();

            if (!string.IsNullOrEmpty(query))
                request.query = query;

            if (radius.HasValue)
                request.radius = radius.Value;

            if (!string.IsNullOrEmpty(region))
                request.region = region;

            if (!string.IsNullOrEmpty(location))
                request.location = location;

            if (!string.IsNullOrEmpty(language))
                request.language = language;

            if (!string.IsNullOrEmpty(type))
                request.type = type;

            return client.Places.TextSearch(request, key);
        }
    }
}