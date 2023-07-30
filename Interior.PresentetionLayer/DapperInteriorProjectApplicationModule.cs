using Autofac;
using Interior.Application.Services.Abstract;
using Interior.Application.Services.Concrete;
using Interior.DomainLayer.Repositories;
using Interior.Infrastructure;

namespace Interior.PresentetionLayer
{
    public class DapperInteriorProjectApplicationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<ContactAppService>().As<IContactAppService>();
        }
    }
}
