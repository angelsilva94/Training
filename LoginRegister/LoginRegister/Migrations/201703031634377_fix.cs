namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfoes", "username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "username", c => c.String(nullable: false));
        }
    }
}
