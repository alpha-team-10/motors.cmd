namespace Motors.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelandmanufacturerrestrictionsfixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Models", "Name", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Models", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
