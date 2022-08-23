using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Realms;
using RestoWPF.Core;
using SushiHangover.RealmJson;
using System.Reflection;
using System.Security.Cryptography;

namespace resto_api.Controllers
{
    public class CenterController : ControllerBase
    {
        Realm realm = Realm.GetInstance(new RealmConfig());

        #region Test

        [HttpGet]
        public void GetTest()
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSAParameters Rpublic = RSA.ExportParameters(false);
                RSAParameters Rprivate = RSA.ExportParameters(true);

                string parameters = JsonConvert.SerializeObject(Rpublic);
                RSAParameters parameters2 = JsonConvert.DeserializeObject<RSAParameters>(parameters);
                //RSAParameters sAParameters = JsonConvert.DeserializeObject<RSAParameters>(Rpublic);
            }
            //encryptedData = RSAEncrypt(dataToEncrypt, Rpublic, false);

            //decryptedData = RSADecrypt(encryptedData, Rprivate, false);
        }

        [HttpGet]
        public void Get()
        {

            realm.Write(() =>
            {
                //RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography");
                //string a = key.GetValue("MachineGUID").ToString();
                //if (key != null)
                //{
                //    realm.Add(new DeviceModel()
                //    {

                //        MachineGuid = key.GetValue("MachineGUID").ToString()
                //    });
                //}

                CostumeThemeModel costumeTheme = realm.Add(new CostumeThemeModel()
                {
                    Color = "#FFFF0000",
                });

                realm.Add(new UsersModel()
                {
                    UserName = "tpcm",
                    Password = "1",
                    IsActive = true,
                });

                realm.Add(new DeviceModel()
                {
                    MachineGuid = "1",
                    MachineName = "1",
                    IsActive = true
                });


                for (int i = 0; i < 4; i++)
                {
                    var TL = realm.Add(new TableFloorModel()
                    {
                        FloorName = $"Kat: {i}",
                    });

                    for (int j = 0; j < 5*i; j++)
                    {
                        TL.Tables.Add(new TableModel()
                        {
                            TableName = $"Masa: {j}",
                        });
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

                //todo sifreler haslanacak
            });
        }

        [HttpPost]
        public async Task<ActionResult<string>> Token(string apiKey, string deviceid)
        {
            DeviceModel? device = realm.All<DeviceModel>().Where(i => i.IsActive == true && i.MachineGuid == deviceid).First();
            if (device is not null)
            {

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSAParameters Rpublic = RSA.ExportParameters(false);
                    RSAParameters Rprivate = RSA.ExportParameters(true);


                    realm.Write(() =>
                    {
                        device.Token = JsonConvert.SerializeObject(Rpublic);
                        device.PrivateKey = JsonConvert.SerializeObject(Rprivate);
                    });

                    return Ok(device.Token);
                }

            }
            else
                return BadRequest("Hatalı Sözdizilimi");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(string guid)
        {
            DeviceModel? device = realm.All<DeviceModel>().Where(i => i.IsActive == true && i.MachineGuid == guid).First();
            if (device is not null)
            {

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSAParameters Rpublic = RSA.ExportParameters(false);
                    RSAParameters Rprivate = RSA.ExportParameters(true);

                   
                    realm.Write(() =>
                    {
                        device.Token = JsonConvert.SerializeObject(Rpublic);
                        device.PrivateKey = JsonConvert.SerializeObject(Rprivate);
                    });

                    return Ok(device.Token);
                }

            }
            else
                return BadRequest("Hatalı Sözdizilimi");
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostTodoItem(string passwd)
        {
            UsersModel usersModel = realm.All<UsersModel>().Where(i => i.IsActive == true && i.Password == passwd).FirstOrDefault().NonManagedCopy<UsersModel>();
            if (usersModel is not null)
            {
                usersModel.Password = "*******************************";
                return Ok(usersModel);
            }
            return BadRequest("Hatalı Sözdizilimi");
        }
        #endregion
    }
}
