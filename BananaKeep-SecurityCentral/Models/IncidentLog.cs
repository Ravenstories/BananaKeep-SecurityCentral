namespace BananaKeep_SecurityCentral.Models
{
    public class IncidentLog
    {
        public int IncidentID { get; set; }
        public DateTime Timestamp { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public int Altitude { get; set; }
    }
}
