using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class OurFieldController : Controller
    {
        private readonly IOurFieldAppService _ourFieldAppService;

        public OurFieldController(IOurFieldAppService ourFieldAppService)
        {
            _ourFieldAppService = ourFieldAppService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _ourFieldAppService.GetAllAsync();
            return View(values);
        }
        public async Task<IActionResult> DeleteOurField(int id)
        {
            await _ourFieldAppService.DeleteAsync(id);
            return RedirectToAction("Index","OurField");
        }
        [HttpGet]
        public IActionResult AddOurField()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOurField(OurField ourField)
        {
            await _ourFieldAppService.AddAsync(ourField);
            return RedirectToAction("Index", "OurField");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOurField(int id)
        {
            var value = await _ourFieldAppService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOurField(int id , OurField ourField)
        {
            await _ourFieldAppService.UpdateAsync(id, ourField);
            return RedirectToAction("Index", "OurField");
        }

    }
}
