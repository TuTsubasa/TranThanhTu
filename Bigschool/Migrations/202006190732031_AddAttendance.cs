namespace Bigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendaces",
                c => new
                    {
                        SourceId = c.String(nullable: false, maxLength: 128),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        Source_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SourceId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Sources", t => t.Source_Id)
                .Index(t => t.AttendeeId)
                .Index(t => t.Source_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendaces", "Source_Id", "dbo.Sources");
            DropForeignKey("dbo.Attendaces", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendaces", new[] { "Source_Id" });
            DropIndex("dbo.Attendaces", new[] { "AttendeeId" });
            DropTable("dbo.Attendaces");
        }
    }
}
