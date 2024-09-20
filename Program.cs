using DATAspNetCoreMVCMaxton.BusinessLogic;
using DATAspNetCoreMVCMaxton.DataAccess;
using DATAspNetCoreMVCMaxton.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUserModel, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();
// Register repositories and services
builder.Services.AddScoped<IProfileGroupRepository, ProfileGroupRepository>();
builder.Services.AddScoped<IProfileGroupService, ProfileGroupService>();
// Register repositories và services
builder.Services.AddScoped<IProfileOrbitaRepository, ProfileOrbitaRepository>();
builder.Services.AddScoped<IProfileOrbitaService, ProfileOrbitaService>();


var app = builder.Build();

builder.Services.AddEndpointsApiExplorer();

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

// Routing configuration
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Admin" });

app.MapControllerRoute(
    name: "user",
    pattern: "User/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "User" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
