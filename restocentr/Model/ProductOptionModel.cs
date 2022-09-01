using MongoDB.Bson;
using System.Collections.Generic;

namespace restocentr.Model
{
    public class ProductOptionModel
    {
        public ObjectId ID { get; set; }
        public string OptionName { get; set; }
        public IList<ProductModel> Products { get; }
    }
}
