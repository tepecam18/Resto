using Microsoft.AspNetCore.SignalR;
using Realms;
using RestoWPF.Core;

public class MyHub : Hub
{
    static Realm realm = Realm.GetInstance(new RealmConfig());

    public async Task SendMessage(string msg)
    {
        await Clients.All.SendAsync("recieveMessage", msg);
    }

    public override Task OnConnectedAsync()
    {
        var id = Context.ConnectionId;
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }
}