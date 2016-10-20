namespace DB_Testing3_EatOut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateCreatedAdded : DbMigration
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
            
            AddColumn("dbo.Employees", "EmployeeFormID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "EmployeeTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderRows", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderRows", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Seats", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Seats", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.TimeTables", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.TimeTables", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ProductGroupID", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductTypes", "ProductTypeName", c => c.String());
            AddColumn("dbo.ProductTypes", "ProductTypeOrderRow", c => c.Int(nullable: false));
            AddColumn("dbo.ProductTypes", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductTypes", "DateModified", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Employees", "EmployeeFormID");
            CreateIndex("dbo.Employees", "EmployeeTypeID");
            CreateIndex("dbo.Products", "ProductGroupID");
            AddForeignKey("dbo.Employees", "EmployeeFormID", "dbo.EmployeeForms", "EmployeeFormID", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes", "EmployeeTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ProductGroupID", "dbo.ProductGroups", "ProductGroupID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductGroupID", "dbo.ProductGroups");
            DropForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropForeignKey("dbo.Employees", "EmployeeFormID", "dbo.EmployeeForms");
            DropIndex("dbo.Products", new[] { "ProductGroupID" });
            DropIndex("dbo.Employees", new[] { "EmployeeTypeID" });
            DropIndex("dbo.Employees", new[] { "EmployeeFormID" });
            DropColumn("dbo.ProductTypes", "DateModified");
            DropColumn("dbo.ProductTypes", "DateCreated");
            DropColumn("dbo.ProductTypes", "ProductTypeOrderRow");
            DropColumn("dbo.ProductTypes", "ProductTypeName");
            DropColumn("dbo.Products", "DateModified");
            DropColumn("dbo.Products", "DateCreated");
            DropColumn("dbo.Products", "ProductGroupID");
            DropColumn("dbo.TimeTables", "DateModified");
            DropColumn("dbo.TimeTables", "DateCreated");
            DropColumn("dbo.Seats", "DateModified");
            DropColumn("dbo.Seats", "DateCreated");
            DropColumn("dbo.Orders", "DateModified");
            DropColumn("dbo.Orders", "DateCreated");
            DropColumn("dbo.OrderRows", "DateModified");
            DropColumn("dbo.OrderRows", "DateCreated");
            DropColumn("dbo.Employees", "DateModified");
            DropColumn("dbo.Employees", "DateCreated");
            DropColumn("dbo.Employees", "EmployeeTypeID");
            DropColumn("dbo.Employees", "EmployeeFormID");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.EmployeeForms");
        }
    }
}
