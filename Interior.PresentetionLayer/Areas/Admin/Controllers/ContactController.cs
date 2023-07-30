using Interior.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
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
