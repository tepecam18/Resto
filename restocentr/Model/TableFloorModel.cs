using System.Collections.Generic;

namespace restocentr.Model
{
    public class TableFloorModel
    {
        public string ObjectId { get; set; }
        public string FloorName { get; set; }
        public IList<TableModel> Tables { get; }

    }
}