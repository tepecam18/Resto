﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;
using resto_api.Static;

namespace resto_api.Model
{
    public class DeviceModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? MachineGuid { get; set; }
        public string? MachineName { get; set; }
        public bool IsActive { get; set; }


        [BsonIgnore]
        public string? Token { get; set; }
        [BsonIgnore]
        public string? PrivateKey { get; set; }

        [BsonIgnore]
        public UsersModel? User { get; set; }
    }
}