using System.Threading.Tasks;

using DayInNode.WebAPI.Entities;
using DayInNode.WebAPI.Entities.Objects;

using Microsoft.AspNetCore.Mvc;

namespace DayInNode.WebAPI.Controllers {
    public class TestSQLServerController : BaseController {
        private readonly EntityFactory _context;

        public TestSQLServerController(EntityFactory context) {
            _context = context;
        }

        [HttpGet]
        public async Task<string> Get(int id) {
            var post = new Posts {
                Likes = id
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return "OK";
        }
    }
}