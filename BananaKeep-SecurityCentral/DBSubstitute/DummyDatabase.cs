using BananaKeep_SecurityCentral.Models;

namespace BananaKeep_SecurityCentral.DBSubstitute
{
    public class DummyDatabase
    {
        private List<User> _users;
        private List<GPSUnit> _gpsUnits;
        private List<Depository> _depositories;
        private List<ToolBoxGPSUnit> _toolBoxGPSUnits;
        private List<Incident> _incidents;

        public DummyDatabase()
        {
            Initialize();
        }
        private void Initialize()
        {
            _users = new List<User>
            {
                new User {ID = 1, CompanyCVR = 12345678, Email="torben@torbentools.com", FullName = "Torben Toolesen", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 6969 6969", Depositories = new List<Depository>(), Incidents = new List<Incident>()},
                new User {ID = 2, CompanyCVR = 12345678, Email="svend@torbentools.com", FullName = "Svend Toolesen", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 6969 6969", Depositories = new List<Depository>(), Incidents = new List<Incident>()},
                new User {ID = 3, CompanyCVR = 87654321, Email="albert@monkeybusiness.com", FullName = "Albert II", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 0420 1337", Depositories = new List<Depository>(), Incidents = new List<Incident>()},
                new User {ID = 4, CompanyCVR = 12345678, Email="joergen@torbentools.com", FullName = "Jørgen Toolesen", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 6969 6969", Depositories = new List<Depository>(), Incidents = new List<Incident>()},
                new User {ID = 5, CompanyCVR = 87654321, Email="chad@monkeybusiness.com", FullName = "Chad Monkey", Password="4js5i7s5it5Hez3445zz5", PhoneNumber="+45 0420 6969", Depositories = new List<Depository>(), Incidents = new List<Incident>()}
            };


            _gpsUnits = new List<GPSUnit>
            {
                new ToolBoxGPSUnit { ID = 1, Name="Torben's Tobenet Venstrehånds Undergrebet Bøje Sav", DepositoryGPSUnitID = 3, Latitude = 37.7749, Longitude = -122.4194, Timestamp = DateTime.Now, Active = true, Altitude = 1500 }, // Tool D1
                new ToolBoxGPSUnit { ID = 2, Name="Torben's Torbulator", DepositoryGPSUnitID = 3, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.Now.AddHours(-1), Active = true, Altitude = 1500}, // tool D1
                new Depository { ID = 3, Name="Torben's Vogn", IncidentTriggerRadiusMeters=10, LicensePlate="1234-ABC", UserID = 1, Latitude = 41.8781, Longitude = -87.6298, Timestamp = DateTime.Now.AddHours(-2), Active = true, Altitude = 1500, ToolBoxGPSUnits = new List<ToolBoxGPSUnit>()}, // Depository 1 - Torben Tools
                new ToolBoxGPSUnit { ID = 4, Name="Torben's Boremaskine", DepositoryGPSUnitID = 3, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.Now.AddHours(-3), Active = false, Altitude = 1500}, // tool D1
                new ToolBoxGPSUnit { ID = 5, Name="Svend's Automassager", DepositoryGPSUnitID = 7, Latitude = 29.7604, Longitude = -95.3698, Timestamp = DateTime.Now.AddHours(-4), Active = false, Altitude = 1500}, // tool D2
                new ToolBoxGPSUnit { ID = 6, Name="Svend's Svensknøgle", DepositoryGPSUnitID = 7, Latitude = 39.7604, Longitude = -85.3698, Timestamp = DateTime.Now.AddMinutes(-4), Active = true, Altitude = 1500}, // tool D2
                new Depository { ID = 7, Name="Svend's Vogn", IncidentTriggerRadiusMeters=10, LicensePlate="1234-ABC", UserID = 2, Latitude = 49.7604, Longitude = -75.3698, Timestamp = DateTime.Now.AddSeconds(-4), Active = true, Altitude = 1500, ToolBoxGPSUnits = new List<ToolBoxGPSUnit>()}, // Depository 2 - Torben Tools
                new Depository { ID = 8, Name="Banana Fleet Vehicle 1", IncidentTriggerRadiusMeters=10, LicensePlate="1234-ABC", UserID = 3, Latitude = 59.7604, Longitude = -65.3698, Timestamp = DateTime.Now.AddDays(-1), Active = true, Altitude = 1500, ToolBoxGPSUnits = new List<ToolBoxGPSUnit>()}, // Depository 3 - Monkey Business
                new ToolBoxGPSUnit { ID = 9, Name="Stix's Sticky Box of Sticky Stick Stickers", DepositoryGPSUnitID = 8, Latitude = 69.7604, Longitude = -55.3698, Timestamp = DateTime.Now.AddYears(-1), Active = true, Altitude = 1500}, // tool D3
                
                // Add more GPS units here
            };

            _incidents = new List<Incident>
            {
                new Incident {
                    ID=1, Dismissed=true, GPSUnitID=1, TriggeredTimestamp=DateTime.Now.AddMinutes(-24942), Logs = new List<IncidentLog>
                    {
                        new IncidentLog { IncidentID=1, Longitude=60, Latitude=60, Altitude= 1500, Timestamp= DateTime.Now },
                        new IncidentLog { IncidentID=1, Longitude=61, Latitude=59, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-5) },
                        new IncidentLog { IncidentID=1, Longitude=62, Latitude=58, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-10) },
                    }
                },
                new Incident {
                    ID=2, Dismissed=false, GPSUnitID=6, TriggeredTimestamp=DateTime.Now.AddMinutes(-24942), Logs = new List<IncidentLog>
                    {
                        new IncidentLog { IncidentID=2, Longitude=60, Latitude=60, Altitude= 1500, Timestamp= DateTime.Now },
                        new IncidentLog { IncidentID=2, Longitude=61, Latitude=59, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-5) },
                        new IncidentLog { IncidentID=2, Longitude=62, Latitude=58, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-10) },
                    }
                },
                new Incident {
                    ID=3, Dismissed=true, GPSUnitID=4, TriggeredTimestamp=DateTime.Now.AddMinutes(-24942), Logs = new List<IncidentLog>
                    {
                        new IncidentLog { IncidentID=3, Longitude=60, Latitude=60, Altitude= 1500, Timestamp= DateTime.Now },
                        new IncidentLog { IncidentID=3, Longitude=61, Latitude=59, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-5) },
                        new IncidentLog { IncidentID=3, Longitude=62, Latitude=58, Altitude= 1500, Timestamp= DateTime.Now.AddSeconds(-10) },
                    }
                },
            };

