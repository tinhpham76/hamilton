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
        public async Task<IActionResult> Hamilton([FromQuery] string locations, [FromQuery] long range)
        {
            var arrayLocations = locations.Split("|");

            var input = new List<string>();

            foreach (var location in arrayLocations)
                input.Add(location.Trim());

            var response = await hamilton.Check(input, range);

            if (response != null && response.Count > 0)
                return ToResponse(response);
            return ToResponse(
                response,
                new ErrorJsonModel()
                {
                    message = "Không tìm thấy đường đi Hamilton.",
                    code = "404",
                });
        }
    }
}
