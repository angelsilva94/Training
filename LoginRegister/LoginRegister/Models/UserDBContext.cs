using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class UserDBContext : DbContext {
        public UserDBContext() : base("name=UserDBContext") {
        }
        public System.Data.Entity.DbSet<LoginRegister.Models.UserModel> UserModels { get; set; }
        

    }
}