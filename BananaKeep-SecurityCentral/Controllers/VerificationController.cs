﻿using BananaKeep_SecurityCentral.DBSubstitute;
using BananaKeep_SecurityCentral.Models;


namespace BananaKeep_SecurityCentral.Controllers
{
    public class VerificationController
    {
        public VerificationController()
        {

        }

        public void VerifyGPSData(GPSData gpsData)
        {
            // Validate GPS data received
            if (gpsData == null || gpsData.Latitude < -90 || gpsData.Latitude > 90 ||
                               gpsData.Longitude < -180 || gpsData.Longitude > 180)
            {
                throw new Exception("Invalid GPS data");
            }

            //Use DatabaseHandler to fetch all GPSUnits
            var databaseHandler = new DatabaseHandler();
            //Get all GPSUnits from DatabaseHandler (DummyDatabase) - Redundant
            //var gpsUnits = databaseHandler.GetAllGPSUnitData();
            //Get single GPSUnit from DatabaseHandler (DummyDatabase)
            
            var gpsUnit = databaseHandler.GetSingleGPSUnitData(gpsData.Id);


            Console.WriteLine("GPSUnits: " + gpsUnit);

            // Check if GPS unit is active
            //Do we save the location if inactive?
            if (!gpsUnit.Active)
            {
                Console.WriteLine("GPS unit is not active");
            }else
            {
                Console.WriteLine("GPS unit is active");
            }
        }
    }
}
