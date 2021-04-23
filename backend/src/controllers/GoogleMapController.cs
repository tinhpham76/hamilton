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
    }
}
