using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Win32;
using restocentr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
                    if (MessageBox.Show("Sunucuyla Bağlantı Koptu. Tekrar bağlanmaya çalışılsın mı", "Bağlantı Hatası", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    {
                        Environment.Exit(0);
                    }
                    else
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
                MessageBox.Show("Sunucuyla Bağlantı Kurulamadı");
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
