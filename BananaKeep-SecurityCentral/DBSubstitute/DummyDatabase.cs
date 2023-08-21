using BananaKeep_SecurityCentral.Models;

namespace BananaKeep_SecurityCentral.DBSubstitute
{
    public class DummyDatabase
    {
        private static List<User> _users;
        private static List<GPSUnit> _gpsUnits;
        private static List<Depository> _depositories;
        private static List<ToolBoxGPSUnit> _toolBoxGPSUnits;
        private static List<Incident> _incidents;


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
                new GPSUnit { ID = 1, Name="Torben's Tobenet Venstrehånds Undergrebet Bøje Sav", Latitude = 37.7749, Longitude = -122.4194, Timestamp = DateTime.Now, Active = true, Altitude = 1500 }, // Tool D1
                new GPSUnit { ID = 2, Name="Torben's Torbulator", Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.Now.AddHours(-1), Active = true, Altitude = 1500}, // tool D1
                new GPSUnit { ID = 3, Name="Torben's Vogn", Latitude = 41.8781, Longitude = -87.6298, Timestamp = DateTime.Now.AddHours(-2), Active = true, Altitude = 1500}, // Depository 1 - Torben Tools
                new GPSUnit { ID = 4, Name="Torben's Boremaskine", Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.Now.AddHours(-3), Active = false, Altitude = 1500}, // tool D1
                new GPSUnit { ID = 5, Name="Svend's Automassager", Latitude = 29.7604, Longitude = -95.3698, Timestamp = DateTime.Now.AddHours(-4), Active = false, Altitude = 1500}, // tool D2
                new GPSUnit { ID = 6, Name="Svend's Svensknøgle", Latitude = 39.7604, Longitude = -85.3698, Timestamp = DateTime.Now.AddMinutes(-4), Active = true, Altitude = 1500}, // tool D2
                new GPSUnit { ID = 7, Name="Svend's Vogn", Latitude = 49.7604, Longitude = -75.3698, Timestamp = DateTime.Now.AddSeconds(-4), Active = true, Altitude = 1500}, // Depository 2 - Torben Tools
                new GPSUnit { ID = 8, Name="Banana Fleet Vehicle 1", Latitude = 59.7604, Longitude = -65.3698, Timestamp = DateTime.Now.AddDays(-1), Active = true, Altitude = 1500}, // Depository 3 - Monkey Business
                new GPSUnit { ID = 9, Name="Monkey Stick Box", Latitude = 69.7604, Longitude = -55.3698, Timestamp = DateTime.Now.AddYears(-1), Active = true, Altitude = 1500}, // tool D3
                
                // Add more GPS units here
            };

            _toolBoxGPSUnits = new List<ToolBoxGPSUnit>
            {
                new ToolBoxGPSUnit { GPSUnit = _gpsUnits[0], DepositoryGPSUnitID = 3 },
                new ToolBoxGPSUnit { GPSUnit = _gpsUnits[1], DepositoryGPSUnitID = 3 },
                new ToolBoxGPSUnit { GPSUnit = _gpsUnits[3], DepositoryGPSUnitID = 3 },
                new ToolBoxGPSUnit { GPSUnit = _gpsUnits[4], DepositoryGPSUnitID = 7 },
                new ToolBoxGPSUnit { GPSUnit = _gpsUnits[5], DepositoryGPSUnitID = 7 },
                new ToolBoxGPSUnit { GPSUnit = _gpsUnits[8], DepositoryGPSUnitID = 8 }
            };

            _depositories = new List<Depository>
            {
                new Depository
                {
                    GPSUnit = _gpsUnits[2], IncidentTriggerRadiusMeters=200, LicensePlate="1234-ABC",
                    ToolBoxGPSUnits = new List<ToolBoxGPSUnit>
                    {
                        _toolBoxGPSUnits[0],
                        _toolBoxGPSUnits[1]
                    },
                    User = _users[0]
                },
                new Depository
                {
                    GPSUnit = _gpsUnits[6], IncidentTriggerRadiusMeters=200, LicensePlate="1234-ABC",
                    ToolBoxGPSUnits = new List<ToolBoxGPSUnit>
                    {
                        _toolBoxGPSUnits[2],
                        _toolBoxGPSUnits[3]
                    },
                    User = _users[1]
                },
                new Depository
                {
                    GPSUnit = _gpsUnits[7], IncidentTriggerRadiusMeters=200, LicensePlate="1234-ABC",
                    ToolBoxGPSUnits = new List<ToolBoxGPSUnit>
                    {
                        _toolBoxGPSUnits[4]
                    },
                    User = _users[2]
                }
            };

            _incidents = new List<Incident>
            {
                new Incident {
                    ID=1, Dismissed=false, GPSUnit=_gpsUnits[0], TriggeredTimestamp=DateTime.Now.AddMinutes(-24942), Logs = new List<IncidentLog>
                    {
                        new IncidentLog { IncidentID=1, Longitude=60, Latitude=60, Altitude= 1500, Timestamp= DateTime.Now },
                        new IncidentLog { IncidentID=1, Longitude=61, Latitude=59, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-5) },
                        new IncidentLog { IncidentID=1, Longitude=62, Latitude=58, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-10) },
                    }
                },
                new Incident {
                    ID=2, Dismissed=false, GPSUnit=_gpsUnits[5], TriggeredTimestamp=DateTime.Now.AddMinutes(-24942), Logs = new List<IncidentLog>
                    {
                        new IncidentLog { IncidentID=2, Longitude=60, Latitude=60, Altitude= 1500, Timestamp= DateTime.Now },
                        new IncidentLog { IncidentID=2, Longitude=61, Latitude=59, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-5) },
                        new IncidentLog { IncidentID=2, Longitude=62, Latitude=58, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-10) },
                    }
                },
                new Incident {
                    ID=3, Dismissed=true, GPSUnit=_gpsUnits[3], TriggeredTimestamp=DateTime.Now.AddMinutes(-24942), Logs = new List<IncidentLog>
                    {
                        new IncidentLog { IncidentID=3, Longitude=60, Latitude=60, Altitude= 1500, Timestamp= DateTime.Now },
                        new IncidentLog { IncidentID=3, Longitude=61, Latitude=59, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-5) },
                        new IncidentLog { IncidentID=3, Longitude=62, Latitude=58, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-10) },
                    }
                },
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

        public static List<Incident> GetIncidents()
        {
            return _incidents;
        }

        public static List<Depository> GetDepositories()
        {
            return _depositories;
        }

        public static List<ToolBoxGPSUnit> GetToolBoxGPSUnits()
        {
            return _toolBoxGPSUnits;
        }
    }
}
