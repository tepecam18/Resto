using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        [BsonIgnore]
        public DeviceModel? Device { get; set; }
        [BsonIgnore]
        public UsersModel? SalesPerson { get; set; }
        [BsonIgnore]
        public UsersModel? WaiterPerson { get; set; }
        [BsonIgnore]
        public UsersModel? PaymantPerson { get; set; }
        [BsonElement]
        public IList<OrderProductModel>? Products { get; }
        [BsonElement]
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