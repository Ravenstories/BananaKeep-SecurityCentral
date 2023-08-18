namespace BananaKeep_SecurityCentral.Models
{ 
    public class GPSUnit
    {
        // GPSData class is used to store the GPS data received from the GPS module.
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
