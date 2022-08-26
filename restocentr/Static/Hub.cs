using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Win32;
using restocentr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography");
                string guid = key.GetValue("MachineGUID").ToString();

                connection.InvokeAsync("DeviceLoginAsync", guid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sunucu Cihaz Kaydı Başarısız: {ex.Message}");
            }

            #region OnHub
            LoginStatu();
            #endregion
        }
        #endregion
    }
}
