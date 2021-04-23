using System.Threading.Tasks;
using Core.Libs.Client;
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
        public async Task<IActionResult> Directions(
            [FromQuery] string origin,
            [FromQuery] string destination,
            [FromQuery] string mode,
            [FromQuery] string waypoints,
            [FromQuery] bool alternatives,
            [FromQuery] string avoid,
            [FromQuery] string language,
            [FromQuery] string units,
            [FromQuery] string region)
        {
            var response = await googleMap.Directions(
                origin, destination, waypoints, mode, alternatives, avoid, language, units, region);

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
            [FromQuery] string units)
        {
            var response = await googleMap.DistanceMatrix(
                origins, destinations, mode, language, region, avoid, units);

            return ToResponse(response.Data);
        }

        [HttpGet]
        [Route(Program.PLACES_FIND_PLACE_FROM_TEXT)]
        public async Task<IActionResult> PlaceSearch(
            [FromQuery] string input,
            [FromQuery] string inputtype,
            [FromQuery] string language,
            [FromQuery] string fields,
            [FromQuery] string locationbias)
        {
            var response = await googleMap.PlaceSearch(
                input, inputtype, language, fields, locationbias);

            return ToResponse(response.Data);
        }

        [HttpGet]
        [Route(Program.PLACES_NEARBY_SEARCH)]
        public async Task<IActionResult> NearbySearch(
            [FromQuery] string location,
            [FromQuery] long radius,
            [FromQuery] string keyword,
            [FromQuery] string language,
            [FromQuery] int minprice,
            [FromQuery] int maxprice,
            [FromQuery] string name,
            [FromQuery] string type)
        {
            var response = await googleMap.NearbySearch(
                location, radius, minprice, maxprice, keyword, language, type);

            return ToResponse(response.Data.results);
        }

        [HttpGet]
        [Route(Program.PLACES_TEXT_SEARCH)]
        public async Task<IActionResult> TextSearch(
         [FromQuery] string query,
         [FromQuery] long radius,
         [FromQuery] int minprice,
         [FromQuery] int maxprice,
         [FromQuery] string region,
         [FromQuery] string location,
         [FromQuery] string language,
         [FromQuery] string type)
        {
            var response = await googleMap.TextSearch(
                query, radius, minprice, maxprice, region, location, language, type);

            return ToResponse(response.Data.results);
        }

        [HttpGet]
        [Route(Program.PLACES_DETAIL)]
        public async Task<IActionResult> PlaceDetails(
           [FromQuery] string place_id,
           [FromQuery] string language,
           [FromQuery] string region,
           [FromQuery] string sessiontoken,
           [FromQuery] string fields)
        {
            var response = await googleMap.PlaceDetails(
                place_id, language, region, sessiontoken, fields);

            return ToResponse(response.Data.result);
        }

        [HttpGet]
        [Route(Program.PLACES_AUTO_COMPLETE)]
        public async Task<IActionResult> AutoComplete(
            [FromQuery] string input,
            [FromQuery] int? offset,
            [FromQuery] long? radius,
            [FromQuery] string sessiontoken,
            [FromQuery] string origin,
            [FromQuery] string location,
            [FromQuery] string language,
            [FromQuery] string types,
            [FromQuery] string components,
            [FromQuery] string strictbounds)
        {
            var response = await googleMap.PlaceAutocomplete(
                input, offset, radius, sessiontoken, origin, location, language, types, components, strictbounds);

            return ToResponse(response.Data.predictions);
        }

        [HttpGet]
        [Route(Program.PLACES_QUERY_AUTO_COMPLETE)]
        public async Task<IActionResult> QueryAutoComplete(
            [FromQuery] string input,
            [FromQuery] int? offset,
            [FromQuery] long? radius,
            [FromQuery] string location,
            [FromQuery] string language)
        {
            var response = await googleMap.QueryAutocomplete(
                input, offset, radius, location, language);

            return ToResponse(response.Data.predictions);
        }

        [HttpGet]
        [Route(Program.PLACES_GEOCODE)]
        public async Task<IActionResult> GeoCode(
            [FromQuery] string address,
            [FromQuery] string components,
            [FromQuery] string bounds,
            [FromQuery] string language,
            [FromQuery] string region)
        {
            var response = await googleMap.GetGeocoding(
                address, components, bounds, language, region);

            return ToResponse(response.Data.results);
        }
    }
}
