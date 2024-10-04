////// https://localhost:7257/Index?name=Tomato&price=41



/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//--.
app.MapGet("/", () => "Hello World!");

//--.
app.Run();
*/



using Ex06_CallingMetodThroughService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//--.
builder.Services.AddSingleton<OperationPrice>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
