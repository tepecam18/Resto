using resto_api.Model;
using System.Security.Cryptography;
using System.Text;

namespace resto_api.Static
{
    public static class Ss
    {
        #region Data
        public static List<DeviceModel> Devices { get; set; }
        #endregion

        #region Properties
        /// <summary>
        /// Device Token for Create Sessions
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        public static string CreateDevice(DeviceModel Device)
        {
            while (true)
            {

            using SHA256 alg = SHA256.Create();
            byte[] data = Encoding.ASCII.GetBytes("Hello, from the .NET Docs!");
            byte[] hash = alg.ComputeHash(data);

            RSAParameters sharedParameters;
            byte[] signedHash;

            // Generate signature
            using (RSA rsa = RSA.Create())
            {
                sharedParameters = rsa.ExportParameters(false);

                RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
                rsaFormatter.SetHashAlgorithm(nameof(SHA256));

                signedHash = rsaFormatter.CreateSignature(hash);
            }
            }

            Devices.Add(Device);
            return "";
        }

        /// <summary>
        /// Edit is Device user
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        public static string EditDevice(DeviceModel Device)
        {
            //Devices.User ==
            return "";
        }
        #endregion
    }
}
