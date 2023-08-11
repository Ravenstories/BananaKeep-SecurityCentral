namespace BananaKeep_SecurityCentral.Models
{ 
    public class GPSData
    {
        // GPSData class is used to store the GPS data received from the GPS module.
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Active { get; set; }
    }
}
