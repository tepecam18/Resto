using resto_api.Model;

namespace resto_api.Abstract
{
    public interface ISessionsBl
    {
        /// <summary>
        /// Device is login
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        string LoginDevice(DeviceModel device);

        /// <summary>
        /// device is create
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        DeviceModel CreateDevice(DeviceModel device);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string EditDevice(UsersModel user);

    }
}
