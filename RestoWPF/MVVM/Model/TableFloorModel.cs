﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class TableFloorModel 
    {
        public string ID { get; set; }
        public string? FloorName { get; set; }
        public IList<TableModel>? Tables { get;}

    }
}