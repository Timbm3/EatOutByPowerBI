namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentMethos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        PaymentMethods = c.String(),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
            AddColumn("dbo.Orders", "PaymentMethodId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Orders", "PaymentMethodId");
            AddForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods", "PaymentMethodId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods");
            DropIndex("dbo.Orders", new[] { "PaymentMethodId" });
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Orders", "PaymentMethodId");
            DropTable("dbo.PaymentMethods");
        }
    }
}
