var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Welcome in the BestBank!");

app.Run();
