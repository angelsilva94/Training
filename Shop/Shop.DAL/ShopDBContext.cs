using Shop.Models.DBModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace LoginRegister.Models {

    public class ShopDBContext : DbContext {

        public ShopDBContext() : base("name=ShopDBContext") {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { set; get; }
        //public DbSet<Brand> Brand { set; get; }
        public DbSet<Category> Category { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<OrderStatus> OrderStatus { set; get; }
        public DbSet<ProductCategory> ProductCategory { set; get; }
        public DbSet<ReviewProduct> ReviewProduct { set; get; }
        public DbSet<UserInfo> UserInfo { set; get; }

        public System.Data.Entity.DbSet<Shop.Models.DBModel.UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryId).
                Property(x => x.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Category>().HasOptional(x => x.categoryParent).WithMany().HasForeignKey(x => x.categoryParentId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>().HasMany(x => x.ProductCategories).WithRequired(x => x.Category).HasForeignKey(x=>x.CategoryId);
            modelBuilder.Entity<Product>().HasMany(x => x.ProductCategories).WithRequired(x => x.Product).HasForeignKey(x => x.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}