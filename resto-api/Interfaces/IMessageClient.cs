namespace resto_api.Interfaces
{
    public interface IMessageClient
    {
        Task userLogin(string message);
        Task deviceLogin(string message);
    }
}
