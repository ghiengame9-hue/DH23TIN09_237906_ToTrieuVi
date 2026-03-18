using CodeQLTour.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TourContext>(options =>
    options.UseSqlite("Data Source=qltour.db");

// THÊM DÒNG NÀY
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

// THÊM DÒNG NÀY
app.UseSession();

app.UseAuthorization();
app.MapGet("/", () => Results.Redirect("/Tour/Index"));
app.MapControllerRoute(
    name: "default",
   pattern: "{controller=Tour}/{action=Index}/{id?}");

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");
