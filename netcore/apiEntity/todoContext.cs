using apiEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace apiEntity {
    public class todoContext : DbContext {
        public todoContext (DbContextOptions<todoContext> options) : base (options) {
        }
        public DbSet<todoModel> TodoItems { get; set; }

    }
}