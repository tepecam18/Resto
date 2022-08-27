namespace resto_api.Core
{
    public class Log : ILog
    {
        private string pathlog;

        public Log()
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

        public void Write(string msg)
        {
            using (StreamWriter sw = File.AppendText(pathlog))
            {
                sw.WriteLine($"api:{DateTime.Now}: {msg}");
            }
        }
    }
}
