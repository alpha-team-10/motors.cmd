namespace Motors.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduseranddatetoComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "Author_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Author_Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropColumn("dbo.Comments", "Author_Id");
            DropColumn("dbo.Comments", "Date");
        }
    }
}
