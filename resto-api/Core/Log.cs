namespace resto_api.Core
{
    public class Log : ILog
    {
        private string pathlog;
        private string cache = "";

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

            try
            {
                using (StreamWriter sw = File.AppendText(pathlog))
                {
                    if (cache != "")
                    {
                        sw.WriteLine(cache);
                        cache = "";
                    }
                    sw.WriteLine($"api:{DateTime.Now}: {msg}");
                }
            }
            catch (Exception)
            {
                cache += $"wpf:{DateTime.Now}: {msg} \n";
            }
        }
    }
}
