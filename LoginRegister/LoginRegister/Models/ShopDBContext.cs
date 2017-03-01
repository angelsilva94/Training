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
        public DbSet<ProductModel> ProductModel { set; get; }
        public DbSet<BrandModel> BrandModel { set; get; }
        public DbSet<CategoryModel> CategoryModel { set; get; }
        public DbSet<OrderModel> OrderModel { set; get; }
        public DbSet<OrderProductModel> OrderProductModel { set; get; }
        public DbSet<OrderStatusModel> OrderStatusModel { set; get; }
        public DbSet<ProductCategoryModel> ProductCategoryModel { set; get; }
        public DbSet<ReviewProductModel> ReviewProductModel { set; get; }
        public DbSet<UserInfoModel> UserInfoModel { set; get; }

    }
}