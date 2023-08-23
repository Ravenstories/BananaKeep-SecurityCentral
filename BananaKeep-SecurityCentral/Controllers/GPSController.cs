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

                // This is purely for testing purposes, and is therefore flawed by its lack of thread locking.
                ConnectionLog += "\nRequest #" + ConnectionLogNumber++ + ":\n" + requestBody;

                // Deserialize the JSON data into a GPSData object using Newtonsoft.Json
                GPSUnit gpsData = JsonConvert.DeserializeObject<GPSUnit>(requestBody);

                
                // Verify the GPS data received and save to database if verified
                var verificationController = new VerificationController();
                if (verificationController.VerifyGPSData(gpsData))
                {
                    // Check if there is an incident with this unit
                    TrackingController trackingController = new TrackingController();
                    if (trackingController.HasUnitCurrentIncident(gpsData))
                    {
                        // As there is currently an incident, we must log this datapoint
                        IncidentLog log = new IncidentLog();
                    } 
                    else
                    {
                        // If not, then find out what Kind it is.


                        // IF it does not have an incident, and is a toolbox gps unit... We must check its relative position to its Depository.
                        trackingController.TrackToolBoxGPSUnit();
                    }
                }

                return Ok(200);
            }
            catch (Exception ex)
            {
                // Handle exceptions and errors
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }
    }
}
