namespace Bigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FllowerId = c.String(nullable: false, maxLength: 128),
                        Fllower_Id = c.String(nullable: false, maxLength: 128),
                        Fllowee_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FllowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.Fllower_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Fllowee_Id)
                .Index(t => t.Fllower_Id)
                .Index(t => t.Fllowee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "Fllowee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "Fllower_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "Fllowee_Id" });
            DropIndex("dbo.Followings", new[] { "Fllower_Id" });
            DropTable("dbo.Followings");
        }
    }
}
