using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace restocentr.Static
{
    internal static class Log
    {
        private static string pathlog;

        static Log()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            pathlog = $"{path}\\MyLog.txt";

            if (!File.Exists(pathlog))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(pathlog))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }
        }

        public static void Write(string msg)
        {
            using (StreamWriter sw = File.AppendText(pathlog))
            {
                sw.WriteLine($"{DateTime.Now} : {msg}");
            }
        }

    }
}
