using BananaKeep_SecurityCentral.DBSubstitute;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 

var app = builder.Build();
app.MapControllers(); // Map controllers from GPSController and other controllers


//Initialize the database
DummyDatabase.Initialize();

app.Run();