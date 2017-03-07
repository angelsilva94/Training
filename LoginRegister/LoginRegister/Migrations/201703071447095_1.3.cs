namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderStatus_OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.Orders", new[] { "OrderStatus_OrderStatusId" });
            DropColumn("dbo.Orders", "orderStatusCode");
            RenameColumn(table: "dbo.Orders", name: "OrderStatus_OrderStatusId", newName: "orderStatusCode");
            DropPrimaryKey("dbo.OrderStatus");
            AlterColumn("dbo.Orders", "orderStatusCode", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderStatus", "orderStatusCod", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderStatus", "orderStatusCod");
            CreateIndex("dbo.Orders", "orderStatusCode");
            AddForeignKey("dbo.Orders", "orderStatusCode", "dbo.OrderStatus", "orderStatusCod", cascadeDelete: true);
            DropColumn("dbo.OrderStatus", "OrderStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderStatus", "OrderStatusId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Orders", "orderStatusCode", "dbo.OrderStatus");
            DropIndex("dbo.Orders", new[] { "orderStatusCode" });
            DropPrimaryKey("dbo.OrderStatus");
            AlterColumn("dbo.OrderStatus", "orderStatusCod", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "orderStatusCode", c => c.Int());
            AddPrimaryKey("dbo.OrderStatus", "OrderStatusId");
            RenameColumn(table: "dbo.Orders", name: "orderStatusCode", newName: "OrderStatus_OrderStatusId");
            AddColumn("dbo.Orders", "orderStatusCode", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "OrderStatus_OrderStatusId");
            AddForeignKey("dbo.Orders", "OrderStatus_OrderStatusId", "dbo.OrderStatus", "OrderStatusId");
        }
    }
}
