using Microsoft.AspNetCore.SignalR;
using Realms;
using resto_api.Interfaces;
using RestoWPF.Core;

namespace resto_api.Hubs
{
    public class MyLocalHub : Hub<IMessageClient>
    {
        #region Data
        static Realm realm = Realm.GetInstance(new RealmConfig());
        #endregion


        public async Task DeviceLoginAsync(string deviceID)
        {
            //await Clients.All.SendAsync("deviceLogin", deviceID);
            await Clients.All.deviceLogin(deviceID);
        }

        public async Task UserLoginAsync(string userID)
        {
            //await Clients.All.SendAsync("userLogin", userID);
            await Clients.All.userLogin(userID);
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
