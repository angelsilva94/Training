namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ReviewProducts");
            AddColumn("dbo.ReviewProducts", "ReviewProductIdNumber", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReviewProducts", "ReviewProductIdNumber");
            DropColumn("dbo.ReviewProducts", "ReviewProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReviewProducts", "ReviewProductId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ReviewProducts");
            DropColumn("dbo.ReviewProducts", "ReviewProductIdNumber");
            AddPrimaryKey("dbo.ReviewProducts", "ReviewProductId");
        }
    }
}
