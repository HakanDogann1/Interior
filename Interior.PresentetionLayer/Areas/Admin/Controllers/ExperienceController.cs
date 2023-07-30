using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceAppService _experienceAppService;

        public ExperienceController(IExperienceAppService experienceAppService)
        {
            _experienceAppService = experienceAppService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _experienceAppService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddExperience(Experience experience)
        {
            await _experienceAppService.AddAsync(experience);
            return RedirectToAction("Index","Experience");
        }
        public async Task<IActionResult> DeleteExperience(int id)
        {
            await _experienceAppService.DeleteAsync(id);
            return RedirectToAction("Index", "Experience");

        }
        [HttpGet]
        public async Task<IActionResult> UpdateExperience(int id)
        {
            var value =await _experienceAppService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExperience(int id,Experience experience)
        {
            await _experienceAppService.UpdateAsync(id,experience);
            return RedirectToAction("Index", "Experience");
        }
    }
}
