using Application.Services.ExternalLinks;
using Microsoft.AspNetCore.Mvc;

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
        public JsonResult GetExternalLinks()
        {
            var model = _externalLinkService.GetAll();
            return new JsonResult(model);
        }
    }
}
