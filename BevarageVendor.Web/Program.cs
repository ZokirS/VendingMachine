using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service;
using Service.Contracts;
using Repository.Configuration;
using Microsoft.AspNetCore.Identity;
using Entities.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICoinRepository, CoinRepository>();
builder.Services.AddScoped<IBeverageRepository, BeverageRepository>();
builder.Services.AddScoped<ICoinService, CoinService>();
builder.Services.AddScoped<IBeverageService, BeverageService>();
builder.Services.AddDbContextPool<RepositoryContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.AddIdentity<User, IdentityRole>(o =>
{
    o.Password.RequiredLength = 10;
}).AddEntityFrameworkStores<RepositoryContext>();
builder.Services.AddAutoMapper(typeof(Program));
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
