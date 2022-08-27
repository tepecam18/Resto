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
        #region Data
        static HubConnection connection;
        #endregion

        #region Ctor
        static Hub()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/mylocalhub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            #region OnHub
            LoginStatu();
            #endregion
        }
        #endregion

        #region OnHub
        public static async void LoginStatu()
        {
            connection.On<string>("deviceLogin", (message) =>
            {
                string newMessage = $"{message}";
                Log.Write(newMessage);
                if (message == "mustafa")
                {
                    Nv.SetContent(Nv.MainMenu);
                }
            });

            try
            {
                await connection.StartAsync();
                Log.Write("Connection started");
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
