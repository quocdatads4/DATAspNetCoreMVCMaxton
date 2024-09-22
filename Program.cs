using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using DATAspNetCoreMVCMaxton.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure services
builder.Services.AddDbContext<DATAspNetCoreMVCMaxton.Areas.User.Data.ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUserDTO, IdentityRole>()
	.AddEntityFrameworkStores<DATAspNetCoreMVCMaxton.Areas.User.Data.ApplicationDbContext>()
	.AddDefaultTokenProviders();
// Register repositories and services
builder.Services.AddScoped<IProfileGroupRepository, ProfileGroupRepository>();
builder.Services.AddScoped<IProfileGroupService, ProfileGroupService>();
// Register repositories và services
builder.Services.AddScoped<IProfileOrbitasRepository, ProfileOrbitaRepository>();
builder.Services.AddScoped<IProfileOrbitasBLL, ProfileOrbitaService>();

// Register repositories và services
builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

// Register repositories và services
builder.Services.AddScoped<IFacebookAccountRepository, FacebookAccountRepository>();
builder.Services.AddScoped<IFacebookAccountService, FacebookAccountService>();

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
