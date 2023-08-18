using BananaKeep_SecurityCentral.Models;
using Microsoft.AspNetCore.SignalR;


namespace BananaKeep_SecurityCentral.HubConfig
{
    public class IncidentHub : Hub
    {
        public async Task BroadcastChartData(List<Incident> data) =>
            await Clients.All.SendAsync("broadcastincidents", data);
    }
}
