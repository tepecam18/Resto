using MongoDB.Bson;
using Realms;
using resto_api.Model;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;

namespace resto_api.Static
{
    //todo https://docs.microsoft.com/tr-tr/dotnet/api/system.security.cryptography.rsacryptoserviceprovider?view=net-7.0
    public static class Ss
    {
        #region Data
        public static List<DeviceModel> Devices { get; set; }
        #endregion

        #region Ctor
        static Ss()
        {
            Devices = new List<DeviceModel>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Device Token for Create Sessions
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        public static RSAParameters CreateDevice(DeviceModel Device)
        {
            Devices.Add(Device);
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSAParameters rSAParameters = RSA.ExportParameters(false);
                string str = rSAParameters.ToString();
                return rSAParameters;
            }
        }

        /// <summary>
        /// Edit is Device user
        /// </summary>
        /// <param name="Device"></param>
        /// <returns></returns>
        public static string EditDevice(UsersModel User)
        {
            //Devices == User;
            return "";
        }
        #endregion
    }

    #region Model
    public class DeviceList
    {
        public DeviceModel Device { get; set; }
        public RSAParameters Token { get; set; }
        public UsersModel User { get; set; }
    }
    #endregion
}
