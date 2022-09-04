using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;
namespace resto_api.Modal
{
    public class ProductGroupModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? GroupName { get; set; }
        public bool IsActive { get; set; }
        public int Location { get; set; }

        [BsonElement]
        public IList<ProductModel> Products { get; }
    }
}