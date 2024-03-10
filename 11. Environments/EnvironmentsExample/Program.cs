var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

if (
  app.Environment.IsDevelopment() || // Environment = "Development"
  app.Environment.IsStaging() || // Environment = "Staging"
  app.Environment.IsEnvironment("Beta") // Environment = "Beta" (Custom Env)
  )
{
  app.UseDeveloperExceptionPage(); // Showing detailed exception page for all env's except Production
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
