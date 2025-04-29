using Microsoft.AspNetCore.Mvc;

namespace NIHComicViewerWeb.Controllers
{
    public class ComicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
