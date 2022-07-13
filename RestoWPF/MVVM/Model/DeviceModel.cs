using MongoDB.Bson;
using Realms;

namespace RestoWPF.MVVM.Model
{
    public class DeviceModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        //todo device prop(ip mac name model)
        public bool IsMain { get; set; }
    }
}