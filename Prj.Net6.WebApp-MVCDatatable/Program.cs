using Microsoft.EntityFrameworkCore;
using Prj.Net6.WebApp_MVCDatatable.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// added
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// added
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
