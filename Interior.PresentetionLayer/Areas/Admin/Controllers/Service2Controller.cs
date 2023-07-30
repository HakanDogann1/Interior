using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class Service2Controller : Controller
    {
        private readonly IService2AppService _service2AppService;

        public Service2Controller(IService2AppService service2AppService)
        {
            _service2AppService = service2AppService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _service2AppService.GetAllAsync();
            return View(values);
        }
        public async Task<IActionResult> DeleteService2(int id)
        {
            await _service2AppService.DeleteAsync(id);
            return RedirectToAction("Index","Service2");
        }
        [HttpGet]
        public IActionResult AddService2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService2(Service2 service2)
        {
            await _service2AppService.AddAsync(service2);
            return RedirectToAction("Index", "Service2");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService2(int id)
        {
            var value = await _service2AppService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService2(int id,Service2 service2)
        {
           
            await _service2AppService.UpdateAsync(id,service2);
            return RedirectToAction("Index", "Service2");
        }
    }
}
