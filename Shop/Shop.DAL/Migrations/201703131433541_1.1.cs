namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "userMode", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "userType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "userType", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "userMode");
        }
    }
}
