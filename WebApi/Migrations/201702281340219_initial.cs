namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        IMDBlink = c.String(),
                        Release = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Raters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Occupation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        RaterName_Id = c.Int(),
                        Title_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Raters", t => t.RaterName_Id)
                .ForeignKey("dbo.Movies", t => t.Title_Id)
                .Index(t => t.RaterName_Id)
                .Index(t => t.Title_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Title_Id", "dbo.Movies");
            DropForeignKey("dbo.Reviews", "RaterName_Id", "dbo.Raters");
            DropIndex("dbo.Reviews", new[] { "Title_Id" });
            DropIndex("dbo.Reviews", new[] { "RaterName_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Raters");
            DropTable("dbo.Movies");
        }
    }
}
