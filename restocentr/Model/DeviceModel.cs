using MongoDB.Bson;

namespace restocentr.Model
{
    public class DeviceModel
    {
        public ObjectId ID { get; set; }
        public string MachineGuid { get; set; }
        public string MachineName { get; set; }
        public bool IsMain { get; set; }
    }
}