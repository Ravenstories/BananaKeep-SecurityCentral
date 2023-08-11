var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapControllers(); // Map controllers from GPSController and other controllers

app.Run();