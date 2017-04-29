namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _10 : DbMigration
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
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        quantityOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
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
                        totalOrderPrice = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        Address_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.OrderStatus", t => t.orderStatusCode, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.orderStatusCode)
                .Index(t => t.UserId)
                .Index(t => t.Address_AddressId);

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
                        userMode = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        street = c.String(nullable: false),
                        adress = c.String(nullable: false),
                        country = c.String(nullable: false),
                        city = c.String(nullable: false),
                        zip = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.ReviewProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ReviewProductIdNumber = c.Int(nullable: false, identity: true),
                        ratingReview = c.Double(nullable: false),
                        reviewDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewProductIdNumber)
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
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        type = c.String(nullable: false),
                        typeDesc = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserTypeId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ProductCategoryId)
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
                        categoryParentId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.categoryParentId)
                .Index(t => t.categoryParentId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "categoryParentId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.UserTypes", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReviewProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ReviewProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Addresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "orderStatusCode", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Categories", new[] { "categoryParentId" });
            DropIndex("dbo.ProductCategories", new[] { "ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "CategoryId" });
            DropIndex("dbo.UserTypes", new[] { "UserId" });
            DropIndex("dbo.UserInfoes", new[] { "UserId" });
            DropIndex("dbo.ReviewProducts", new[] { "UserId" });
            DropIndex("dbo.ReviewProducts", new[] { "ProductId" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "Address_AddressId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "orderStatusCode" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.Categories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.ReviewProducts");
            DropTable("dbo.Addresses");
            DropTable("dbo.Users");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}