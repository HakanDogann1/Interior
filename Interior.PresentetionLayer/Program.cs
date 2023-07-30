using Autofac.Extensions.DependencyInjection;
using Autofac;
using Interior.PresentetionLayer;
using Interior.Application.Services.Abstract;
using Interior.Application.Services.Concrete;
using Interior.DomainLayer.Repositories;
using Interior.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IContactAppService, ContactAppService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IExperienceAppService, ExperienceAppService>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();

builder.Services.AddScoped<IHeaderAppService, HeaderAppService>();
builder.Services.AddScoped<IHeaderRepository, HeaderRepository>();

builder.Services.AddScoped<IOurFieldAppService,OurFieldAppService>();
builder.Services.AddScoped<IOurFieldRepository, OurFieldRepository>();

builder.Services.AddScoped<IProjectAppService, ProjectAppService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IService2AppService, Service2AppService>();
builder.Services.AddScoped<IService2Repository, Service2Repository>();

builder.Services.AddScoped<IServiceAppService, ServiceAppService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

builder.Services.AddScoped<ITeamAppService, TeamAppService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
//    .ConfigureContainer<ContainerBuilder>(builder =>
//    {
//        builder.RegisterModule(new DapperInteriorProjectApplicationModule());
//    });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
