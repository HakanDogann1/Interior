using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Controllers
{
    public class DefaultContactController : Controller
    {
        private readonly IContactAppService _contactAppService;

        public DefaultContactController(IContactAppService contactAppService)
        {
            _contactAppService = contactAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddContact()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            await _contactAppService.AddAsync(contact);
            return RedirectToAction("Index","DefaultContact");
        }
    }
}
