using MongoDB.Bson;

namespace restocentr.Model
{
    public class CanceledModel
    {
        public ObjectId ID { get; set; }
        public string Note { get; set; } = "";
        public bool IsFavorite { get; set; }
    }
}
