using Microsoft.EntityFrameworkCore;
using ParkingControl.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);
var MySQLConnectionString = builder.Configuration.GetConnectionString("MySQLConnectionString");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MySQLContext>
    (options => options.UseMySql(MySQLConnectionString, ServerVersion.AutoDetect(MySQLConnectionString)));

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
