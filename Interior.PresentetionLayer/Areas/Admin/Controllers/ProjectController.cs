using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _projectAppService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            await _projectAppService.AddAsync(project);
            return RedirectToAction("Index","Project");
        }
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectAppService.DeleteAsync(id);
            return RedirectToAction("Index", "Project");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProject(int id)
        {
           var value =  await _projectAppService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProject(int id,Project project)
        {
            await _projectAppService.UpdateAsync(id, project);
            return RedirectToAction("Index", "Project");
        }
    }
}
