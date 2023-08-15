﻿using BananaKeep_SecurityCentral.DBSubstitute;
using BananaKeep_SecurityCentral.Models;

namespace BananaKeep_SecurityCentral.Controllers
{
    public class DatabaseHandler
    {
        public DatabaseHandler()
        {

        }
        //USE DUMMYDATABASE FOR TESTING
        

        public void SaveGPSData(GPSData gpsData)
        {
            //Save GPSData to Database
            DummyDatabase.SaveGPSData(gpsData);

        }
        public void UpdateGPSData() { }
        public void DeleteGPSData() { }
        public List<GPSData> GetAllGPSUnitData() 
        {
            //Get all GPSUnits from DummyDatabase
            var gpsUnits = DummyDatabase.GetAllGPSUnits();
            //Return all GPSUnits
            return gpsUnits;
        }
        public GPSData GetSingleGPSUnitData(int id) 
        {
            //Get single GPSUnit from DummyDatabase
            Console.WriteLine("GPSUnit ID: " + id);
            var gpsUnit = DummyDatabase.GetGPSUnitById(id);
            //Return single GPSUnit
            return gpsUnit;
        }

    }
}
