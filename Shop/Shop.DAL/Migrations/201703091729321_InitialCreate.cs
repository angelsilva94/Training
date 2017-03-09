namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        brandName = c.String(nullable: false),
                        brandLogoUrl = c.String(nullable: false),
                        brandDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        productName = c.String(nullable: false),
                        productDesc = c.String(nullable: false),
                        productPrice = c.Double(nullable: false),
                        productUrl = c.String(nullable: false),
                        productPublishDate = c.DateTime(nullable: false),
                        productModifyDate = c.DateTime(nullable: false),
                        productStatus = c.Boolean(nullable: false),
                        productStock = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderProductId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderProductId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        purchaseDate = c.DateTime(nullable: false),
                        orderStatusCode = c.Int(nullable: false),
                        quantityOrder = c.Int(nullable: false),
                        totalOrderPrice = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.OrderStatus", t => t.orderStatusCode, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.orderStatusCode)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        orderStatusCod = c.Int(nullable: false, identity: true),
                        orderStatusDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.orderStatusCod);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                        name = c.String(nullable: false),
                        email = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        regDate = c.DateTime(nullable: false),
                        userType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ReviewProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ReviewProductId = c.Int(nullable: false),
                        ratingReview = c.Int(nullable: false),
                        reviewDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.UserId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        phone = c.String(nullable: false),
                        adress = c.String(nullable: false),
                        country = c.String(nullable: false),
                        city = c.String(nullable: false),
                        zip = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.ProductId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        categoryName = c.String(nullable: false),
                        categoryDesc = c.String(nullable: false),
                        categoryImage = c.String(nullable: false),
                        categoryParentId = c.Int(nullable: false),
                        categoryParent_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.categoryParent_CategoryId)
                .Index(t => t.categoryParent_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "categoryParent_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.UserInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReviewProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReviewProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "orderStatusCode", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Categories", new[] { "categoryParent_CategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "CategoryId" });
            DropIndex("dbo.UserInfoes", new[] { "UserId" });
            DropIndex("dbo.ReviewProducts", new[] { "UserId" });
            DropIndex("dbo.ReviewProducts", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "orderStatusCode" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.Categories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.ReviewProducts");
            DropTable("dbo.Users");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
