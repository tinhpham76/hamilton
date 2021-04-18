using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Libs.Client;
using Core.Libs.Integration.GoogleMap;
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
        [Route("findhamiltonfromaddressname")]
        public async Task<IActionResult> Hamilton([FromQuery] string locations, [FromQuery] long range)
        {
            var arrayLocations = locations.Split("|");

            var input = new List<string>();

            foreach (var location in arrayLocations)
                input.Add(location);

            var response = await hamilton.Check(input, range);

            if (response != null && response.Count > 0)
                return ToResponse(response);
            return ToResponse(
                response,
                new Core.Libs.Client.Models.Json.ErrorJsonModel()
                {
                    message = "Không tìm thấy đường đi Hamilton.",
                    code = "404",
                });
        }
    }
}
