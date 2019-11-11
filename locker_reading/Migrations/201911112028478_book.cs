namespace locker_reading.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Pages = c.Int(nullable: false),
                        Finished = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Books");
        }
    }
}
