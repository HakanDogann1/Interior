using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Controllers
{
    public class DefaultAboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
