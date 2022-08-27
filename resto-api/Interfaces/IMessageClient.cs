public interface IMessageClient
{

    #region Securty
    Task deviceLogin(string message);

    Task userLogin(string message);
    #endregion

    #region Orders
    Task addOrder(OrderModel order);

    Task addOrderProduct(OrderProductModel orderproduct);
    #endregion

}
