﻿using MongoDB.Bson;
using Realms;

public class UsersModel : RealmObject
{
    [PrimaryKey]
    public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public int Auth { get; set; }
    public bool IsActive { get; set; }

}
