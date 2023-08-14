using BananaKeep_SecurityCentral.Controllers;
using BananaKeep_SecurityCentral.DBSubstitute;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 

var app = builder.Build();
app.MapControllers(); // Map controllers from GPSController and other controllers


//Initialize the database
DummyDatabase.Initialize();



//Rewrite console.writeline to log to file

var logFilePath = "Logs/console.log"; // Path to the log file
var logFileStream = new FileStream(logFilePath, FileMode.Append);
var logStreamWriter = new StreamWriter(logFileStream) { AutoFlush = true };

Console.SetOut(logStreamWriter);


app.Run();

// Set startpage to LogView

app.MapGet("/", () =>
{
    using var scope = app.Services.CreateScope();
    var serviceProvider = scope.ServiceProvider;
    var logController = serviceProvider.GetRequiredService<LogController>();
    return logController.LogView();
});

while (true)
{
    Console.WriteLine("Hello World!");
    Thread.Sleep(5000);
}
