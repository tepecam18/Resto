using MongoDB.Bson;

namespace restocentr.Model
{
    public class ProductIntegrationModel
    {
        public ObjectId ID { get; set; }
        public ProductModel Product { get; set; }
    }
}
