﻿using MongoDB.Bson;
using Realms;

namespace RestoWPF.Model
{
    public class DeviceModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? MachineGuid { get; set; }
        public string? MachineName { get; set; }
        public bool IsMain { get; set; }
    }
}