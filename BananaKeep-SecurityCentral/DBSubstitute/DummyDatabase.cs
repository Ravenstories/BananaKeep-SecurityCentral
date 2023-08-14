using BananaKeep_SecurityCentral.Models;

namespace BananaKeep_SecurityCentral.DBSubstitute
{
    public class DummyDatabase
    {
        private static List<GPSData> _gpsUnits = new List<GPSData>();

        public static void Initialize()
        {
            _gpsUnits = new List<GPSData>
            {
                new GPSData { Id = 1, Latitude = 37.7749, Longitude = -122.4194, Timestamp = DateTime.Now, Active = true, Altitude = 1500 },
                new GPSData { Id = 2, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.Now.AddHours(-1), Active = true, Altitude = 1500},
                new GPSData { Id = 3, Latitude = 41.8781, Longitude = -87.6298, Timestamp = DateTime.Now.AddHours(-2), Active = true, Altitude = 1500},
                new GPSData { Id = 4, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.Now.AddHours(-3), Active = false, Altitude = 1500},
                new GPSData { Id = 5, Latitude = 29.7604, Longitude = -95.3698, Timestamp = DateTime.Now.AddHours(-4), Active = false, Altitude = 1500},
                // Add more GPS units here
            };
        }
        //return all GPS units
        public static List<GPSData> GetAllGPSUnits()
        {
            return _gpsUnits;
        }
        //return a GPS unit by id
        public static GPSData GetGPSUnitById(int id)
        {
           return _gpsUnits.FirstOrDefault(gpsUnit => gpsUnit.Id == id);
        }
    }
    

}
