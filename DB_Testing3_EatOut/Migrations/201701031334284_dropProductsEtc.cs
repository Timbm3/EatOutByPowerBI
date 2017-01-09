namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropProductsEtc : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            //DropIndex("dbo.Events", new[] { "EventTypeId" });
            //DropTable("dbo.Events");
        }
        
        public override void Down()
        {
        }
    }
}
