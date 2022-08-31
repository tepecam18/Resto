using Microsoft.AspNetCore.SignalR;
using Realms;
using resto_api.Core;
using RestoWPF.Core;

namespace resto_api.Hubs
{
    public class MyLocalHub : Hub<IMessageClient>
    {
        #region Data
        private Realm realm { get; set; }
        private IQueryable<DeviceModel> devices { get; set; }
        private IQueryable<UsersModel> users { get; set; }
        ILog log;
        #endregion

        public MyLocalHub(ILog _Ilog)
        {
            realm = Realm.GetInstance(new RealmConfig());
            devices = realm.All<DeviceModel>();
            users = realm.All<UsersModel>();
            //todo realm dosyası açık kontrollü ekle
            log = _Ilog;
        }

        #region Method
        private bool DeviceControl()
        {
            DeviceModel? device = devices.Where(i => i.ConnectionId == Context.ConnectionId).FirstOrDefault();
            return device is not null;
        }
        #endregion

        #region Securty
        public async Task DeviceLoginAsync(string deviceID)
        {
            try
            {

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

                        realm.Add<DeviceModel>(new DeviceModel
                        {
                            MachineGuid ="9c8fdcf5-ddce-41af-bb2b-ddcfb67aa830",
                            IsActive = true,
                            MachineName = "ptts2"
                        });

                        realm.Add<UsersModel>(new UsersModel
                        {
                            Password ="1",
                            IsActive = true,
                            UserName = "tpcm"
                        });
                    });
                }

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
                    log.Write($"Geçersiz Device Talepi: {deviceID}");
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
                        log.Write($"{device.MachineName}: Geçersiz User Bilgisi.");
                        await Clients.Caller.userLogin("NotUser");
                    }
                }
                else
                {
                    log.Write("Geçersiz Device denemesi yapıldı");
                    await Clients.Caller.userLogin("NotDevice");
                }
            }
            catch (Exception ex)
            {
                log.Write($"sunucu kullanıcı kontrolü devredışı: {ex.Message}");
                await Clients.Caller.userLogin("Warning");
            }
        }
        #endregion

        #region Daily

        public async Task GetDailyAsync()
        {
            try
            {
                DeviceModel? device = devices.Where(i => i.ConnectionId == Context.ConnectionId).FirstOrDefault();
                if (device is not null)
                {

                }
                else
                {
                    log.Write("Geçersiz Device denemesi yapıldı");
                }
            }
            catch (Exception ex)
            {
                log.Write($"sunucu kullanıcı kontrolü devredışı: {ex.Message}");
            }
        }

        #endregion

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            //todo clear device
            return base.OnDisconnectedAsync(exception);
        }
    }
}
