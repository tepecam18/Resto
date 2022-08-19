using Microsoft.AspNetCore.SignalR;

namespace resto_api.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string msg)
        {
            await Clients.All.SendAsync("recieveMessage", msg);
        }
    }
}
