namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testBtIdss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookeds", "BookingTimeIds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookeds", "BookingTimeIds", c => c.String());
        }
    }
}
