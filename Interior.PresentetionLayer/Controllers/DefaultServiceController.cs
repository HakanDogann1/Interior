using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Controllers
{
    public class DefaultServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
