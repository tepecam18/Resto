using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace restocentr.Static
{
    internal static class Hub
    {
        #region Data
        static HubConnection connection;
        #endregion

        #region Ctor
        static Hub()
        {
            //todo url parametre üzerinden al
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/mylocalhub")
                .Build();

            connection.Closed += (error) =>
            {
                Log.Write(error.Message);
                HubClosed();
                return Task.CompletedTask;
            };

            #region OnHub
            DeviceStatu();
            UserStatu();
            #endregion
        }

        public static void DeviceLogin()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography");
                string deviceID = key.GetValue("MachineGUID").ToString();

                Hub.DeviceLogin(deviceID);
            }
            catch (Exception ex)
            {
                Log.Write($"Sunucu Cihaz Kaydı Başarısız: {ex.Message}");
            }
        }

        public static void HubClosed()
        {
            Log.ShowAsync(
                "Sunucuyla Bağlantı Koptu.",
                sa =>
                {
                    Task.Delay(new Random().Next(0, 5) * 1000);
                    try
                    {
                        connection.StartAsync();
                        DeviceLogin();
                    }
                    catch (Exception ex)
                    {
                        Log.Write(ex.Message);
                        HubClosed();
                    }
                },
                "Tekrar Bağlan",
                10);
        }
        #endregion

        #region OnHub
        public static async void DeviceStatu()
        {
            connection.On<string>("deviceLogin", (message) =>
            {
                if (message == "Ok")
                {
                }
                //todo cihaz kaydedilsin
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                //todo tekrar denensin mi
                //todo bulut sunucu üderinden ip adresini alarak bağlan
                Log.ShowAsync("Sunucuyla Bağlantı Kurulamadı");
                Log.Write(ex.Message);
            }
        }

        public static async void UserStatu()
        {
            connection.On<string>("userLogin", message =>
            {
                switch (message)
                {
                    case "Ok":
                        Nv.SetContent(Nv.MainMenu);
                        break;
                    case "NotUser":
                        Log.ShowAsync("Girile pin hatalıdır");
                        break;
                    case "NotDevice":
                        Log.ShowAsync("Bu cihaz kaydedilmemiş veya aktif değildir");
                        break;
                    default:
                        Nv.SetContent(Nv.Login);
                        break;
                };
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
        private static async void Send(string gool, string param)
        {
            try
            {
                await connection.InvokeAsync(gool, param);
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message);
            }
        }

        public static void DeviceLogin(string deviceID)
        {
            Send("DeviceLoginAsync", deviceID);
        }

        public static void UserLogin(string pin)
        {
            Send("UserLoginAsync", pin);
        }
        #endregion
    }
}
