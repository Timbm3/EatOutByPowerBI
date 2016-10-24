using System.Data.Entity.Migrations;

namespace EatOutByBI.Data.Migrations
{
    public partial class InitialMigrations7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeForms",
                c => new
                    {
                        EmployeeFormID = c.Int(nullable: false, identity: true),
                        EmployeeFormName = c.String(),
                        EmployeeFormOrderRow = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeFormID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmployeeFormID = c.Int(nullable: false),
                        EmployeeTypeID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.EmployeeForms", t => t.EmployeeFormID, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeTypes", t => t.EmployeeTypeID, cascadeDelete: true)
                .Index(t => t.EmployeeFormID)
                .Index(t => t.EmployeeTypeID);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        EmployeeTypeID = c.Int(nullable: false, identity: true),
                        EmployeeTypeName = c.String(),
                        EmployeeTypeOrderRow = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeTypeID);
            
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        OrderRowID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
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
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
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
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
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
                        MonthDay = c.DateTime(nullable: false),
                        WeekDay = c.String(),
                        TimeStamp = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
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
                        ProductGroupID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.OrderRows", t => t.OrderRowID, cascadeDelete: true)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupID, cascadeDelete: true)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID, cascadeDelete: true)
                .Index(t => t.OrderRowID)
                .Index(t => t.ProductTypeID)
                .Index(t => t.ProductGroupID);
            
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        ProductGroupID = c.Int(nullable: false, identity: true),
                        ProductGroupName = c.String(),
                        ProductGroupOrderRow = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductGroupID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        ProductTypeName = c.String(),
                        ProductTypeOrderRow = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.Products", "ProductGroupID", "dbo.ProductGroups");
            DropForeignKey("dbo.Products", "OrderRowID", "dbo.OrderRows");
            DropForeignKey("dbo.Orders", "TimeTableID", "dbo.TimeTables");
            DropForeignKey("dbo.Orders", "SeatID", "dbo.Seats");
            DropForeignKey("dbo.OrderRows", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropForeignKey("dbo.Employees", "EmployeeFormID", "dbo.EmployeeForms");
            DropIndex("dbo.Products", new[] { "ProductGroupID" });
            DropIndex("dbo.Products", new[] { "ProductTypeID" });
            DropIndex("dbo.Products", new[] { "OrderRowID" });
            DropIndex("dbo.Orders", new[] { "TimeTableID" });
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.Orders", new[] { "SeatID" });
            DropIndex("dbo.OrderRows", new[] { "OrderID" });
            DropIndex("dbo.Employees", new[] { "EmployeeTypeID" });
            DropIndex("dbo.Employees", new[] { "EmployeeFormID" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.Products");
            DropTable("dbo.TimeTables");
            DropTable("dbo.Seats");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeForms");
        }
    }
}
