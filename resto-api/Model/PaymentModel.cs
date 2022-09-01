﻿using MongoDB.Bson;
using Realms;
namespace resto_api.Modal
{
    public class PaymentModel : EmbeddedObject
{
    public PaymentTypeModel Type { get; set; }
    public Decimal128 Price { get; set; }
}

public class PaymentTypeModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string Name { get; set; }
}
}
