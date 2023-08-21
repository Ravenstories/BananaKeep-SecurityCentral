using System;
using BananaKeep_SecurityCentral.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BananaKeep_SecurityCentral.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    // This controller is used to receive GPS data
    public class GPSController : ControllerBase
    {
        public static string ConnectionLog = "IT WORKS :)))\n";

        [HttpPost("gps-data")]
        public async Task<IActionResult> ReceiveGPSDataAsync()
        {
            try
            {
                // Read the JSON payload from the request body
                string requestBody = string.Empty;
                using (var reader = new StreamReader(Request.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                ConnectionLog += "\nNew Request:\n" + requestBody;

                // Deserialize the JSON data into a GPSData object using Newtonsoft.Json
                GPSUnit gpsData = JsonConvert.DeserializeObject<GPSUnit>(requestBody);

                Console.WriteLine("GPSData: " + gpsData.ToString());
                
                // Verify the GPS data received
                var verificationController = new VerificationController();
                verificationController.VerifyGPSData(gpsData);

                TrackingController.TrackGPSData();

                return Ok(200);
            }
            catch (Exception ex)
            {
                // Handle exceptions and errors
                return StatusCode(500, "An error occurred");
            }
        }
    }
}
