using restocentr.View;
using System;
using System.IO;
using System.Threading.Tasks;

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
                sw.WriteLine($"wpf:{DateTime.Now}: {msg}");
            }
        }

        public static bool Show(string msg, string btn = "Kapat", int time = 3)
        {
            bool repos = false;
            if (MainWindow.snackbar.MessageQueue is { } messageQueue)
            {
                MainWindow.snackbar.MessageQueue.DiscardDuplicates = true;
                messageQueue.Enqueue(
                msg,
                btn,
                action => repos = true,
                msg,
                false,
                true,
                new(0,0,time));
                return repos;
            }
            return repos;
        }
    }
}
