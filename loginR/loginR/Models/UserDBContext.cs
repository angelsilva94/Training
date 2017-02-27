using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace loginR.Models {
    public class UsersDBContext : DbContext {
        public UsersDBContext() : base("UsersDBContext") {
        }
        public DbSet<UserModel> Users { get; set; }
    }
}