using DayInNode.WebAPI.Entities.Objects;

using Microsoft.EntityFrameworkCore;

namespace DayInNode.WebAPI.Entities {
    public class EntityFactory : DbContext {
        public DbSet<Posts> Posts { get; set; }

        public EntityFactory(DbContextOptions<EntityFactory> options) : base(options) { }
    }
}