namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "password", c => c.String(nullable: false));
            DropColumn("dbo.UserModels", "pwd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "pwd", c => c.String(nullable: false));
            DropColumn("dbo.UserModels", "password");
        }
    }
}
