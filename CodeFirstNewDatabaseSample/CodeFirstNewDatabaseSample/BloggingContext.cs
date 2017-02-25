using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample {
    class BloggingContext : DbContext {
        public DbSet<Blog> blogs { set; get; }
        public DbSet<Post> post { set; get; }
    }
}
