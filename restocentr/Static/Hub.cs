﻿using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Win32;
using restocentr.Model;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Documents;

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
            getOrders();
            getProduct();
            UserStatu();
            HataMsg();

            try
            {
                connection.StartAsync();
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message);
            }
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
        public static void UserStatu()
        {
            connection.On<int>("userLogin", message =>
            {
                if (message == 200)
                {
                    Nv.SetContent(Nv.MainMenu);
                }
            });
        }

        public static void getOrders()
        {
            connection.On<string>("getDaily", message =>
            {
                St.Orders = JsonSerializer.Deserialize<List<OrderModel>>(message);
            });
        }

        public static void getProduct()
        {
            connection.On<string>("getProduct", message =>
            {
                    St.ProductGroup = JsonSerializer.Deserialize<List<ProductGroupModel>>(message);
            });
        }

        public static void HataMsg()
        {
            connection.On<string>("hataMsg", message =>
            {
                Log.ShowAsync(message);
            });
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
                if (gool == "UserLoginAsync")
                {
                    Log.ShowAsync("Sunucuya Bağlantı Başarısız");
                    //todo buluttan ip adres sorgu
                }
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
