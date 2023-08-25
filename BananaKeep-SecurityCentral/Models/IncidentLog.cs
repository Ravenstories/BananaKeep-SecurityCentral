namespace BananaKeep_SecurityCentral.Models
{
    public class IncidentLog
    {
        public int IncidentID { get; set; }
        public DateTime Timestamp { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
    }
}
