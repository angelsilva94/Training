namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfoes", "UserInfoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "UserInfoId", c => c.Int(nullable: false));
        }
    }
}
