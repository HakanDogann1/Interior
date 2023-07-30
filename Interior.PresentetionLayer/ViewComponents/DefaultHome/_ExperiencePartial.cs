using Interior.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.ViewComponents.DefaultHome
{
    public class _ExperiencePartial:ViewComponent
    {
        private readonly IExperienceAppService _experienceAppService;

        public _ExperiencePartial(IExperienceAppService experienceAppService)
        {
            _experienceAppService = experienceAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _experienceAppService.GetAllAsync();
            return View(values);
        }
    }
}
