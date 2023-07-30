using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Controllers
{
    public class DefaultHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
