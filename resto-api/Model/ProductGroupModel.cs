using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.Model
{
    public class ProductGroupModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? GroupName { get; set; }
        public bool IsActive { get; set; }
        public int Location { get; set; }
        public IList<ProductModel> Products { get; }
    }
}
