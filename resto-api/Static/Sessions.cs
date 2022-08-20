using MongoDB.Bson;
using Realms;
using resto_api.Abstract;
using resto_api.Model;
using RestoWPF.Core;
using System.Security.Cryptography;

namespace resto_api.Static
{
    //todo https://docs.microsoft.com/tr-tr/dotnet/api/system.security.cryptography.rsacryptoserviceprovider?view=net-7.0
    public static class Ss 
    {
        #region Data
        static Realm realm = Realm.GetInstance(new RealmConfig());

        public static List<DeviceModel> Devices { get; set; }
        #endregion

        #region Ctor
        static Ss()
        {
            Devices = new List<DeviceModel>();
        }
        #endregion

        #region Properties

        public static string LoginDevice(DeviceModel device)
        {
            Devices.Add(CreateDevice(device));
            return device.Token;
        }

        public static DeviceModel CreateDevice(DeviceModel device)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSAParameters rSAParametersPublic = RSA.ExportParameters(false);
                RSAParameters rSAParametersPrivete = RSA.ExportParameters(true);

                realm.Write(() =>
                {
                    device.Token = rSAParametersPublic.ToJson();
                    device.PrivateKey = rSAParametersPrivete.ToJson();
                });
                return device;
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
    public class TokenModel
    {
        public object D { get; set; }
        public object DP { get; set; }
        public object DQ { get; set; }
        public object Exponent { get; set; }
        public object InverseQ { get; set; }
        public object Modulus { get; set; }
        public object P { get; set; }
        public object Q { get; set; }
    }
    #endregion
}
