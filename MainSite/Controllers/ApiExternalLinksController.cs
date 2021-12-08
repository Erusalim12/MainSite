using Application.Services.ExternalLinks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MainSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiExternalLinksController : ControllerBase
    {
        private readonly IExternalLinkService _externalLinkService;

        public ApiExternalLinksController(IExternalLinkService externalLinkService)
        {
            _externalLinkService = externalLinkService;
        }

        [Route("links")]
        [HttpGet]
        public JsonResult GetExternalLinks()
        {
            var model = _externalLinkService.GetAll().OrderByDescending(a => a.Order);
            return new JsonResult(model);
        }
    }
}
