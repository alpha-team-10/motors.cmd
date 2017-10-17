namespace Motors.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Motorcycleaddedandmodelandmanufacturerfixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Motorcycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Power = c.Int(nullable: false),
                        ProductionDate = c.DateTime(nullable: false),
                        Kilometers = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Model_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.Model_Id)
                .Index(t => t.Model_Id);
            
            AddColumn("dbo.Offers", "MotorcycleId", c => c.Int());
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Models", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Offers", "MotorcycleId");
            AddForeignKey("dbo.Offers", "MotorcycleId", "dbo.Motorcycles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "MotorcycleId", "dbo.Motorcycles");
            DropForeignKey("dbo.Motorcycles", "Model_Id", "dbo.Models");
            DropIndex("dbo.Motorcycles", new[] { "Model_Id" });
            DropIndex("dbo.Offers", new[] { "MotorcycleId" });
            AlterColumn("dbo.Models", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Offers", "MotorcycleId");
            DropTable("dbo.Motorcycles");
        }
    }
}
