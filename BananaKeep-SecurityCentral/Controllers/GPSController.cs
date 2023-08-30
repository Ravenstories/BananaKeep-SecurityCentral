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
        public static int ConnectionLogNumber = 1;

        VerificationController verificationController = Main.Home.VerificationController;
        TrackingController trackingController = Main.Home.TrackingController;


        [HttpPost("gps-data")]
        public async Task<IActionResult> ReceiveGPSDataAsync()
        {
            try
            {
                // Read the JSON payload from the request body
                string requestBody;
                using (var reader = new StreamReader(Request.Body))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                // This is purely for testing purposes, and is therefore flawed by its lack of thread locking.
                ConnectionLog += "\nRequest #" + ConnectionLogNumber++ + ":\n" + requestBody;

                // Deserialize the JSON data into a GPSData object using Newtonsoft.Json
                GPSUnit gpsData = JsonConvert.DeserializeObject<GPSUnit>(requestBody);


                // Verify the GPS data received and save to database if verified
                if (verificationController.VerifyGPSData(gpsData))
                {
                    trackingController.ProcessGPSData(gpsData);
                    return Ok("Success");
                }

                return BadRequest("Impossible GPSData");
            }
            catch (Exception ex)
            {
                // Handle exceptions and errors
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }
    }
}
