using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

//--. adds to the collection of services the services that are necessary
//      for the operation of MVC controllers
builder.Services.AddControllersWithViews();

var app = builder.Build();

//--.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
