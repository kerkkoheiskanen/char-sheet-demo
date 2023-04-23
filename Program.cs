using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HeroGritSheet.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using BlazorServerApp.DataAccess;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient(); // Register HttpClient without specifying the BaseAddress
builder.Services.AddSingleton<IMongoClient>(s =>
{
    var configuration = s.GetService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("MongoDB");
    return new MongoClient(connectionString);
});
builder.Services.AddScoped<IMongoDatabase>(s =>
{
    var mongoClient = s.GetService<IMongoClient>();
    var configuration = s.GetService<IConfiguration>();
    var databaseName = configuration.GetValue<string>("MongoDB:DatabaseName");
    return mongoClient.GetDatabase(databaseName);
});
builder.Services.AddSingleton<MongoDbService>();

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
