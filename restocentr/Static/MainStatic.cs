using restocentr.Model;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Threading;
using Microsoft.Win32;

namespace restocentr.Static
{
    internal static class St
    {
        public static DailyModel Today;
        public static OrderModel Order = new OrderModel();
        internal static UsersModel User { get; set; }
        internal static DeviceModel Device { get; set; }

        #region Data
        static HubConnection connection;
        #endregion

        #region Ctor
        static St()
        {
            #region Hub
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/mylocalhub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography");
            string guid = key.GetValue("MachineGUID").ToString();

            try
            {
                connection.InvokeAsync("DeviceLoginAsync", guid);
            }
            catch (Exception ex)
            {
            }

            #region OnHub
            LoginStatu();
            #endregion
            #endregion

            //todo Device Kaydedici
            //if (realm.All<DeviceModel>().Count() > 0)
            //{
            //    Device = realm.All<DeviceModel>().First();
            //}
            ////todo if ana makine mi
            //realm.Write(() =>
            //{
            //    DateTimeOffset Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).Date;
            //    //Bugünün verisini al yoksa oluştur
            //    if (realm.All<DailyModel>().Where(i => i.Date == Date).Count() >= 1)
            //    {
            //        Today = realm.All<DailyModel>().Where(i => i.Date == Date).First();
            //    }
            //    else
            //    {
            //        Today = realm.Add(new DailyModel());
            //    }
            //});
        }
        #endregion

        #region Hub
        public static async void LoginStatu()
        {
            connection.On<string>("deviceLogin", (message) =>
            {
                string newMessage = $"{message}";
                messagesList.Add(newMessage);
                if (message == "mustafa")
                {
                    Nv.SetContent(Nv.MainMenu);
                }
            });

            try
            {
                await connection.StartAsync();
                messagesList.Add("Connection started");
            }
            catch (Exception ex)
            {
                messagesList.Add(ex.Message);
            }
        }
        #endregion
    }
}
