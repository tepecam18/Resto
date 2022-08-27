using Realms;

namespace RestoWPF.Core
{
    internal class RealmConfig : RealmConfiguration
    {
        public RealmConfig()
        {
            //string data = "\"TPCM+PTTS+BJIbyI9LSGWZYY928E+lPJ4szM9bA+EdWHsi6wbWAjn+73F9TxKvTzItUx8ctjqYRHSCmAuKC1UA==\"";
            //MainWindow.encrypt = JsonSerializer.Deserialize<byte[]>(data);

            //if (0 == MainWindow.encrypt[0])
            //{
            //    Random rnd = new Random();
            //    rnd.NextBytes(MainWindow.encrypt);
            //}

            //string p = JsonSerializer.Serialize(MainWindow.encrypt);
            //string p = GetPassword();
            //byte[] p22 = JsonSerializer.Deserialize<byte[]>(p);
            IsReadOnly = false;
            //EncryptionKey = MainWindow.encrypt;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DatabasePath = $"{path}\\Resto.json";
            //todo realm dosyalarını sili kapat
            ShouldDeleteIfMigrationNeeded = true;
        }

        //static private string GetPassword()
        //{
        //    return BitConverter.ToString(MainWindow.encrypt).Replace("-", string.Empty);
        //}
    }
}
