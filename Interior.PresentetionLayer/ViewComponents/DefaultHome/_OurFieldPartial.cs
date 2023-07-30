using Interior.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.ViewComponents.DefaultHome
{
    public class _OurFieldPartial:ViewComponent
    {
        private readonly IOurFieldAppService _ourFieldAppService;

        public _OurFieldPartial(IOurFieldAppService ourFieldAppService)
        {
            _ourFieldAppService = ourFieldAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _ourFieldAppService.GetAllAsync();
            return View(values);
        }
    }
}
