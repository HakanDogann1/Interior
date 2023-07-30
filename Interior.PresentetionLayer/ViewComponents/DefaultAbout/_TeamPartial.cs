using Interior.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.ViewComponents.DefaultAbout
{
    public class _TeamPartial:ViewComponent
    {
        private readonly ITeamAppService _teamAppService;

        public _TeamPartial(ITeamAppService teamAppService)
        {
            _teamAppService = teamAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _teamAppService.GetAllAsync();
            return View(values);
        }
    }
}
