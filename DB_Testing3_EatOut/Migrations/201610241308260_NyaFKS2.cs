namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NyaFKS2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderRows", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderRows", new[] { "OrderID" });
            RenameColumn(table: "dbo.OrderRows", name: "OrderID", newName: "Order_OrderID");
            AlterColumn("dbo.OrderRows", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.OrderRows", "Order_OrderID");
            AddForeignKey("dbo.OrderRows", "Order_OrderID", "dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.OrderRows", new[] { "Order_OrderID" });
            AlterColumn("dbo.OrderRows", "Order_OrderID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.OrderRows", name: "Order_OrderID", newName: "OrderID");
            CreateIndex("dbo.OrderRows", "OrderID");
            AddForeignKey("dbo.OrderRows", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
    }
}
