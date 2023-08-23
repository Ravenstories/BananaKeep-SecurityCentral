using BananaKeep_SecurityCentral.DBSubstitute;
using BananaKeep_SecurityCentral.Models;
using System.Runtime.CompilerServices;

namespace BananaKeep_SecurityCentral.Controllers
{
    public class DatabaseHandler
    {
        //USE DUMMYDATABASE FOR TESTING

        private static DummyDatabase db = new DummyDatabase();

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
            var gpsUnits = DummyDatabase.GetAllGPSUnits();
            //Return all GPSUnits
            return gpsUnits;
        }
        public GPSUnit GetSingleGPSUnitData(int id) 
        {
            //Get single GPSUnit from DummyDatabase
            Console.WriteLine("GPSUnit ID: " + id);
            var gpsUnit = db.GetGPSUnitById(id);
            //Return single GPSUnit
            return gpsUnit;
        }

        public static List<ToolBoxGPSUnit> GetDepositoryToolBoxGPSUnits(int depositoryGPSUnitID) 
        { 
            return db.GetToolBoxGPSUnits().FindAll(t => t.DepositoryGPSUnitID == depositoryGPSUnitID);
        }

        public List<Incident> GetGPSUnitIncidents(int unitID)
        {
            return db.GetIncidents().FindAll(i => i.GPSUnitID == unitID);
        }

        public static List<Incident> GetUserIncidents(int userID)
        {
            return DummyDatabase.GetUserIncidents(userID);
        }
    }
}
