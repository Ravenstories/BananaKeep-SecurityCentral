namespace BananaKeep_SecurityCentral.Controllers
{
    public class TrackingController
    {
        //Compare data from Database to see if the units are too far apart

        public static void TrackGPSData()
        {
            //Get all GPSUnits from DatabaseHandler
            DatabaseHandler databaseHandler = new DatabaseHandler();
            var gpsUnits = databaseHandler.GetAllGPSUnitData();

            //Get the first GPSUnit
            var gpsUnit1 = gpsUnits[0];
            //Get the second GPSUnit
            var gpsUnit2 = gpsUnits[1];

            //Get the distance between the two GPSUnits
            var distance = DistanceInKmBetweenEarthCoordinates(gpsUnit1.Latitude, gpsUnit1.Longitude, gpsUnit2.Latitude, gpsUnit2.Longitude);
            Console.WriteLine("Distance: ", distance);

            //If the distance is greater than 0.5 km, send an alert
            if (distance > 0.5)
            {
                Console.WriteLine("ALERT: GPS units are too far apart");
            }

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
