using BananaKeep_SecurityCentral.Models;

namespace BananaKeep_SecurityCentral.DBSubstitute
{
    public class DummyDatabase
    {
        private static List<User> _users = new List<User>();
        private static List<GPSUnit> _gpsUnits = new List<GPSUnit>();
        private static List<Depository> _depositories = new List<Depository>();
        private static List<ToolBoxGPSUnit> _toolBoxGPSUnits = new List<ToolBoxGPSUnit>();


        public static void Initialize()
        {
            _users = new List<User>
            {
                new User {ID = 1, CompanyCVR = 12345678, Email="torben@torbentools.com", FullName = "Torben Toolesen", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 6969 6969"},
                new User {ID = 2, CompanyCVR = 12345678, Email="svend@torbentools.com", FullName = "Svend Toolesen", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 6969 6969"},
                new User {ID = 3, CompanyCVR = 87654321, Email="albert@monkeybusiness.com", FullName = "Albert II", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 0420 1337"},
                new User {ID = 4, CompanyCVR = 12345678, Email="joergen@torbentools.com", FullName = "Jørgen Toolesen", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 6969 6969"},
                new User {ID = 5, CompanyCVR = 87654321, Email="chad@monkeybusiness.com", FullName = "Chad Monkey", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 0420 6969"}
            };


            _gpsUnits = new List<GPSUnit>
            {
                new GPSUnit { ID = 1, Latitude = 37.7749, Longitude = -122.4194, Timestamp = DateTime.Now, Active = true, Altitude = 1500 },
                new GPSUnit { ID = 2, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.Now.AddHours(-1), Active = true, Altitude = 1500},
                new GPSUnit { ID = 3, Latitude = 41.8781, Longitude = -87.6298, Timestamp = DateTime.Now.AddHours(-2), Active = true, Altitude = 1500},
                new GPSUnit { ID = 4, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.Now.AddHours(-3), Active = false, Altitude = 1500},
                new GPSUnit { ID = 5, Latitude = 29.7604, Longitude = -95.3698, Timestamp = DateTime.Now.AddHours(-4), Active = false, Altitude = 1500},
                // Add more GPS units here
            };

            Console.WriteLine(_gpsUnits.Count + " GPS units added to the database.");
        }
        //return all GPS units
        public static List<GPSUnit> GetAllGPSUnits()
        {
            return _gpsUnits;
        }
        //return a GPS unit by id
        public static GPSUnit GetGPSUnitById(int id)
        {
           return _gpsUnits.FirstOrDefault(gpsUnit => gpsUnit.ID == id);
        }
        //save GPS data
        public static void SaveGPSData(GPSUnit gpsData)
        {
            //Check if id exists
            var gpsUnit = GetGPSUnitById(gpsData.ID);
            if (gpsUnit == null)
            {
                throw new Exception("GPS unit does not exist");
            }
            else
            {
                //Add GPS data to GPS unit list
                try
                {
                    _gpsUnits.Remove(gpsUnit);
                    _gpsUnits.Add(gpsData);
                    Console.WriteLine("GPS data saved.");
                    
                }
                catch { Console.WriteLine("Couldn't save new gps data for: ", gpsUnit.ID); }
            }

        }
    }


}
