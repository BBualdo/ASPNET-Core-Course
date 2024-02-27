var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // adds all controller classes as services
var app = builder.Build();

// app.UseRouting();
// app.UseEndpoints(endpoints => endpoints.MapControllers());

// you can shortcut it with:

app.MapControllers();
app.UseStaticFiles();

app.Run();
