namespace Login.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        usr = c.String(nullable: false, maxLength: 128),
                        pwd = c.String(),
                        name = c.String(),
                        surname = c.String(),
                        lastname = c.String(),
                        regDate = c.DateTime(nullable: false),
                        userType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.usr);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
