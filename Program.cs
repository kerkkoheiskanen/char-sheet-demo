using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HeroGritSheet.Data.Interfaces;
using HeroGritSheet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using LiteDB;
using LiteDB.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient(); // Register HttpClient without specifying the BaseAddress
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddSingleton<LiteDbContext>();
builder.Services.AddDbContext<LiteDbContext>(options =>
    options.UseLiteDatabase(builder.Configuration.GetConnectionString("LiteDBConnection")));

builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
