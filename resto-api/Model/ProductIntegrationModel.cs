using MongoDB.Bson;
using Realms;

public class ProductIntegrationModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public ProductModel? Product { get; set; }
}
