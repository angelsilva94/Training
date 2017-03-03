using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ShopDBContext : DbContext {
        public ShopDBContext() : base("name=UserDBContext") {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

        }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { set; get; }
        public DbSet<Brand> Brand { set; get; }
        public DbSet<Category> Category { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<OrderProduct> OrderProduct { set; get; }
        public DbSet<OrderStatus> OrderStatus { set; get; }
        public DbSet<ProductCategory> ProductCategory { set; get; }
        public DbSet<ReviewProduct> ReviewProduct { set; get; }
        public DbSet<UserInfo> UserInfo { set; get; }
        
    }
}