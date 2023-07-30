using Interior.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Interior.PresentetionLayer.ViewComponents.DefaultService
{
    public class _Service2Partial:ViewComponent
    {
        private readonly IService2AppService _service2AppService;

        public _Service2Partial(IService2AppService service2AppService)
        {
            _service2AppService = service2AppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _service2AppService.GetAllAsync();
            return View(values);
        }
    }
}
