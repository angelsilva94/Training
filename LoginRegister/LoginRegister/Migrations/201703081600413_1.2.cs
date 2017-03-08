namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
