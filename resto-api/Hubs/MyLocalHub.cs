using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using Realms;
using resto_api.Core;
using resto_api.Modal;
using resto_api.Properties;

namespace resto_api.Hubs
{
    public class MyLocalHub : Hub<IMessageClient>
    {
        #region Data
        Realm realm = Realm.GetInstance(new RealmConfig());
        ILog Log;
        #endregion

        #region Ctor
        public MyLocalHub(ILog log)
        {
            DateTimeOffset Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
            DailyModel Today = realm.All<DailyModel>().Where(i => i.Date == Date).FirstOrDefault();

            if (Today is null)
            {
                realm.Write(() =>
                {
                    Today = realm.Add<DailyModel>(new DailyModel());
                });

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

                    UsersModel usersModel = realm.Add<UsersModel>(new UsersModel
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


                    for (int j = 0; j < 10; j++)
                    {
                        OrderModel b = new OrderModel()
                        {
                            IsClosed = false,
                            SalesPerson = usersModel,
                            PaymantPerson = usersModel,
                            WaiterPerson = usersModel,
                        };
                        foreach (var item in PG.Products)
                        {
                            b.Products.Add(new OrderProductModel()
                            {
                                Product = item,

                            });
                        }
                        Today.Orders.Add(b);
                    }

                    for (int j = 0; j < 1000; j++)
                    {
                        OrderModel b = new OrderModel()
                        {
                            IsClosed = true,
                            SalesPerson = usersModel,
                            PaymantPerson = usersModel,
                            WaiterPerson = usersModel,
                        };
                        foreach (var item in PG.Products)
                        {
                            b.Products.Add(new OrderProductModel()
                            {
                                Product = item,
                            });
                        }
                        Today.Orders.Add(b);
                    }
                });
            }
            Log=log;
        }
        #endregion

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
                }
                else
                {
                    await Clients.Caller.hataMsg("Bu cihaz kaydedilmemiş veya aktif değildir");
                    Log.Write($"Geçersiz Device Talepi: {deviceID}");
                }
            }
            catch (Exception ex)
            {
                Log.Write($"sunucu cihaz kontrolü devredışı: {ex.Message}");
                await Clients.Caller.hataMsg("Warning");
            }
        }

        public async Task UserLoginAsync(string userPin)
        {
            try
            {
                DeviceModel? device = realm.All<DeviceModel>().Where(i => i.ConnectionId == Context.ConnectionId).FirstOrDefault();
                if (device is not null)
                {
                    UsersModel? user = realm.All<UsersModel>().Where(i => i.Password == userPin && i.IsActive).FirstOrDefault();
                    if (user is not null)
                    {

                        realm.Write(() =>
                        {
                            device.User = user;
                            device.WarningCount = 0;
                        });
                        await Clients.Caller.userLogin(200);

                        //today send
                        DateTimeOffset Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
                        Clients.Caller.getDaily(realm.All<DailyModel>().Single(i => i.Date == Date).ToBson());

                        //product list send
                        if (user.productGroups.Count > 0)
                            await Clients.Caller.getProduct(user.productGroups.ToJson());
                        else
                            await Clients.Caller.getProduct(realm.All<ProductGroupModel>().Where(i => i.IsActive).ToList().ToJson());
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
                        Log.Write($"{device.MachineName}: Geçersiz User Bilgisi");
                        await Clients.Caller.hataMsg("Geçersiz User Bilgisi");
                    }
                }
                else
                {
                    Log.Write("Geçersiz Device denemesi yapıldı");
                    await Clients.Caller.hataMsg("Bu cihaz kaydedilmemiş veya aktif değildir");
                }
            }
            catch (Exception ex)
            {
                Log.Write($"sunucu kullanıcı kontrolü devredışı: {ex.Message}");
                await Clients.Caller.hataMsg("Bilgi İşlem İle Görüşün");
            }
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            //todo clear device
            return base.OnDisconnectedAsync(exception);
        }
        #endregion
    }
}
