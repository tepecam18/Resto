using MongoDB.Bson;
using Realms;

public class PaymentModel : EmbeddedObject
{
    public PaymentTypeModel Type { get; set; }
    public Decimal128 Price { get; set; }
}

public class PaymentTypeModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string Name { get; set; }
}
