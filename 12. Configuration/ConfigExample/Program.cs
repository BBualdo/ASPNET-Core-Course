using ConfigExample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Supply an object of WeatherAPIOptions with "WeatherAPI" section as a service
builder.Services.Configure<WeatherAPIOptions>(builder.Configuration.GetSection("WeatherAPI"));

// Load Custom config
builder.Configuration.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.Run();

// Environment Variables have lifetime equal to terminal window lifetime, where that variables has been declared.

// $Env:KeyName__ChildKeyName="Value"
