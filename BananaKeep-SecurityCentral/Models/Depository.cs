namespace BananaKeep_SecurityCentral.Models
{
    public class Depository
    {
        public GPSUnit GPSUnit { get; set; }
        public int IncidentTriggerRadiusMeters { get; set; }
        public string LicensePlate { get; set; }
        public List<ToolBoxGPSUnit> ToolBoxGPSUnits { get; set; }
        public User User { get; set; }

    }
}
