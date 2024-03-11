var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
  endpoints.Map("/", async context =>
  {
    string? directly = app.Configuration["MyKey"];
    string? value = app.Configuration.GetValue<string>("MyKey");
    int withDefault = app.Configuration.GetValue<int>("x", 10);

    await context.Response.WriteAsync($"{directly}\n");
    await context.Response.WriteAsync($"{value}\n");
    await context.Response.WriteAsync($"{withDefault}\n");
  });
});
#pragma warning restore ASP0014

app.MapControllers();

app.Run();
