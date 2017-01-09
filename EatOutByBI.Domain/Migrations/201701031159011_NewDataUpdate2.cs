namespace EatOutByBI.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NewDataUpdate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.Products",
    c => new
    {
        ProductID = c.Int(nullable: false, identity: true),
        ProductName = c.String(nullable: false, maxLength: 100),
        ProductGroupID = c.Int(nullable: false),
        Amount = c.Int(nullable: false),
        Unit = c.String(),
        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
        Factor1 = c.Int(nullable: false),
        Factor2 = c.Int(nullable: false),
        DateCreated = c.DateTime(nullable: false),
        DateModified = c.DateTime(nullable: false),
    })
    .PrimaryKey(t => t.ProductID)
    .Index(t => t.ProductGroupID);
            AddForeignKey("dbo.Products", "ProductGroupID", "dbo.ProductGroups", "ProductGroupID");
            //CreateTable(
            //    "dbo.SalesOrderItems",
            //    c => new
            //    {
            //        SalesOrderItemId = c.Int(nullable: false, identity: true),
            //        ProductID = c.Int(nullable: false),
            //        Quantity = c.Int(nullable: false),
            //        SalesOrderId = c.Int(nullable: false),
            //        DateCreated = c.DateTime(nullable: false),
            //        DateModified = c.DateTime(nullable: false),
            //        Factor1 = c.Int(nullable: false),
            //        Factor2 = c.Int(nullable: false),
            //    })
            //    .PrimaryKey(t => t.SalesOrderItemId)
            //    .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
            //    .ForeignKey("dbo.SalesOrders", t => t.SalesOrderId, cascadeDelete: true)
            //    .Index(t => t.ProductID)
            //    .Index(t => t.SalesOrderId);

            //CreateTable(
            //    "dbo.SalesOrders",
            //    c => new
            //    {
            //        SalesOrderId = c.Int(nullable: false, identity: true),
            //        CustomerName = c.String(),
            //        SeatID = c.Int(nullable: false),
            //        EmployeeID = c.Int(nullable: false),
            //        PaymentMethodId = c.Int(nullable: false),
            //        DateTime = c.DateTime(nullable: false),
            //        DateCreated = c.DateTime(nullable: false),
            //        DateModified = c.DateTime(nullable: false),
            //        Factor1 = c.Int(nullable: false),
            //        Factor2 = c.Int(nullable: false),
            //        TimeStamp = c.DateTime(nullable: false),
            //    })
            //    .PrimaryKey(t => t.SalesOrderId)
            //    .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
            //    .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
            //    .ForeignKey("dbo.Seats", t => t.SeatID, cascadeDelete: true)
            //    .Index(t => t.SeatID)
            //    .Index(t => t.EmployeeID)
            //    .Index(t => t.PaymentMethodId);

        }

        public override void Down()
        {
            //DropForeignKey("dbo.SalesOrders", "SeatID", "dbo.Seats");
            //DropForeignKey("dbo.SalesOrderItems", "SalesOrderId", "dbo.SalesOrders");
            //DropForeignKey("dbo.SalesOrders", "PaymentMethodId", "dbo.PaymentMethods");
            //DropForeignKey("dbo.SalesOrders", "EmployeeID", "dbo.Employees");
            //DropForeignKey("dbo.SalesOrderItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductGroupID", "dbo.ProductGroups");

            //DropIndex("dbo.SalesOrders", new[] { "PaymentMethodId" });
            //DropIndex("dbo.SalesOrders", new[] { "EmployeeID" });
            //DropIndex("dbo.SalesOrders", new[] { "SeatID" });
            //DropIndex("dbo.SalesOrderItems", new[] { "SalesOrderId" });
            //DropIndex("dbo.SalesOrderItems", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "ProductGroupID" });

            //DropTable("dbo.SalesOrders");
            //DropTable("dbo.SalesOrderItems");
            DropTable("dbo.Products");



        }
    }
}
