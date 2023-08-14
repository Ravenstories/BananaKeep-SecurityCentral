using Microsoft.AspNetCore.Mvc;

namespace BananaKeep_SecurityCentral.Controllers
{
    public class LogController : Controller
    {
        public IActionResult LogView()
        {
            var logFilePath = "console.log"; // Path to the log file
            if (System.IO.File.Exists(logFilePath))
            {
                var logContent = System.IO.File.ReadAllText(logFilePath);
                return Content(logContent, "text/plain"); // Return log content as plain text
            }
            return Content("Log file not found.", "text/plain");
        }

        public IActionResult ShowLog()
        {
            return RedirectToAction("LogView", "Log");
        }
    }
}
