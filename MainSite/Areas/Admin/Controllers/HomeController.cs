using Microsoft.AspNetCore.Mvc;

namespace MainSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
    }
}
