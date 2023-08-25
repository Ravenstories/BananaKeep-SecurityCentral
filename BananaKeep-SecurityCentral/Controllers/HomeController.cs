using Microsoft.AspNetCore.Mvc;

namespace BananaKeep_SecurityCentral.Controllers
{
    public class HomeController : Controller
    {
        public DatabaseHandler DatabaseHandler;
        public TrackingController TrackingController;
        public VerificationController VerificationController;
        public HomeController()
        {
            DatabaseHandler = new DatabaseHandler();
            VerificationController = new VerificationController(DatabaseHandler);
            TrackingController = new TrackingController(DatabaseHandler);
        }
    }
}
