using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;
using MongoDB.Driver;

namespace DayInNode.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class TestController : Controller {       
        [HttpGet]
        public async Task<string> Get(int id) {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("day2innode");
            
            var collection = database.GetCollection<BsonDocument>("posts");

            var document = new BsonDocument { 
                { "id", id },
                { "likes", 2 }
            };

            await collection.InsertOneAsync(document);
            
            return "OK";         
        }    
    }
}