
using ASP.net_middleware_2;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


//app.Use(HeaderMiddleware.Invoke);

app.Use(async (context, next) => {
    await new HeaderMiddleware().Invoke(context, () => next());
});

//app.Map("/", () =>
//{
//    return View();
//});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello World");
});


//app.Map("/", () =>
//{
//   return View();
//});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();