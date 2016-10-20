namespace DB_Testing3_EatOut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        OrderRowID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderRowID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        SeatID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        TimeTableID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatID, cascadeDelete: true)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableID, cascadeDelete: true)
                .Index(t => t.SeatID)
                .Index(t => t.EmployeeID)
                .Index(t => t.TimeTableID);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatID = c.Int(nullable: false, identity: true),
                        TableNr = c.Int(nullable: false),
                        Bar = c.Boolean(nullable: false),
                        Outside = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SeatID);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        TimeTableID = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        YearWeekNumber = c.Int(nullable: false),
                        MonthName = c.String(),
                        MonthDay = c.Int(nullable: false),
                        WeekDay = c.String(),
                        TimeStamp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimeTableID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        OrderRowID = c.Int(nullable: false),
                        ProductTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.OrderRows", t => t.OrderRowID, cascadeDelete: true)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID, cascadeDelete: true)
                .Index(t => t.OrderRowID)
                .Index(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.Products", "OrderRowID", "dbo.OrderRows");
            DropForeignKey("dbo.Orders", "TimeTableID", "dbo.TimeTables");
            DropForeignKey("dbo.Orders", "SeatID", "dbo.Seats");
            DropForeignKey("dbo.OrderRows", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Products", new[] { "ProductTypeID" });
            DropIndex("dbo.Products", new[] { "OrderRowID" });
            DropIndex("dbo.Orders", new[] { "TimeTableID" });
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.Orders", new[] { "SeatID" });
            DropIndex("dbo.OrderRows", new[] { "OrderID" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.TimeTables");
            DropTable("dbo.Seats");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
            DropTable("dbo.Employees");
        }
    }
}
