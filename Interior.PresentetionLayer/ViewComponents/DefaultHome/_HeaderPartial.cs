using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.ViewComponents.DefaultHome
{
    public class _HeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
