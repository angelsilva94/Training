namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        pwd = c.String(nullable: false),
                        name = c.String(nullable: false),
                        email = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        regDate = c.DateTime(nullable: false),
                        userType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserModels");
        }
    }
}
