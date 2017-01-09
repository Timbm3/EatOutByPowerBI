namespace EatOutByBI.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SalesOrderEtc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.PaymentMethods",
    c => new
    {
        PaymentMethodId = c.Int(nullable: false, identity: true),
        PaymentMethodType = c.String(),
        Factor1 = c.Int(nullable: false),
        Factor2 = c.Int(nullable: false),
    })
    .PrimaryKey(t => t.PaymentMethodId);






            CreateTable(
    "dbo.SalesOrderItems",
    c => new
    {
        SalesOrderItemId = c.Int(nullable: false, identity: true),
        ProductID = c.Int(nullable: false),
        Quantity = c.Int(nullable: false),
        SalesOrderId = c.Int(nullable: false),
        DateCreated = c.DateTime(nullable: false),
        DateModified = c.DateTime(nullable: false),
        Factor1 = c.Int(nullable: false),
        Factor2 = c.Int(nullable: false),
    })
    .PrimaryKey(t => t.SalesOrderItemId)
    //.ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
    //.ForeignKey("dbo.SalesOrders", t => t.SalesOrderId, cascadeDelete: true)
    .Index(t => t.ProductID)
    .Index(t => t.SalesOrderId);
            AddForeignKey("dbo.SalesOrderItems", "ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.SalesOrderItems", "SalesOrderId", "dbo.SalesOrders", "SalesOrderId");

            CreateTable(
                "dbo.SalesOrders",
                c => new
                {
                    SalesOrderId = c.Int(nullable: false, identity: true),
                    CustomerName = c.String(),
                    SeatID = c.Int(nullable: false),
                    EmployeeID = c.Int(nullable: false),
                    PaymentMethodId = c.Int(nullable: false),
                    DateTime = c.DateTime(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    DateModified = c.DateTime(nullable: false),
                    Factor1 = c.Int(nullable: false),
                    Factor2 = c.Int(nullable: false),
                    TimeStamp = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.SalesOrderId)
                //.ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                //.ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                //.ForeignKey("dbo.Seats", t => t.SeatID, cascadeDelete: true)
                .Index(t => t.SeatID)
                .Index(t => t.EmployeeID)
                .Index(t => t.PaymentMethodId);
            AddForeignKey("dbo.SalesOrders", "EmployeeID", "dbo.Employees", "EmployeeID");
            AddForeignKey("dbo.SalesOrders", "PaymentMethodId", "dbo.PaymentMethods", "PaymentMethodId");
            AddForeignKey("dbo.SalesOrders", "SeatID", "dbo.Seats", "SeatID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.SalesOrders", "SeatID", "dbo.Seats");
            DropForeignKey("dbo.SalesOrderItems", "SalesOrderId", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.SalesOrders", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.SalesOrderItems", "ProductID", "dbo.Products");

            DropIndex("dbo.SalesOrders", new[] { "PaymentMethodId" });
            DropIndex("dbo.SalesOrders", new[] { "EmployeeID" });
            DropIndex("dbo.SalesOrders", new[] { "SeatID" });
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrderId" });
            DropIndex("dbo.SalesOrderItems", new[] { "ProductID" });


            DropTable("dbo.SalesOrders");
            DropTable("dbo.SalesOrderItems");


            DropTable("dbo.PaymentMethods");


        }
    }
}
