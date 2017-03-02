namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductModels", "productBrandId", "dbo.BrandModels");
            DropForeignKey("dbo.ReviewProductModels", "productId", "dbo.ProductModels");
            DropForeignKey("dbo.ReviewProductModels", "reviewUsername", "dbo.UserModels");
            DropForeignKey("dbo.UserInfoModels", "username", "dbo.UserModels");
            DropForeignKey("dbo.OrderModels", "orderUsername", "dbo.UserModels");
            DropForeignKey("dbo.OrderProductModels", "orderId", "dbo.OrderModels");
            DropForeignKey("dbo.OrderProductModels", "productId", "dbo.ProductModels");
            DropForeignKey("dbo.CategoryModels", "categoryParentId", "dbo.CategoryModels");
            DropForeignKey("dbo.ProductCategoryModels", "categoryId", "dbo.CategoryModels");
            DropForeignKey("dbo.ProductCategoryModels", "productId", "dbo.ProductModels");
            DropForeignKey("dbo.OrderModels", "OrderStatusModel_orderStatusCod", "dbo.OrderStatusModels");
            DropIndex("dbo.ProductModels", new[] { "productBrandId" });
            DropIndex("dbo.OrderProductModels", new[] { "productId" });
            DropIndex("dbo.OrderProductModels", new[] { "orderId" });
            DropIndex("dbo.OrderModels", new[] { "orderUsername" });
            DropIndex("dbo.OrderModels", new[] { "OrderStatusModel_orderStatusCod" });
            DropIndex("dbo.ReviewProductModels", new[] { "productId" });
            DropIndex("dbo.ReviewProductModels", new[] { "reviewUsername" });
            DropIndex("dbo.UserInfoModels", new[] { "username" });
            DropIndex("dbo.ProductCategoryModels", new[] { "categoryId" });
            DropIndex("dbo.ProductCategoryModels", new[] { "productId" });
            DropIndex("dbo.CategoryModels", new[] { "categoryParentId" });
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
                        totalOrderPrice = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        orderUsername = c.String(nullable: false),
                        OrderStatus_OrderStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatus_OrderStatusId)
                .Index(t => t.UserId)
                .Index(t => t.OrderStatus_OrderStatusId);
            
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
                        reviewId = c.Int(nullable: false),
                        ratingReview = c.Int(nullable: false),
                        reviewUsername = c.String(nullable: false),
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
                        UserInfoId = c.Int(nullable: false),
                        username = c.String(nullable: false),
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
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusId = c.Int(nullable: false, identity: true),
                        orderStatusCod = c.Int(nullable: false),
                        orderStatusDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderStatusId);
            
            DropTable("dbo.BrandModels");
            DropTable("dbo.ProductModels");
            DropTable("dbo.OrderProductModels");
            DropTable("dbo.OrderModels");
            DropTable("dbo.UserModels");
            DropTable("dbo.ReviewProductModels");
            DropTable("dbo.UserInfoModels");
            DropTable("dbo.ProductCategoryModels");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.OrderStatusModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderStatusModels",
                c => new
                    {
                        orderStatusCod = c.Int(nullable: false, identity: true),
                        orderStatusDesc = c.String(),
                    })
                .PrimaryKey(t => t.orderStatusCod);
            
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
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.ProductCategoryModels",
                c => new
                    {
                        categoryId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.categoryId, t.productId });
            
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
                .PrimaryKey(t => t.username);
            
            CreateTable(
                "dbo.ReviewProductModels",
                c => new
                    {
                        productId = c.Int(nullable: false),
                        reviewUsername = c.String(nullable: false, maxLength: 128),
                        reviewId = c.Int(nullable: false),
                        ratingReview = c.Int(nullable: false),
                        reviewDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.productId, t.reviewUsername });
            
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
                "dbo.OrderModels",
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
                .PrimaryKey(t => t.orderId);
            
            CreateTable(
                "dbo.OrderProductModels",
                c => new
                    {
                        orderProductId = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        orderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderProductId);
            
            CreateTable(
                "dbo.ProductModels",
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
                .PrimaryKey(t => t.productId);
            
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
            
            DropForeignKey("dbo.Orders", "OrderStatus_OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.ProductCategories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "categoryParent_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.UserInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReviewProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReviewProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Categories", new[] { "categoryParent_CategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "CategoryId" });
            DropIndex("dbo.UserInfoes", new[] { "UserId" });
            DropIndex("dbo.ReviewProducts", new[] { "UserId" });
            DropIndex("dbo.ReviewProducts", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "OrderStatus_OrderStatusId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Categories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.ReviewProducts");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            CreateIndex("dbo.CategoryModels", "categoryParentId");
            CreateIndex("dbo.ProductCategoryModels", "productId");
            CreateIndex("dbo.ProductCategoryModels", "categoryId");
            CreateIndex("dbo.UserInfoModels", "username");
            CreateIndex("dbo.ReviewProductModels", "reviewUsername");
            CreateIndex("dbo.ReviewProductModels", "productId");
            CreateIndex("dbo.OrderModels", "OrderStatusModel_orderStatusCod");
            CreateIndex("dbo.OrderModels", "orderUsername");
            CreateIndex("dbo.OrderProductModels", "orderId");
            CreateIndex("dbo.OrderProductModels", "productId");
            CreateIndex("dbo.ProductModels", "productBrandId");
            AddForeignKey("dbo.OrderModels", "OrderStatusModel_orderStatusCod", "dbo.OrderStatusModels", "orderStatusCod");
            AddForeignKey("dbo.ProductCategoryModels", "productId", "dbo.ProductModels", "productId", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategoryModels", "categoryId", "dbo.CategoryModels", "categoryId", cascadeDelete: true);
            AddForeignKey("dbo.CategoryModels", "categoryParentId", "dbo.CategoryModels", "categoryId");
            AddForeignKey("dbo.OrderProductModels", "productId", "dbo.ProductModels", "productId", cascadeDelete: true);
            AddForeignKey("dbo.OrderProductModels", "orderId", "dbo.OrderModels", "orderId", cascadeDelete: true);
            AddForeignKey("dbo.OrderModels", "orderUsername", "dbo.UserModels", "username", cascadeDelete: true);
            AddForeignKey("dbo.UserInfoModels", "username", "dbo.UserModels", "username");
            AddForeignKey("dbo.ReviewProductModels", "reviewUsername", "dbo.UserModels", "username", cascadeDelete: true);
            AddForeignKey("dbo.ReviewProductModels", "productId", "dbo.ProductModels", "productId", cascadeDelete: true);
            AddForeignKey("dbo.ProductModels", "productBrandId", "dbo.BrandModels", "brandId", cascadeDelete: true);
        }
    }
}
