namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "categoryParent_CategoryId" });
            DropColumn("dbo.Categories", "categoryParentId");
            RenameColumn(table: "dbo.Categories", name: "categoryParent_CategoryId", newName: "categoryParentId");
            AlterColumn("dbo.Categories", "categoryParentId", c => c.Int());
            CreateIndex("dbo.Categories", "categoryParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "categoryParentId" });
            AlterColumn("dbo.Categories", "categoryParentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Categories", name: "categoryParentId", newName: "categoryParent_CategoryId");
            AddColumn("dbo.Categories", "categoryParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "categoryParent_CategoryId");
        }
    }
}
