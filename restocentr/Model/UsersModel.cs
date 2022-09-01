namespace restocentr.Model
{
    public class UsersModel
    {
        public string ObjectId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Auth { get; set; }
        public bool IsActive { get; set; }

    }
}

//realm.Write(() =>
//{
//    realm.Add(new UsersModel()
//    {
//        UserName = "test",
//        Password = "123"
//    });
//});