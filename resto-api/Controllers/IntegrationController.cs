using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realms;
using RestoWPF.Core;
using RestoWPF.Model;

namespace resto_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationController : ControllerBase
    {
        Realm realm = Realm.GetInstance(new RealmConfig());

        // GET: api/<ValuesController>
        [HttpGet(Name = "GetUserModel2")]
        public string Get()
        {
            List<TableModel> Table = realm.All<TableModel>().ToList();
            return JsonConvert.SerializeObject(Table);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            realm.Write(() =>
            {
                TableModel Table = new TableModel()
                {
                    Floor = "Kat-1",
                    TableName = "Masa-1"
                };

                realm.Add(Table);
            });
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
