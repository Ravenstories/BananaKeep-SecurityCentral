using BananaKeep_SecurityCentral.DBSubstitute;
using BananaKeep_SecurityCentral.Models;
using System.Runtime.CompilerServices;

namespace BananaKeep_SecurityCentral.Controllers
{
    public class DatabaseHandler
    {
        //USE DUMMYDATABASE FOR TESTING

        public void SaveGPSData(GPSUnit gpsData)
        {
            //Save GPSData to Database
            DummyDatabase.SaveGPSData(gpsData);

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
            var gpsUnit = DummyDatabase.GetGPSUnitById(id);
            //Return single GPSUnit
            return gpsUnit;
        }

        public static List<ToolBoxGPSUnit> GetDepositoryToolBoxGPSUnits(int depositoryGPSUnitID) 
        { 
            return DummyDatabase.GetToolBoxGPSUnits().FindAll(t => t.DepositoryGPSUnitID == depositoryGPSUnitID);
        }

        public static List<Incident> GetRelevantIncidents(int userID)
        {
            List<Incident> userIncidents = new List<Incident>();

            // First we find all the depositories belonging to the user
            List<Depository> depositories = DummyDatabase.GetDepositories().FindAll(d => d.User.ID == userID);



            // Then we check and see, if there are any ongoing incidents for the Depositories (in the case of a stolen van), or any of the tools therein.
            List<Incident> incidents = DummyDatabase.GetIncidents();
            foreach (Incident inc in incidents)
            {
                foreach (Depository de in depositories)
                {
                    if (de.GPSUnit.ID == inc.GPSUnit.ID)
                    {
                        userIncidents.Add(inc); 
                        break;
                    }
                    else
                    {
                        foreach (ToolBoxGPSUnit toolBox in de.ToolBoxGPSUnits)
                        {
                            if (inc.GPSUnit.ID == toolBox.GPSUnit.ID)
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
    }
}
