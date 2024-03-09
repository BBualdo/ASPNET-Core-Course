using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// builder.Services is IoC Container that provides object of given Interface Type and Service Type
builder.Services.Add(new ServiceDescriptor(
  typeof(ICitiesService),
  typeof(CitiesService),
  ServiceLifetime.Singleton
  ));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
