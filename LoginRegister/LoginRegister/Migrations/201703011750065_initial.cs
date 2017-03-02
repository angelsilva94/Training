namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandModels",
                c => new
                    {
                        brandId = c.Int(nullable: false, identity: true),
                        brandName = c.String(nullable: false),
                        brandLogoUrl = c.String(nullable: false),
                        brandDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.brandId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        productName = c.String(nullable: false),
                        productDesc = c.String(nullable: false),
                        productPrice = c.Double(nullable: false),
                        productUrl = c.String(nullable: false),
                        productPublishDate = c.DateTime(nullable: false),
                        productModifyDate = c.DateTime(nullable: false),
                        productStatus = c.Boolean(nullable: false),
                        productStock = c.Int(nullable: false),
                        productBrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.BrandModels", t => t.productBrandId, cascadeDelete: true)
                .Index(t => t.productBrandId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        orderProductId = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        orderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderProductId)
                .ForeignKey("dbo.Orders", t => t.orderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId)
                .Index(t => t.orderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        purchaseDate = c.DateTime(nullable: false),
                        orderStatusCode = c.Int(nullable: false),
                        quantityOrder = c.Int(nullable: false),
                        totalOrderPrice = c.Int(nullable: false),
                        orderUsername = c.String(nullable: false, maxLength: 128),
                        OrderStatusModel_orderStatusCod = c.Int(),
                    })
                .PrimaryKey(t => t.orderId)
                .ForeignKey("dbo.UserModels", t => t.orderUsername, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatusModels", t => t.OrderStatusModel_orderStatusCod)
                .Index(t => t.orderUsername)
                .Index(t => t.OrderStatusModel_orderStatusCod);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        password = c.String(nullable: false),
                        name = c.String(nullable: false),
                        email = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        regDate = c.DateTime(nullable: false),
                        userType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.username);
            
            CreateTable(
                "dbo.ReviewProducts",
                c => new
                    {
                        productId = c.Int(nullable: false),
                        reviewUsername = c.String(nullable: false, maxLength: 128),
                        reviewId = c.Int(nullable: false),
                        ratingReview = c.Int(nullable: false),
                        reviewDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.productId, t.reviewUsername })
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.reviewUsername, cascadeDelete: true)
                .Index(t => t.productId)
                .Index(t => t.reviewUsername);
            
            CreateTable(
                "dbo.UserInfoModels",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        phone = c.String(nullable: false),
                        adress = c.String(nullable: false),
                        country = c.String(nullable: false),
                        city = c.String(nullable: false),
                        zip = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.username)
                .ForeignKey("dbo.UserModels", t => t.username)
                .Index(t => t.username);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        categoryId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.categoryId, t.productId })
                .ForeignKey("dbo.CategoryModels", t => t.categoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.categoryId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        categoryName = c.String(nullable: false),
                        categoryDesc = c.String(nullable: false),
                        categoryImage = c.String(nullable: false),
                        categoryParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.categoryId)
                .ForeignKey("dbo.CategoryModels", t => t.categoryParentId)
                .Index(t => t.categoryParentId);
            
            CreateTable(
                "dbo.OrderStatusModels",
                c => new
                    {
                        orderStatusCod = c.Int(nullable: false, identity: true),
                        orderStatusDesc = c.String(),
                    })
                .PrimaryKey(t => t.orderStatusCod);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderStatusModel_orderStatusCod", "dbo.OrderStatusModels");
            DropForeignKey("dbo.ProductCategories", "productId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "categoryId", "dbo.CategoryModels");
            DropForeignKey("dbo.CategoryModels", "categoryParentId", "dbo.CategoryModels");
            DropForeignKey("dbo.OrderProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "orderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "orderUsername", "dbo.UserModels");
            DropForeignKey("dbo.UserInfoModels", "username", "dbo.UserModels");
            DropForeignKey("dbo.ReviewProducts", "reviewUsername", "dbo.UserModels");
            DropForeignKey("dbo.ReviewProducts", "productId", "dbo.Products");
            DropForeignKey("dbo.Products", "productBrandId", "dbo.BrandModels");
            DropIndex("dbo.CategoryModels", new[] { "categoryParentId" });
            DropIndex("dbo.ProductCategories", new[] { "productId" });
            DropIndex("dbo.ProductCategories", new[] { "categoryId" });
            DropIndex("dbo.UserInfoModels", new[] { "username" });
            DropIndex("dbo.ReviewProducts", new[] { "reviewUsername" });
            DropIndex("dbo.ReviewProducts", new[] { "productId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusModel_orderStatusCod" });
            DropIndex("dbo.Orders", new[] { "orderUsername" });
            DropIndex("dbo.OrderProducts", new[] { "orderId" });
            DropIndex("dbo.OrderProducts", new[] { "productId" });
            DropIndex("dbo.Products", new[] { "productBrandId" });
            DropTable("dbo.OrderStatusModels");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.UserInfoModels");
            DropTable("dbo.ReviewProducts");
            DropTable("dbo.UserModels");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Products");
            DropTable("dbo.BrandModels");
        }
    }
}
