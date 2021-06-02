using System.Collections.Generic;
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
    public class HamiltonController : BaseController
    {
        private readonly IHamiltonBusiness hamilton;

        public HamiltonController(
            ILogger<HamiltonController> logger,
            IHamiltonBusiness hamilton) : base(logger)
        {
            this.hamilton = hamilton;
        }

        [HttpGet]
        [Route(Program.FIND_HAMILTON)]
        public async Task<IActionResult> Hamilton(
            [FromQuery] string locations,
            [FromQuery] long? range,
            [FromQuery] string key)
        {
            if (string.IsNullOrEmpty(locations))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'locations' parameter."
                });

            if (!range.HasValue)
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'range' parameter."
                });

            if (string.IsNullOrEmpty(key))
                return ToResponse(string.Empty, new ErrorJsonModel
                {
                    message = "Invalid request. Missing the 'key' parameter."
                });

            var arrayLocations = locations.Split("|");

            var input = new List<string>();

            foreach (var location in arrayLocations)
                if (!string.IsNullOrEmpty(location))
                    input.Add(location.Trim());

            if (input.Count <= 1)
                return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    message = "Invalid request. The 'locations' parameter must be more than 2 location.",
                    code = "404",
                });

            var response = await hamilton.Check(input, range.Value, key);

            if (response != null && response.Count > 0)
                return ToResponse(response);
            return ToResponse(string.Empty,
                new ErrorJsonModel()
                {
                    message = "Not Found",
                    code = "404",
                });
        }
    }
}