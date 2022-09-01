using MongoDB.Bson;
using Realms;
namespace resto_api.Modal
{
    public class ProductIntegrationModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public ProductModel? Product { get; set; }
}
}
