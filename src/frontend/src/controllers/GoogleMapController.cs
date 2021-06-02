using System.Threading.Tasks;
using Core.Libs.Client;
using Core.Libs.Client.Models.Json;
using Hamilton.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hamilton.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("apis/[controller]")]
    public class GoogleMapController : BaseController
    {
        private readonly IGoogleMapBusiness googleMap;

        public GoogleMapController(
            ILogger<GoogleMapController> logger,
            IGoogleMapBusiness googleMap) : base(logger)
        {
            this.googleMap = googleMap;
        }

        [HttpGet]
        [Route(Program.ROUTES_DIRECTIONS)]
        public async Task<IActionResult> Direction(
            [FromQuery] string origin,
            [FromQuery] string destination,
            [FromQuery] string mode,
            [FromQuery] string waypoints,
            [FromQuery] bool alternatives,
            [FromQuery] string avoid,
            [FromQuery] string language,
            [FromQuery] string units,
            [FromQuery] string region,
            [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(origin))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'origin' parameter."
                });

            if (string.IsNullOrEmpty(destination))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'destination' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.Direction(
                origin, destination, key, waypoints, mode, alternatives, avoid, language, units, region);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data);
        }

        [HttpGet]
        [Route(Program.ROUTES_DISTANCEMATRIX)]
        public async Task<IActionResult> DistanceMatrix(
            [FromQuery] string origins,
            [FromQuery] string destinations,
            [FromQuery] string mode,
            [FromQuery] string language,
            [FromQuery] string region,
            [FromQuery] string avoid,
            [FromQuery] string units,
            [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(origins))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'origins' parameter."
                });

            if (string.IsNullOrEmpty(destinations))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'destinations' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.DistanceMatrix(
                origins, destinations, key, mode, language, region, avoid, units);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data);
        }

        [HttpGet]
        [Route(Program.PLACES_FIND_PLACE_FROM_TEXT)]
        public async Task<IActionResult> FindPlace(
            [FromQuery] string input,
            [FromQuery] string inputtype,
            [FromQuery] string language,
            [FromQuery] string fields,
            [FromQuery] string locationbias,
            [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(input))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'input' parameter."
                });

            if (string.IsNullOrEmpty(inputtype))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'inputtype' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.FindPlace(
                input, inputtype, key, language, fields, locationbias);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data.candidates);
        }

        [HttpGet]
        [Route(Program.PLACES_NEARBY_SEARCH)]
        public async Task<IActionResult> NearbySearch(
            [FromQuery] string location,
            [FromQuery] long? radius,
            [FromQuery] string keyword,
            [FromQuery] string language,
            [FromQuery] string name,
            [FromQuery] string type,
            [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(location))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'location' parameter."
                });

            if (!radius.HasValue)
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'radius' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.NearbySearch(
                location, radius, key, keyword, language, type);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data.results);
        }

        [HttpGet]
        [Route(Program.PLACES_TEXT_SEARCH)]
        public async Task<IActionResult> TextSearch(
         [FromQuery] string query,
         [FromQuery] long radius,
         [FromQuery] string region,
         [FromQuery] string location,
         [FromQuery] string language,
         [FromQuery] string type,
         [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(query))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'query' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.TextSearch(
                query, radius, key, region, location, language, type);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data.results);
        }

        [HttpGet]
        [Route(Program.PLACES_DETAIL)]
        public async Task<IActionResult> PlaceDetail(
           [FromQuery] string place_id,
           [FromQuery] string language,
           [FromQuery] string region,
           [FromQuery] string sessiontoken,
           [FromQuery] string fields,
           [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(place_id))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'place_id' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.PlaceDetail(
                place_id, key, language, region, sessiontoken, fields);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data.result);
        }

        [HttpGet]
        [Route(Program.PLACES_AUTO_COMPLETE)]
        public async Task<IActionResult> PlaceAutocomplete(
            [FromQuery] string input,
            [FromQuery] int? offset,
            [FromQuery] long? radius,
            [FromQuery] string sessiontoken,
            [FromQuery] string origin,
            [FromQuery] string location,
            [FromQuery] string language,
            [FromQuery] string types,
            [FromQuery] string components,
            [FromQuery] string strictbounds,
            [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(input))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'input' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.PlaceAutocomplete(
                input, offset, radius, key, sessiontoken, origin, location, language, types, components, strictbounds);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data.predictions);
        }

        [HttpGet]
        [Route(Program.PLACES_QUERY_AUTO_COMPLETE)]
        public async Task<IActionResult> QueryAutoComplete(
            [FromQuery] string input,
            [FromQuery] int? offset,
            [FromQuery] long? radius,
            [FromQuery] string location,
            [FromQuery] string language,
            [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(input))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'input' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.QueryAutocomplete(
                input, offset, radius, key, location, language);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data.predictions);
        }

        [HttpGet]
        [Route(Program.PLACES_GEOCODE)]
        public async Task<IActionResult> GeoCode(
            [FromQuery] string address,
            [FromQuery] string components,
            [FromQuery] string bounds,
            [FromQuery] string language,
            [FromQuery] string region,
            [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(address))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'address' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var response = await googleMap.Geocoding(
                address, key, components, bounds, language, region);

            if (!string.IsNullOrEmpty(response.Data.error_message)
                || response.Data.status != "OK")
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    code = response.Data.status,
                    message = response.Data.error_message
                });

            return ToResponse(response.Data.results);
        }
    }
}