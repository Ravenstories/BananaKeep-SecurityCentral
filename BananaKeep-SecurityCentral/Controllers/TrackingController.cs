using BananaKeep_SecurityCentral.Models;

namespace BananaKeep_SecurityCentral.Controllers
{
    public class TrackingController
    {
        //Compare data from Database to see if the units are too far apart

        private static DatabaseHandler databaseHandler = new DatabaseHandler();

        public static void TrackToolBoxGPSUnit(ToolBoxGPSUnit unit)
        {
            //Get all GPSUnits from DatabaseHandler
            
            var gpsUnits = databaseHandler.GetAllGPSUnitData();

            //Get the first GPSUnit
            var gpsUnit1 = gpsUnits[0];
            //Get the second GPSUnit
            var gpsUnit2 = gpsUnits[1];

            //Get the distance between the two GPSUnits
            var distance = DistanceInKmBetweenEarthCoordinates(gpsUnit1.Latitude, gpsUnit1.Longitude, gpsUnit2.Latitude, gpsUnit2.Longitude);
            Console.WriteLine($"Distance: {distance} Km");

            //If the distance is greater than 0.5 km, send an alert
            if (distance > 0.5)
            {
                Console.WriteLine("ALERT: GPS units are too far apart");
            }

        }

        public bool HasUnitCurrentIncident(GPSUnit unit)
        {
            List<Incident> _is = databaseHandler.GetGPSUnitIncidents(unit.ID);

            foreach (Incident i in _is)
            {
                if (i.Dismissed is null)
                {
                    // If dismissed is null, then it means that the user has yet to specify whether there is an incident or not, so we will for now assume it is the case.
                    return true;
                }
                else
                {
                    bool dismissed = i.Dismissed == true;
                    // One might be tempted to "return !dismissed", but we must check the remaining incidents in _is
                    if (!dismissed)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        public static double DistanceInKmBetweenEarthCoordinates(double lat1, double lon1, double lat2, double lon2)
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
