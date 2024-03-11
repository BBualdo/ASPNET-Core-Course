var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

/* In other place than IDE launchsetting.json doesnt exist, so in terminal to set Environment you have to write:
  $Env:ASPNETCORE_ENVIRONMENT="Environment_Name"
*/

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
