using MongoDB.Bson;
using Realms;

namespace resto_api.Model
{
    public class ProductGroupModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? GroupName { get; set; }
        public bool IsActive { get; set; }
        public int Location { get; set; }
        public IList<ProductModel> Products { get; }
    }
}
