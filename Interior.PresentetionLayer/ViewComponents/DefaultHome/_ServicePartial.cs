using Interior.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.ViewComponents.DefaultHome
{
    public class _ServicePartial:ViewComponent
    {
        private readonly IServiceAppService _serviceAppService;

        public _ServicePartial(IServiceAppService serviceAppService)
        {
            _serviceAppService = serviceAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _serviceAppService.GetAllAsync();
            return View(values);
        }
    }
}
