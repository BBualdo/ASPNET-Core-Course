using ConfigExample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Supply an object of WeatherAPIOptions with "WeatherAPI" section as a service
builder.Services.Configure<WeatherAPIOptions>(builder.Configuration.GetSection("WeatherAPI"));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.Run();

// Secrets Manager is created separately in AppData folder on local computer to avoid exposing sensitive data in config files.
// 
// dotnet user-secrets init
// dotnet user-secrets set "KeyName" "KeyValue"
// dotnet user-secrets list
