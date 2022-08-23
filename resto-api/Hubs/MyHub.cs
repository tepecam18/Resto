using Microsoft.AspNetCore.SignalR;

public class MyHub : Hub
{
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