namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamnByte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRows", "Kvantitet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderRows", "Kvantitet");
        }
    }
}
