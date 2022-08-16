using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;

namespace resto_api.Model
{
    public class DeviceModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? MachineGuid { get; set; }
        public string? MachineName { get; set; }
        public bool IsMain { get; set; }


        [BsonIgnore]
        public string? Token { get; set; }

        [BsonIgnore]
        public UsersModel? User { get; set; }
    }
}