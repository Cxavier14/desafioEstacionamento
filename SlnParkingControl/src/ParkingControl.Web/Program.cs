using Microsoft.EntityFrameworkCore;
using ParkingControl.Application.Service.IServices;
using ParkingControl.Application.Service.Services;
using ParkingControl.Infra.Data.Context;
using ParkingControl.Infra.Data.IRepositories;
using ParkingControl.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var MySQLConnectionString = builder.Configuration.GetConnectionString("MySQLConnectionString");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context
builder.Services.AddDbContext<MySQLContext>
    (options => options.UseMySql(MySQLConnectionString, ServerVersion.AutoDetect(MySQLConnectionString)));

// # Dependency Injections #
// # Repositories #
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<ITarifaRepository, TarifaRepository>();

// # Services #
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<ITarifaService, TarifaService>();

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
