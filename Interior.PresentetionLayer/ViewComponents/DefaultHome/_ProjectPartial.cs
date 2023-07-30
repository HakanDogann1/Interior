using Interior.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.ViewComponents.DefaultHome
{
    public class _ProjectPartial:ViewComponent
    {
        private readonly IProjectAppService _projectAppService;

        public _ProjectPartial(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _projectAppService.GetAllAsync();
            return View(values);
        }
    }
}
