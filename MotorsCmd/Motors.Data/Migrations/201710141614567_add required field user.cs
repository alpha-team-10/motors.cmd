namespace Motors.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequiredfielduser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Salt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Salt", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Mail", c => c.String());
        }
    }
}
