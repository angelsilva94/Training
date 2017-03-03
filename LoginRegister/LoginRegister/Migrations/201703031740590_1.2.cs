namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "orderUsername");
            DropColumn("dbo.ReviewProducts", "reviewUsername");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReviewProducts", "reviewUsername", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "orderUsername", c => c.String(nullable: false));
        }
    }
}
