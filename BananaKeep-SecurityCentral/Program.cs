using BananaKeep_SecurityCentral.Controllers;
using BananaKeep_SecurityCentral.DBSubstitute;
using BananaKeep_SecurityCentral.HubConfig;
using BananaKeep_SecurityCentral.TimerFeatures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string policyName = "_OpenEndPoints";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();
builder.Services.AddSingleton<TimerManager>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(policyName); // UseCors MUST be before UseAuthorization
app.UseAuthorization();
app.MapControllers(); // Map controllers from GPSController and other controllers

app.MapHub<IncidentHub>("/incident");
app.MapGet("/", () => GPSController.ConnectionLog); // Default route


Main.Initialize();

app.Run();

