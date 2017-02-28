using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ShopDBContext : DbContext {
        public ShopDBContext() : base("name=UserDBContext") {
        }
        public DbSet<UserModel> UsersModel { get; set; }
        public DbSet<ProductModel> ProductsModel { set; get; }

    }
}