            _depositories = new List<Depository>();
            _toolBoxGPSUnits = new List<ToolBoxGPSUnit>();

            foreach (object unit in _gpsUnits)
            {
                if (unit is Depository)
                {
                    Depository depo = (Depository)unit;
                    foreach (object potentialToolBoxGPSUnit in _gpsUnits)
                    {
                        if (potentialToolBoxGPSUnit is ToolBoxGPSUnit)
                        {
                            ToolBoxGPSUnit tb = (ToolBoxGPSUnit)potentialToolBoxGPSUnit;
                            if (tb.DepositoryGPSUnitID == depo.ID)
                            {
                                depo.ToolBoxGPSUnits.Add(tb);
                            }
                        }
                    }
                    foreach (User user in _users)
                    {
                        if (depo.UserID == user.ID)
                        {
                            user.Depositories.Add(depo);
                            break;
                        }
                    }

                    _depositories.Add(depo);
                } else if (unit is ToolBoxGPSUnit)
                {
                    _toolBoxGPSUnits.Add((ToolBoxGPSUnit)unit);
                }
            }

            foreach (User u in _users)
            {
                u.Incidents = GetUserIncidents(u.ID);
            }
            

            Console.WriteLine(_gpsUnits.Count + " GPS units added to the database.");
        }

        public List<Incident> GetUserIncidents(int userID)
        {
            List<Incident> userIncidents = new List<Incident>();

            // First we find all the depositories belonging to the user
            List<Depository> depositories = _depositories.FindAll(d => d.UserID == userID);

            // Then we check and see, if there are any ongoing incidents for the Depositories (in the case of a stolen van), or any of the tools therein.
            List<Incident> incidents = _incidents;
            foreach (Incident inc in incidents)
            {
                foreach (Depository de in depositories)
                {
                    if (de.ID == inc.GPSUnitID)
                    {
                        userIncidents.Add(inc);
                        break;
                    }
                    else
                    {
                        foreach (ToolBoxGPSUnit toolBox in de.ToolBoxGPSUnits)
                        {
                            if (inc.GPSUnitID == toolBox.ID)
                            {
                                userIncidents.Add(inc);
                                break;
                            }
                        }
                    }
                }
            }

            return userIncidents;
        }

        //return all GPS units
        public List<GPSUnit> GetAllGPSUnits()
        {
            return _gpsUnits;
        }
        //return a GPS unit by id
        public GPSUnit GetGPSUnitById(int id)
        {
           return _gpsUnits.FirstOrDefault(gpsUnit => gpsUnit.ID == id);
        }
        
        public List<User> GetUsers()
        {
            return _users;
        }

        //save GPS data
        public void SaveGPSData(GPSUnit gpsData)
        {
            //Check if id exists
            var gpsUnit = GetGPSUnitById(gpsData.ID);
            if (_gpsUnits.Count(u => u.ID == gpsData.ID) == 1)
            {
                try
                {
                    foreach (GPSUnit unit in _gpsUnits) 
                    {
                        if (unit.ID == gpsUnit.ID)
                        {
                            unit.Longitude = gpsUnit.Longitude;
                            unit.Latitude = gpsUnit.Latitude;
                            unit.Altitude = gpsUnit.Altitude;
                            unit.Timestamp = gpsUnit.Timestamp;
                        }
                    }
                    Console.WriteLine("GPS data saved.");
                }
                catch 
                { 
                    Console.WriteLine("Couldn't save new gps data for: ", gpsUnit.ID); 
                }
            } 
            else
            {
                throw new Exception("GPS unit does not exist");
            }
        }

        public List<Incident> GetIncidents()
        {
            return _incidents;
        }

        public List<Depository> GetDepositories()
        {
            return _depositories;
        }

        public List<ToolBoxGPSUnit> GetToolBoxGPSUnits()
        {
            return _toolBoxGPSUnits;
        }

        public void CreateIncidentLogEntry(IncidentLog entry, int incidentID)
        {
            _incidents.First(i => i.ID == incidentID).Logs.Add(entry);
        }
        public void CreateIncident(Incident incident, User user)
        {
            _incidents.Add(incident);
            user.Incidents.Add(incident);
        }
    }
}
