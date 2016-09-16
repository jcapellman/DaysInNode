using System.Threading.Tasks;

using StackExchange.Redis;

using Microsoft.AspNetCore.Mvc;

namespace DayInNode.WebAPI.Controllers {
    public class TestController : BaseController {
        private static ConnectionMultiplexer redis;
        private IDatabase db;

        [HttpGet]
        public async Task<string> Get(int id) {
            if (redis == null) {
                redis = ConnectionMultiplexer.Connect("localhost");
            }

            if (db == null) {
                db = redis.GetDatabase();
            }

            await db.StringSetAsync(id.ToString(), 2, flags: CommandFlags.FireAndForget);

            return "OK";
        }
    }
}