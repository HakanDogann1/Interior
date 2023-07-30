using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ServiceController : Controller
    {
        private readonly IServiceAppService _serviceAppService;

        public ServiceController(IServiceAppService serviceAppService)
        {
            _serviceAppService = serviceAppService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _serviceAppService.GetAllAsync();
            return View(values);
        }
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceAppService.DeleteAsync(id);
            return RedirectToAction("Index","Service");
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(Service service)
        {
            await _serviceAppService.AddAsync(service);
            return RedirectToAction("Index", "Service");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _serviceAppService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(int id,Service service)
        {
            await _serviceAppService.UpdateAsync(id, service);
            return RedirectToAction("Index", "Service");
        }
    }
}
