using BananaKeep_SecurityCentral.TimerFeatures;
using BananaKeep_SecurityCentral.HubConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using BananaKeep_SecurityCentral.Models;

namespace BananaKeep_SecurityCentral.Controllers
{
    [ApiController]
    [Route("/ws/[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IHubContext<IncidentHub> hub;
        private readonly TimerManager timer;
        private DatabaseHandler databaseHandler = Main.Home.DatabaseHandler;

        public IncidentController(IHubContext<IncidentHub> _hub, TimerManager _timer)
        {
            hub = _hub;
            timer = _timer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!timer.IsTimerStarted)

                timer.SetTimer(
                    // When the timer hits an interval, it will send the following to all clients
                    () => hub.Clients.All.SendAsync(
                        "TransferIncidentData", // package name
                        databaseHandler.GetIncidents().FindAll(i => i.Dismissed is null) // The package itself. All unanswered Incidents.
                        ));
            return Ok(new { Message = "Request Completed"});
        }
    }
}
