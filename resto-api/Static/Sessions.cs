using resto_api.Model;

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
            //Devices.add
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
