using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData;

var builder = WebApplication.CreateBuilder(args);

// added to setup authentication with cookies to connect to login page
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(opt =>opt.LoginPath = "/Account/Login");

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// setting base path to appsettings.json
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).
    AddJsonFile("appsettings.json");

builder.Services.AddDbContext<TravelExpertsContext>
    (options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("TravelExpertsConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStatusCodePages(); // added for more user-friendly error pages - 404 and 403 errors

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // added for authentication

app.UseAuthorization();

app.UseSession(); // needed to use session state

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TravelExperts}/{action=Index}/{id?}");

app.Run();
