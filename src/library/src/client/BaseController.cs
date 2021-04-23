using Core.Libs.Client.Models.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core.Libs.Client
{
    public abstract class BaseController : Controller
    {
        protected readonly ILogger log;

        public BaseController(
            ILogger log)
        {
            this.log = log;
        }

        protected IActionResult ToResponse<T>(T data, ErrorJsonModel error = null) where T : class
        {
            var model = new ResponseJsonModel<T>();

            if (error != null)
                model.error = error;
            else
                model.data = data;

            return Json(model);
        }

        protected IActionResult Html(string content)
        {
            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }

        protected IActionResult JavaScript(string content)
        {
            return new ContentResult()
            {
                Content = content,
                ContentType = "application/javascript",
            };
        }
    }
}