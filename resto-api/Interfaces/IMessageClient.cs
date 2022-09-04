using resto_api.Modal;

public interface IMessageClient
{

    #region Securty
    Task userLogin(int message);

    Task hataMsg(string message);
    #endregion

    #region Get
    Task getDaily(byte[] daily);

    Task getProduct(string productGroup);
    #endregion
    
    #region Add
    Task addOrder(OrderModel order);

    Task addOrderProduct(OrderProductModel orderproduct);
    #endregion

}
