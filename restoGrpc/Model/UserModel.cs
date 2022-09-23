using MongoDB.Bson;
using ProtoBuf;
using Realms;

namespace restoGrpc.Model
{
    [ProtoContract]
    public class UserModel : RealmObject
    {
        [PrimaryKey]
        [ProtoMember(1)]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        [ProtoMember(2)]
        public string? UserName { get; set; }
        [ProtoMember(3)]
        public int Password { get; set; }
        [ProtoMember(4)]
        public int Auth { get; set; }
        [ProtoMember(5)]
        public bool IsActive { get; set; }

        [ProtoMember(6)]
        public IList<ProductGroupModel> productGroups { get; } = new List<ProductGroupModel>();

        [ProtoIgnore]
        public int Ignore { get; set; }
    }
}
