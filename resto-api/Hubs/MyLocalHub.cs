using Microsoft.AspNetCore.SignalR;
using Realms;
using resto_api.Core;
using RestoWPF.Core;

namespace resto_api.Hubs
{
    public class MyLocalHub : Hub<IMessageClient>
    {
        #region Data
        static Realm realm;
        static IQueryable<DeviceModel> devices;
        static IQueryable<UsersModel> users;
        ILog log;
        #endregion

        public MyLocalHub(ILog _Ilog)
        {
            //todo realm dosyası açık kontrollü ekle
            log = _Ilog;
            realm = Realm.GetInstance(new RealmConfig());
            devices = realm.All<DeviceModel>();
            users = realm.All<UsersModel>();

            if (devices.Count() == 0)
            {
                realm.Write(() =>
                {
                    realm.Add<DeviceModel>(new DeviceModel
                    {
                        MachineGuid ="87b4d63e-f0c6-41d5-b483-d5b023026c1b",
                        IsActive = true,
                        MachineName = "ptts"
                    });

                    realm.Add<UsersModel>(new UsersModel
                    {
                        Password ="1",
                        IsActive = true,
                        UserName = "tpcm"
                    });
                });
            }
        }

        #region Securty
        public async Task DeviceLoginAsync(string deviceID)
        {
            try
            {
                DeviceModel? device = devices.Where(i => i.MachineGuid == deviceID && i.IsActive).FirstOrDefault();
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
                log.Write($"sunucu cihaz kontrolü devredışı: {ex.Message}");
                await Clients.Caller.deviceLogin("Warning");
            }
        }

        public async Task UserLoginAsync(string userPin)
        {
            try
            {
                DeviceModel? device = devices.Where(i => i.ConnectionId == Context.ConnectionId).FirstOrDefault();
                if (device is not null)
                {
                    UsersModel? user = users.Where(i => i.Password == userPin).FirstOrDefault();
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
                            if (++device.WarningCount > 7)
                            {
                                device.WarningCount = 0;
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
            DeviceModel? device = devices.Where(i => i.ConnectionId == Context.ConnectionId).FirstOrDefault();
            return false;
        }
        #endregion

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
