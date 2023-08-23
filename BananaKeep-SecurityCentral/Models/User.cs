namespace BananaKeep_SecurityCentral.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyCVR { get; set; }
        public List<Depository> Depositories { get; set; }

        public List<Incident> Incidents { get; set; }
    }
}
