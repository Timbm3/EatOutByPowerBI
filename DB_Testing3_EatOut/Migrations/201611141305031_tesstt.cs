namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tesstt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "DateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
