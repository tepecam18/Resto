using System.Collections.Generic;

namespace restocentr.Model
{
    public class ProductGroupModel
    {
        public string ID { get; set; }
        public string? GroupName { get; set; }
        public bool IsActive { get; set; }
        public int Location { get; set; }
        public IList<ProductModel> Products { get; }
    }
}
