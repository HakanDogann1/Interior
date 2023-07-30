using Interior.Application.Services.Abstract;
using Interior.Application.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactAppService _contactAppService;
          public ContactController(IContactAppService contactAppService)
        {
            _contactAppService = contactAppService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactAppService.GetAllAsync();
            return View(values);
        }
    }
}
