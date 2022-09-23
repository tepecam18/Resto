
using Grpc.Core;
using Realms;
using restoGrpc.Core;
using restoGrpc.Model;

namespace restoGrpc.Services
{
    public class RestoService : Resto.RestoBase
    {
        public ILog Log { get; }
        public Realm realm { get; set; }

        public RestoService(ILog log)
        {
            Log=log;
            realm = Realm.GetInstance(new RealmConfig());
        }

        public override async Task<Response> Login(LoginRequest request, ServerCallContext context)
        {
            if (realm.All<UserModel>().SingleOrDefault(i=> i.Password == request.Pin) is not null)
            {
                return new Response
                {
                    Message = "Login success",
                    Statu = 200,
                };
            }
            return new Response
            {
                Message = "Kullanıcı Bulunamadı",
                Statu = 400,
            };
        }

        //public override Task<Response> AddUser(UserRequest request, ServerCallContext context)
        //{
        //    realm.Add<UserModel>(request);
        //}
    }
}
