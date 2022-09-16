using MongoDB.Bson;
using Realms;

namespace restoGrpc.Model
{
    public class ProductGroupModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    }
}
