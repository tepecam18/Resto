﻿using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class CostumeThemeModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string Color { get; set; }
        public bool IsDefault { get; set; }
    }
}
