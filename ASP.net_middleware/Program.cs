var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("CUSTOM-HEADER", "CUSTOM VALUE");
    await next();
});

app.Map("/", async (context) => {
    string text = "";
    foreach (var t in context.Response.Headers)
        text += $"{t}\n";
    await context.Response.WriteAsync(text);
    //context.Response.Headers.Add("CUSTOM-HEADER", "CUSTOM VALUE");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();