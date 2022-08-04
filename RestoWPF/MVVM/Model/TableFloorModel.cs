using System.Collections.Generic;

namespace RestoWPF.MVVM.Model
{
    public class TableFloorModel
    {
        public string ID { get; set; }
        public string? FloorName { get; set; }
        public IList<TableModel>? Tables { get;}

    }
}