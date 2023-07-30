using Interior.Application.Services.Abstract;
using Interior.DomainLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class TeamController : Controller
    {
        private readonly ITeamAppService _teamAppService;

        public TeamController(ITeamAppService teamAppService)
        {
            _teamAppService = teamAppService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _teamAppService.GetAllAsync();
            return View(values);
        }
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamAppService.DeleteAsync(id);
            return RedirectToAction("Index","Team");
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(Team team)
        {
            await _teamAppService.AddAsync(team);
            return RedirectToAction("Index", "Team");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
           var value = await _teamAppService.GetByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(int id,Team team)
        {
            await _teamAppService.UpdateAsync(id, team);
            return RedirectToAction("Index", "Team");
        }
    }
}
