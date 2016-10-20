namespace DB_Testing3_EatOut.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MonthAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TimeTables", "MonthDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TimeTables", "MonthDay", c => c.Int(nullable: false));
        }
    }
}
