using MiddlewareExample.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();

//// Recommended Middleware Order
//app.UseExceptionHandler("/Error");
//app.UseHsts();
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseCors();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseSession();
//app.MapControllers();
//// add custom middlewares

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("Middleware 1 - Start\n");
  await next(context);
  await context.Response.WriteAsync("Middleware 1 - Stop\n");
});

// middleware 2
//app.UseMiddleware<CustomMiddleware>();
app.UseCustomMiddleware();

app.UseWhen((HttpContext context) => context.Request.Query.ContainsKey("username"),
  (IApplicationBuilder app) =>
  {
    app.Use(async (context, next) =>
    {
      string? username = context.Request.Query["username"];
      await context.Response.WriteAsync($"Your username is: {username}\n");
      await next();
    });
  });

// middleware 3
app.UseGreetingCustomMiddleware();

// middleware 4 (terminating middleware)
app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("Middleware 3 - Start\n");
  await context.Response.WriteAsync("Middleware 3 - Stop\n");
});

app.Run();