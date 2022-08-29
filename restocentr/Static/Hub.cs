using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace restocentr.Static
{
    internal static class Hub
    {
        //todo bütün loglar mesaj olarak sunucuya gönderilip silinsin
        #region Data
        static public bool IsDeviceLogin = false;
        static HubConnection connection;
        #endregion

        #region Ctor
        static Hub()
        {
            //todo url parametre üzerinden al
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/mylocalhub")
                .Build();

            connection.Closed += async (error) =>
            {
                while (true)
                {
                    if (Log.Show("Sunucuyla Bağlantı Koptu.", "Tekrar Bağlan", 10))
                    {
                        await Task.Delay(new Random().Next(0, 5) * 1000);
                        try
                        {
                            await connection.StartAsync();
                        }
                        catch (Exception ex)
                        {
                            Log.Write(ex.Message);
                        }
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            };

            #region OnHub
            DeviceStatu();
            UserStatu();
            #endregion
        }
        #endregion

        #region OnHub
        public static async void DeviceStatu()
        {
            connection.On<string>("deviceLogin", (message) =>
            {
                string newMessage = $"{message}";
                if (message == "Ok")
                {
                    IsDeviceLogin = true;
                }
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                //todo tekrar denensin mi
                //todo bulut sunucu üderinden ip adresini alarak bağlan
                Log.Show("Sunucuyla Bağlantı Kurulamadı");
                Log.Write(ex.Message);
            }
        }

        public static async void UserStatu()
        {
            connection.On<string>("userLogin", (message) =>
            {
                string newMessage = $"{message}";
                if (message == "Ok")
                {
                    Nv.SetContent(Nv.MainMenu);
                }
                else
                {
                    Nv.SetContent(Nv.Login);
                }
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message);
            }
        }
        #endregion

        #region InvokeHub
        public static async Task DeviceLogin(string deviceID)
        {
            await connection.InvokeAsync("DeviceLoginAsync", deviceID);
        }

        public static async Task UserLogin(string pin)
        {
            await connection.InvokeAsync("UserLoginAsync", pin);
        }
        #endregion
    }
}
