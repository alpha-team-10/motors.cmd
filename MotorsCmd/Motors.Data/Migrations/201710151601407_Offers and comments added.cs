namespace Motors.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Offersandcommentsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferId = c.Int(),
                        Content = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .Index(t => t.OfferId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Offers", "UserId", "dbo.Users");
            DropIndex("dbo.Offers", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "OfferId" });
            DropTable("dbo.Offers");
            DropTable("dbo.Comments");
        }
    }
}
