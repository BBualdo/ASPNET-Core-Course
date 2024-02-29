var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Have to add this bc in ASP.NET Core only JSON Input Formatter is enabled
builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
