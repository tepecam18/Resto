using Microsoft.AspNetCore.SignalR;
using Realms;
using resto_api.Core;
using RestoWPF.Core;

namespace resto_api.Hubs
{
    public class MyLocalHub : Hub<IMessageClient>
    {
        #region Data
        static Realm realm = Realm.GetInstance(new RealmConfig());
        IQueryable<DeviceModel> devices = realm.All<DeviceModel>();
        IQueryable<UsersModel> users = realm.All<UsersModel>();
        ILog log;
        #endregion

        public MyLocalHub(ILog _Ilog)
        {
            log = _Ilog;
        }

        #region Securty
        public async Task DeviceLoginAsync(string deviceID)
        {
            try
            {
                DeviceModel? device = realm.All<DeviceModel>().Where(i => i.MachineGuid == deviceID && i.IsActive).FirstOrDefault();
                if (device is not null)
                {
                    realm.Write(() =>
                    {
                        device.ConnectionId = Context.ConnectionId;
                    });
                    await Clients.Caller.deviceLogin("Ok");
                }
                else
                {
                    await Clients.Caller.deviceLogin("NotDevice");
                }
            }
            catch (Exception ex)
            {
                log.Write($"sunucu cihazi kontrolü devredışı: {ex.Message}");
                await Clients.Caller.deviceLogin("Warning");
            }
        }

        public async Task UserLoginAsync(string userPin)
        {
            try
            {
                //'Realm accessed from incorrect thread.'
                DeviceModel? device = realm.All<DeviceModel>().Where(i => i.ConnectionId == Context.ConnectionId).FirstOrDefault();
                if (device is not null)
                {
                    UsersModel? user = realm.All<UsersModel>().Where(i => i.Password == userPin).FirstOrDefault();
                    if (user is not null)
                    {
                        realm.Write(() =>
                        {
                            device.User = user;
                            device.WarningCount = 0;
                        });
                        await Clients.Caller.userLogin("Ok");
                    }
                    else
                    {
                        realm.Write(() =>
                        {
                            //sürekli 0 geliyor
                            device.WarningCount+=1;
                            if (device.WarningCount < 7)
                            {
                                //todo anamakina ve bilgi işleme mesaj at, haber ver
                            }
                        });

                        log.Write($"{device.MachineName}: Geçersiz User Bilgisi");
                        await Clients.Caller.userLogin("NotUser");
                    }
                }
                else await Clients.Caller.userLogin("NotDevice");
            }
            catch (Exception ex)
            {
                log.Write($"sunucu kullanıcı kontrolü devredışı: {ex.Message}");
                await Clients.Caller.userLogin("Warning");
            }
        }
        #endregion

        #region Method
        private async Task<bool> DeviceControl()
        {
            return false;
        }
        #endregion

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
