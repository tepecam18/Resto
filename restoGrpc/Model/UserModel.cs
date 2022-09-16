using MongoDB.Bson;
using Realms;

namespace restoGrpc.Model
{
    public class UserModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int Auth { get; set; }
        public bool IsActive { get; set; }

        public IList<ProductGroupModel> productGroups { get; } = new List<ProductGroupModel>();
    }
}
