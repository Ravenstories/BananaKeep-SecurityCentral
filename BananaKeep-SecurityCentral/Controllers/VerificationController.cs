using BananaKeep_SecurityCentral.DBSubstitute;
using BananaKeep_SecurityCentral.Models;


namespace BananaKeep_SecurityCentral.Controllers
{
    public class VerificationController
    {
        private DatabaseHandler databaseHandler;

        public VerificationController(DatabaseHandler _databaseHandler)
        {
            this.databaseHandler = _databaseHandler;
        }

        public bool VerifyGPSData(GPSUnit gpsData)
        {
            // Validate GPS data received
            if (gpsData == null || gpsData.Latitude < -90 || gpsData.Latitude > 90 ||
                               gpsData.Longitude < -180 || gpsData.Longitude > 180)
            {
                throw new Exception("Invalid GPS data");
            }

            //Use DatabaseHandler to fetch all GPSUnits
            GPSUnit gpsUnit = databaseHandler.GetSingleGPSUnitData(gpsData.ID);
            Console.WriteLine("GPSUnits: " + gpsUnit.Name);

            // Check if GPS unit is active
            if (!gpsUnit.Active)
            {
                Console.WriteLine("GPS unit is not active");
            }else
            {
                Console.WriteLine("GPS unit is active");
                databaseHandler.SaveGPSData(gpsData);
            }
            return gpsUnit.Active;
        }
    }
}
