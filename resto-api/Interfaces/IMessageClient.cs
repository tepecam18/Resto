public interface IMessageClient
{

    #region Securty
    Task userLogin(int message);

    Task hataMsg(string message);
    #endregion

    #region Get
    Task getDaily(DailyModel daily);

    Task getProduct(IList<ProductGroupModel> productGroup);
    #endregion
    
    #region Add
    Task addOrder(OrderModel order);

    Task addOrderProduct(OrderProductModel orderproduct);
    #endregion

}
