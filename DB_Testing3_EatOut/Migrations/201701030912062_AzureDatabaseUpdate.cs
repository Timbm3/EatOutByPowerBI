namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AzureDatabaseUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookeds", "IsDateAvailable", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.OrderRows", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "SeatID", "dbo.Seats");
            DropForeignKey("dbo.Orders", "TimeTableID", "dbo.TimeTables");
            DropForeignKey("dbo.OrderRows", "ProductID", "dbo.Products");
            DropIndex("dbo.OrderRows", new[] { "ProductID" });
            DropIndex("dbo.OrderRows", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "SeatID" });
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.Orders", new[] { "TimeTableID" });
            DropIndex("dbo.Orders", new[] { "PaymentMethodId" });
            CreateTable(
                "dbo.SalesOrderItems",
                c => new
                {
                    SalesOrderItemId = c.Int(nullable: false, identity: true),
                    ProductId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    SalesOrderId = c.Int(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    DateModified = c.DateTime(nullable: false),
                    Factor1 = c.Int(nullable: false),
                    Factor2 = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.SalesOrderItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SalesOrders", t => t.SalesOrderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SalesOrderId);

            CreateTable(
                "dbo.SalesOrders",
                c => new
                {
                    SalesOrderId = c.Int(nullable: false, identity: true),
                    CustomerName = c.String(),
                    SeatId = c.Int(nullable: false),
                    EmployeeId = c.Int(nullable: false),
                    PaymentMethodId = c.Int(nullable: false),
                    DateTime = c.DateTime(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    DateModified = c.DateTime(nullable: false),
                    Factor1 = c.Int(nullable: false),
                    Factor2 = c.Int(nullable: false),
                    TimeStamp = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.SalesOrderId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .Index(t => t.SeatId)
                .Index(t => t.EmployeeId)
                .Index(t => t.PaymentMethodId);

            AddColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.PaymentMethods", "PaymentMethodType", c => c.String());
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Employees", "Name");
            DropColumn("dbo.PaymentMethods", "PaymentMethods");
            DropColumn("dbo.Products", "Price");
            DropTable("dbo.OrderRows");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookeds", "IsDateAvailable");
            DropColumn("dbo.Bookeds", "IsDateAvailable");
            CreateTable(
    "dbo.Orders",
    c => new
    {
        OrderID = c.Int(nullable: false, identity: true),
        SeatID = c.Int(nullable: false),
        EmployeeID = c.Int(nullable: false),
        TimeTableID = c.Int(nullable: false),
        PaymentMethodId = c.Int(nullable: false),
        DateCreated = c.DateTime(nullable: false),
        DateModified = c.DateTime(nullable: false),
        Factor1 = c.Int(nullable: false),
        Factor2 = c.Int(nullable: false),
        TimeStamp = c.DateTime(nullable: false),
    })
    .PrimaryKey(t => t.OrderID);

            CreateTable(
                "dbo.OrderRows",
                c => new
                {
                    OrderRowID = c.Int(nullable: false, identity: true),
                    ProductID = c.Int(nullable: false),
                    Kvantitet = c.Int(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    DateModified = c.DateTime(nullable: false),
                    Factor1 = c.Int(nullable: false),
                    Factor2 = c.Int(nullable: false),
                    Order_OrderID = c.Int(),
                })
                .PrimaryKey(t => t.OrderRowID);

            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PaymentMethods", "PaymentMethods", c => c.String());
            AddColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.SalesOrders", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.SalesOrderItems", "SalesOrderId", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.SalesOrders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SalesOrderItems", "ProductId", "dbo.Products");
            DropIndex("dbo.SalesOrders", new[] { "PaymentMethodId" });
            DropIndex("dbo.SalesOrders", new[] { "EmployeeId" });
            DropIndex("dbo.SalesOrders", new[] { "SeatId" });
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrderId" });
            DropIndex("dbo.SalesOrderItems", new[] { "ProductId" });
            DropColumn("dbo.Products", "UnitPrice");
            DropColumn("dbo.PaymentMethods", "PaymentMethodType");
            DropColumn("dbo.Employees", "EmployeeName");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.SalesOrderItems");
            CreateIndex("dbo.Orders", "PaymentMethodId");
            CreateIndex("dbo.Orders", "TimeTableID");
            CreateIndex("dbo.Orders", "EmployeeID");
            CreateIndex("dbo.Orders", "SeatID");
            CreateIndex("dbo.OrderRows", "Order_OrderID");
            CreateIndex("dbo.OrderRows", "ProductID");
            AddForeignKey("dbo.OrderRows", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "TimeTableID", "dbo.TimeTables", "TimeTableID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "SeatID", "dbo.Seats", "SeatID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods", "PaymentMethodId", cascadeDelete: true);
            AddForeignKey("dbo.OrderRows", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
        }
    }
}
