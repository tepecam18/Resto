using Microsoft.AspNetCore.SignalR;
using Realms;
using resto_api.Core;
using RestoWPF.Core;
using SushiHangover.RealmJson;
using System.Collections.Generic;
using System.Text.Json;

namespace resto_api.Hubs
{
    public class MyLocalHub : Hub<IMessageClient>
    {
        #region Data
        private Realm realm { get; set; }
        private IQueryable<DeviceModel> devices { get; set; }
        private IQueryable<UsersModel> users { get; set; }
        private DailyModel? daily { get; set; }
        private IQueryable<ProductGroupModel> productGroups { get; set; }
        ILog log;
        #endregion

        public MyLocalHub(ILog _Ilog)
        {
            realm = Realm.GetInstance(new RealmConfig());
            devices = realm.All<DeviceModel>();
            users = realm.All<UsersModel>();
            //DateTime utc olarak kaydediliyor
            DateTimeOffset Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
            daily = realm.All<DailyModel>().Where(i => i.Date == Date).FirstOrDefault();

            if (daily is null)
            {
                realm.Write(() =>
                {
                    daily = realm.Add<DailyModel>(new DailyModel());
                });
            }

            productGroups = realm.All<ProductGroupModel>().Where(i => i.IsActive);
            //todo realm dosyası açık kontrollü ekle
            log = _Ilog;
        }

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

                        realm.Add<UsersModel>(new UsersModel
                        {
                            Password ="2",
                            IsActive = false,
                            UserName = "ptts"
                        });

                        //DateTimeOffset Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
                        //Bugünün verisini al yoksa oluştur
                        //if (realm.All<DailyModel>().Where(i => i.Date == Date).Count() >= 1)
                        //{
                        //    Today = realm.All<DailyModel>().Where(i => i.Date == Date).First();
                        //}
                        //else
                        //{
                        realm.Add(new DailyModel());
                        //}

                        CostumeThemeModel costumeTheme = realm.Add(new CostumeThemeModel()
                        {
                            Color = "#FFFF0000",
                        });

                        for (int i = 0; i < 4; i++)
                        {
                            var TL = realm.Add(new TableFloorModel()
                            {
                                FloorName = $"Kat: {i}",
                            });

                            for (int j = 0; j < 5*i; j++)
                            {
                                if (TL.Tables is not null)
                                {
                                    TL.Tables.Add(new TableModel()
                                    {
                                        TableName = $"Masa: {j}",
                                    });
                                }
                            }
                        }

                        var PG = realm.Add(new ProductGroupModel()
                        {
                            GroupName = "Köfte",
                            IsActive = true,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Burger yerim Menü 70gr",
                            Price = 80,
                            CostumeTheme = costumeTheme,
                        });

                        PG = realm.Add(new ProductGroupModel()
                        {
                            GroupName = "Et",
                            IsActive = true,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Et yerim Menü 70gr",
                            Price = 90,
                            CostumeTheme = costumeTheme,
                        });

                        PG = realm.Add(new ProductGroupModel()
                        {
                            GroupName = "Tavuk",
                            IsActive = true,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 70gr",
                            Price = 90,
                        });

                        PG = realm.Add(new ProductGroupModel()
                        {
                            GroupName = "Hepsi Mi bir",
                            IsActive = true,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Et yerim Menü 70gr",
                            Price = 90.95M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Taavuk yerim Menü 80gr",
                            Price = 90.9999M,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Seni yerim Menü 70gr",
                            Price = 90,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Et yerim Menü 70gr",
                            Price = 90.95M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Taavsuk yesrim Menü 80gr",
                            Price = 90.9999M,
                            CostumeTheme = costumeTheme,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Senis yserim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Senis yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Sensi yerim Menü 90gr",
                            Price = 90.99M,
                        });
                        PG.Products.Add(new ProductModel()
                        {
                            IsActive = true,
                            Name = "Ramazan Sensis yerim Menü 90gr",
                            Price = 90.99M,
                        });

                        DailyModel today = new DailyModel();

                        for (int j = 0; j < 1000; j++)
                        {
                            OrderModel b = new OrderModel();
                            foreach (var item in PG.Products)
                            {
                                b.Products.Add(new OrderProductModel()
                                {
                                    Product = item
                                });
                            }
                            today.Orders.Add(b);
                        }
                    });
                }

                DeviceModel? device = devices.Where(i => i.MachineGuid == deviceID && i.IsActive).FirstOrDefault();
                if (device is not null)
                {
                    realm.Write(() =>
                    {
                        device.ConnectionId = Context.ConnectionId;
                    });
                }
                else
                {
                    await Clients.Caller.hataMsg("Bu cihaz kaydedilmemiş veya aktif değildir");
                    log.Write($"Geçersiz Device Talepi: {deviceID}");
                }
            }
            catch (Exception ex)
            {
                log.Write($"sunucu cihaz kontrolü devredışı: {ex.Message}");
                await Clients.Caller.hataMsg("Warning");
            }
        }

        public async Task UserLoginAsync(string userPin)
        {
            try
            {
                DeviceModel? device = devices.Where(i => i.ConnectionId == Context.ConnectionId).FirstOrDefault();
                if (device is not null)
                {
                    UsersModel? user = users.Where(i => i.Password == userPin && i.IsActive).FirstOrDefault();
                    if (user is not null)
                    {
                        realm.Write(() =>
                        {
                            device.User = user;
                            device.WarningCount = 0;
                        });
                        await Clients.Caller.userLogin(200);

                        //today send
                        if (daily is not null)
                            await Clients.Caller.getDaily(JsonSerializer.Serialize<DailyModel>(daily));

                        //product list send
                        
                        if (user.productGroups.Count > 0)
                            await Clients.Caller.getProduct(JsonSerializer.Serialize<IList<ProductGroupModel>>(user.productGroups));
                        else
                            await Clients.Caller.getProduct(JsonSerializer.Serialize<IQueryable<ProductGroupModel>>(productGroups));
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
                        await Clients.Caller.hataMsg("Geçersiz User Bilgisi");
                    }
                }
                else
                {
                    log.Write("Geçersiz Device denemesi yapıldı");
                    await Clients.Caller.hataMsg("Bu cihaz kaydedilmemiş veya aktif değildir");
                }
            }
            catch (Exception ex)
            {
                log.Write($"sunucu kullanıcı kontrolü devredışı: {ex.Message}");
                await Clients.Caller.hataMsg("Bilgi İşlem İle Görüşün");
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
