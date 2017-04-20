namespace Shop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "quantityOrder", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "quantityOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "quantityOrder", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "quantityOrder");
        }
    }
}
