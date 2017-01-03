namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testBtIds1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookeds", "BookingTimesIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookeds", "BookingTimesIds");
        }
    }
}
