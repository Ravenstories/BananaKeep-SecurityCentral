namespace BananaKeep_SecurityCentral.Models
{
    public class Incident
    {
        public int ID { get; set; }
        public bool Dismissed { get; set; }
        public DateTime TriggeredTimestamp { get; set; }
        public GPSUnit GPSUnit { get; set; }
        public List<IncidentLog> Logs { get; set; }
    }
}
