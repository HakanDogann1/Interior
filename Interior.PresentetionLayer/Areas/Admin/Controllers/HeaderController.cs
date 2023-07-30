using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HeaderController : Controller
    {
        private readonly IHeaderAppService _headerAppService;

        public HeaderController(IHeaderAppService headerAppService)
        {
            _headerAppService = headerAppService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _headerAppService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddHeader()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHeader(Header header)
        {
            await _headerAppService.AddAsync(header);
            return RedirectToAction("Index","Header");
        }
        public async Task<IActionResult> DeleteHeader(int id)
        {
            await _headerAppService.DeleteAsync(id);
            return RedirectToAction("Index", "Header");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateHeader(int id)
        {
            var value = await _headerAppService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHeader(int id,Header header)
        {
            await _headerAppService.UpdateAsync(id, header);
            return RedirectToAction("Index", "Header");
        }
    }
}
