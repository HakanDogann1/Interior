using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult _HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult _ScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult _SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult _TopbarPartial()
        {
            return PartialView();
        }
    }
}
