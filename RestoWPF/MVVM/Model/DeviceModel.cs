using MongoDB.Bson;
using Realms;

namespace RestoWPF.MVVM.Model
{
    public class DeviceModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? MachineGuid { get; set; }
        public bool IsMain { get; set; }
    }
}