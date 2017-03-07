namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _131 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewProducts", "ReviewProductId", c => c.Int(nullable: false));
            DropColumn("dbo.ReviewProducts", "reviewId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReviewProducts", "reviewId", c => c.Int(nullable: false));
            DropColumn("dbo.ReviewProducts", "ReviewProductId");
        }
    }
}
