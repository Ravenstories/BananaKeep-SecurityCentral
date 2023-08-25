using BananaKeep_SecurityCentral.DBSubstitute;
using BananaKeep_SecurityCentral.Models;
using System.Runtime.CompilerServices;

namespace BananaKeep_SecurityCentral.Controllers
{
    public class DatabaseHandler
    {
        //USE DUMMYDATABASE FOR TESTING

        private DummyDatabase db;

        public DatabaseHandler() 
        { 
            db = new DummyDatabase();
        }

        public void SaveGPSData(GPSUnit gpsData)
        {
            //Save GPSData to Database
            db.SaveGPSData(gpsData);

        }
        public void UpdateGPSData() { }
        public void DeleteGPSData() { }
        public List<GPSUnit> GetAllGPSUnitData() 
        {
            //Get all GPSUnits from DummyDatabase
            List<GPSUnit> gpsUnits = db.GetAllGPSUnits();
            //Return all GPSUnits
            return gpsUnits;
        }
        public GPSUnit GetSingleGPSUnitData(int id) 
        {
            //Get single GPSUnit from DummyDatabase
            Console.WriteLine("GPSUnit ID: " + id);
            GPSUnit gpsUnit = db.GetGPSUnitById(id);
            //Return single GPSUnit
            return gpsUnit;
        }

        public List<ToolBoxGPSUnit> GetDepositoryToolBoxGPSUnits(int depositoryGPSUnitID) 
        { 
            return db.GetToolBoxGPSUnits().FindAll(t => t.DepositoryGPSUnitID == depositoryGPSUnitID);
        }

        public List<Incident> GetGPSUnitIncidents(int unitID)
        {
            return db.GetIncidents().FindAll(i => i.GPSUnitID == unitID);
        }

        public List<Incident> GetUserIncidents(int userID)
        {
            return db.GetUserIncidents(userID);
        }

        public List<Incident> GetIncidents()
        {
            return db.GetIncidents();
        }

        private IncidentLog GPSUnitToIncidentLog(GPSUnit unit)
        {
            IncidentLog iLog = new IncidentLog();
            iLog.IncidentID = unit.ID;
            iLog.Longitude = unit.Longitude;
            iLog.Latitude = unit.Latitude;
            iLog.Altitude = unit.Altitude;
            iLog.Timestamp = unit.Timestamp;

            return iLog;
        }

        public void CreateIncidentLogEntry(GPSUnit gpsData)
        {
            // First we find the incident (one that is not dismissed).
            Incident incident = db.GetIncidents().First(i => i.GPSUnitID == gpsData.ID && i.Dismissed != true); // "i.Dismissed != true" safely allows for null and false.

            // Second we package the gpsData into an incident log
            IncidentLog iLog = GPSUnitToIncidentLog(gpsData);

            // Third we Save it to the incident
            db.CreateIncidentLogEntry(iLog, incident.ID);
        }

        public void CreateIncident(GPSUnit unit, int userID)
        {
            Incident incident = new Incident();
            incident.GPSUnitID = unit.ID;
            incident.TriggeredTimestamp = unit.Timestamp;
            incident.Logs = new List<IncidentLog>
            {
                GPSUnitToIncidentLog(unit)
            };
            db.CreateIncident(incident, db.GetUsers().First(u => u.ID == userID));
        }
    }
}
