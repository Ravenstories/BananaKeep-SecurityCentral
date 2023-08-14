using BananaKeep_SecurityCentral.Controllers;
using BananaKeep_SecurityCentral.DBSubstitute;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 

var app = builder.Build();
app.MapControllers(); // Map controllers from GPSController and other controllers


//Initialize the database
DummyDatabase.Initialize();



//Rewrite console.writeline to log to file

var logFilePath = "console.log"; // Path to the log file
var logFileStream = new FileStream(logFilePath, FileMode.Append);
var logStreamWriter = new StreamWriter(logFileStream) { AutoFlush = true };

Console.SetOut(logStreamWriter);

app.Run();


Console.WriteLine("Hello World!");
Console.WriteLine("Testing MVC LogView");
