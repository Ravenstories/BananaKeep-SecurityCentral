using BananaKeep_SecurityCentral.Controllers;
using BananaKeep_SecurityCentral.DBSubstitute;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 

var app = builder.Build();
app.MapControllers(); // Map controllers from GPSController and other controllers

//Initialize the database
DummyDatabase.Initialize();

app.MapGet("/", () => "SYSTEM IS RUNNING"); // Default route

app.Run();
