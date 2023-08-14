using System;
using BananaKeep_SecurityCentral.Models;
using Microsoft.AspNetCore.Mvc;

namespace BananaKeep_SecurityCentral.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    // This controller is used to receive GPS data
    public class GPSController : ControllerBase
    {
        [HttpPost("gps-data")]
        public IActionResult ReceiveGPSData(GPSData gpsData)
        {
            try
            {
                //Log the GPS data received
                Console.WriteLine("GPS data received: " + gpsData);

                // Verify the GPS data received
                var verificationController = new VerificationController();
                verificationController.VerifyGPSData(gpsData);


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
