using Microsoft.Win32;
using restocentr.Static;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace restocentr
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
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
    }
}
