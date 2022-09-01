using MongoDB.Bson;
using Realms;

namespace resto_api.Modal
{
    public class OrderModel : EmbeddedObject
    {

        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public DateTimeOffset DateT { get; set; } = DateTime.Now;
        public string OrderNote { get; set; } = "";
        public bool IsClosed { get; set; }
        public bool IsCanceled { get; set; }
        public CanceledModel? Canceled { get; set; }
        public TableModel? Tables { get; set; }
        public DeviceModel? Device { get; set; }
        public UsersModel? SalesPerson { get; set; }
        public UsersModel? WaiterPerson { get; set; }
        public UsersModel? PaymantPerson { get; set; }
        public IList<OrderProductModel>? Products { get; }
        public IList<PaymentModel>? Payments { get; }


        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                if (Products is not null)
                {
                    foreach (OrderProductModel order in Products)
                    {
                        total += Convert.ToDecimal(order.TotalPrice);
                    }
                }
                return total;
            }
        }
    }
}