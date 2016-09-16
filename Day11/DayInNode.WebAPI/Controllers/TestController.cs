using System.Threading.Tasks;

using StackExchange.Redis;

using Microsoft.AspNetCore.Mvc;

namespace DayInNode.WebAPI.Controllers {
    public class TestController : BaseController {
        [HttpGet]
        public async Task<string> Get(int id) {
            var redis = ConnectionMultiplexer.Connect("localhost");

            var db = redis.GetDatabase();

            await db.StringSetAsync(id.ToString(), 2);
            
            return "OK";
        }
    }
}