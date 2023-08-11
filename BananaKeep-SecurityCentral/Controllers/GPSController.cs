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
                // Validate GPS data received
                if (gpsData == null || gpsData.Latitude < -90 || gpsData.Latitude > 90 ||
                    gpsData.Longitude < -180 || gpsData.Longitude > 180)
                {
                    return BadRequest("Invalid GPS data");
                }

                // ADD CODE HERE TO GO TO VERIFICATION CONTROLLER

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
