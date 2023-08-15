namespace BananaKeep_SecurityCentral.Models
{
    public class Depository
    {
        public int ID { get; set; }
        public int IncidentTriggerRadiusMeters { get; set; }
        public string LicensePlate { get; set; }
        public GPSUnit GPSUnit { get; set; }
        public List<ToolBoxGPSUnit> ToolBoxGPSUnits { get; set; }
        public User User { get; set; }

    }
}
