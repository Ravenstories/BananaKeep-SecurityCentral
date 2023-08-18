using BananaKeep_SecurityCentral.Models;
using Microsoft.AspNetCore.SignalR;


namespace BananaKeep_SecurityCentral.HubConfig
{
    public class IncidentHub : Hub
    {
        public async Task BroadcastIncidentData(List<Incident> data) =>
            await Clients.All.SendAsync("broadcastincidentdata", data);
    }
}
