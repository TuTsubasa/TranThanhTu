namespace Bigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LectrurerId = c.String(nullable: false),
                        Place = c.String(maxLength: 255),
                        Datetime = c.DateTime(nullable: false),
                        CategoryId = c.Byte(nullable: false),
                        Lecturer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Lecturer_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Lecturer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sources", "Lecturer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sources", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Sources", new[] { "Lecturer_Id" });
            DropIndex("dbo.Sources", new[] { "CategoryId" });
            DropTable("dbo.Sources");
            DropTable("dbo.Categories");
        }
    }
}
