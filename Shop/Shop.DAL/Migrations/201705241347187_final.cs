namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropColumn("dbo.Products", "BrandId");
            DropTable("dbo.Brands");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Products", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "BrandId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "BrandId", cascadeDelete: true);
        }
    }
}
