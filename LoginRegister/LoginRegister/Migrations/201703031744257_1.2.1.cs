namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _121 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "totalOrderPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "totalOrderPrice", c => c.Int(nullable: false));
        }
    }
}
