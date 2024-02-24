using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
  WebRootPath = "myroot" // Changing wwwroot folder to own
});
var app = builder.Build();

app.UseStaticFiles();

// adding more than one root folder
app.UseStaticFiles(new StaticFileOptions()
{
  FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "myroot2"))
});

app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
  endpoints.Map("/", async context =>
  {
    await context.Response.WriteAsync("Hello, Static Files.");
  });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();
