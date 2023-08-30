using BananaKeep_SecurityCentral.Models;

namespace BananaKeep_SecurityCentral.Controllers
{
    public class TrackingController
    {
        //Compare data from Database to see if the units are too far apart

        private DatabaseHandler databaseHandler;

        public TrackingController(DatabaseHandler dbh)
        {
            databaseHandler = dbh;
        }

        public void ProcessGPSData(GPSUnit gpsData)
        {
            databaseHandler.SaveGPSData(gpsData);

            // Check if there is an incident with this unit
            if (HasUnitCurrentIncident(gpsData))
            {
                databaseHandler.CreateIncidentLogEntry(gpsData);
            }
            else
            {
                // If not, then find out what Kind it is.
                GPSUnit unit = databaseHandler.GetSingleGPSUnitData(gpsData.ID);

                // If it is a toolbox gps unit... We must check its relative position to its Depository.
                if (unit is ToolBoxGPSUnit)
                {
                    TrackToolBoxGPSUnit((ToolBoxGPSUnit)unit);
                }
            }
        }

        private void TrackToolBoxGPSUnit(ToolBoxGPSUnit unit)
        {
            //Get all GPSUnits from DatabaseHandler
            
            Depository depo = (Depository)databaseHandler.GetSingleGPSUnitData(unit.DepositoryGPSUnitID);

            //Get the distance between the two GPSUnits
            var distance = DistanceInKmBetweenEarthCoordinates(unit.Latitude, unit.Longitude, depo.Latitude, depo.Longitude);
            Console.WriteLine($"Distance: {distance} Km");

            //If the distance is greater than 
            if (distance > (depo.IncidentTriggerRadiusMeters * 0.001))
            {
                Console.WriteLine("ALERT: GPS units are too far apart");

                // Create New incident!
                databaseHandler.CreateIncident(unit, depo.UserID);
            }
        }

        private bool HasUnitCurrentIncident(GPSUnit unit)
        {
            List<Incident> _is = databaseHandler.GetGPSUnitIncidents(unit.ID);

            foreach (Incident i in _is)
            {
                if (i.Dismissed != true) // "nullable-bool != true" allows for Null
                {
                    // If dismissed is null, then it means that the user has yet to specify whether there is an incident or not, so we will for now assume it is the case.
                    return true;
                }
            }
            return false;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        private double DistanceInKmBetweenEarthCoordinates(double lat1, double lon1, double lat2, double lon2)
        {
            double earthRadiusKm = 6371;

            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);

            lat1 = DegreesToRadians(lat1);
            lat2 = DegreesToRadians(lat2);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return earthRadiusKm * c;
        }
    }
}
