namespace BananaKeep_SecurityCentral.Models
{
    public class Depository : GPSUnit
    {
        public int IncidentTriggerRadiusMeters { get; set; }
        public string LicensePlate { get; set; }
        public List<ToolBoxGPSUnit> ToolBoxGPSUnits { get; set; }
        public int UserID { get; set; }

    }
}
