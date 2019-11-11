namespace locker_reading.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lecture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Advance = c.Int(nullable: false, identity: true),
                        SelectedBookId = c.Int(nullable: false),
                        NumAdvance = c.Int(nullable: false),
                        Finished = c.Boolean(nullable: false),
                        Review = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Advance)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lectures", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Lectures", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Lectures", new[] { "Book_Id" });
            DropIndex("dbo.Lectures", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Lectures");
        }
    }
}
