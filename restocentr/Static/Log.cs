using restocentr.View;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Threading;

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

        #region SaveMsg
        public static void Write(string msg)
        {
            using (StreamWriter sw = File.AppendText(pathlog))
            {
                sw.WriteLine($"wpf:{DateTime.Now}: {msg}");
            }
        }
        #endregion

        #region ShowMsg
        public static bool ShowAsync(string msg, Action<string> action, string btn = "Kapat", int time = 3)
        {
            bool repos = false;
            MainWindow.snackbar.Dispatcher.Invoke(DispatcherPriority.Send, new Action((delegate
            {
                MainWindow.snackbar.MessageQueue.Clear();

                if (MainWindow.snackbar.MessageQueue is { } messageQueue)
                {
                    messageQueue.Enqueue(
                    msg,
                    btn,
                    action,
                    msg,
                    false,
                    true,
                    new(0, 0, time));
                }
            })));
            return repos;
        }

        public static bool ShowAsync(string msg, string btn = "Kapat", int time = 3)
        {
            bool repos = false;
            MainWindow.snackbar.Dispatcher.Invoke(DispatcherPriority.Send, new Action((delegate
            {
                MainWindow.snackbar.MessageQueue.Clear();

                if (MainWindow.snackbar.MessageQueue is { } messageQueue)
                {
                    messageQueue.Enqueue(
                    msg,
                    btn,
                    action => { },
                    msg,
                    false,
                    true,
                    new(0, 0, time));
                }
            })));
            return repos;
        }

        public static void Show(string msg, string btn = "Kapat", int time = 3)
        {
            MainWindow.snackbar.MessageQueue.Clear();

            if (MainWindow.snackbar.MessageQueue is { } messageQueue)
            {
                messageQueue.Enqueue(
                msg,
                btn,
                action => { },
                msg,
                false,
                true,
                new(0, 0, time));
            }
        }
        #endregion
    }
}
