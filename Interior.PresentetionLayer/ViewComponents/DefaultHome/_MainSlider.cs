using Interior.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.ViewComponents.DefaultHome
{
    public class _MainSlider:ViewComponent
    {
        private readonly IHeaderAppService _headerAppService;

        public _MainSlider(IHeaderAppService headerAppService)
        {
            _headerAppService = headerAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _headerAppService.GetAllAsync();
            return View(values);
        }
    }
}
