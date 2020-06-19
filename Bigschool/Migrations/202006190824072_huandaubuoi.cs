namespace Bigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class huandaubuoi : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "Fllower_Id", newName: "Follower_Id");
            RenameColumn(table: "dbo.Followings", name: "Fllowee_Id", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Fllowee_Id", newName: "IX_FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Fllower_Id", newName: "IX_Follower_Id");
            DropPrimaryKey("dbo.Followings");
            AddColumn("dbo.Followings", "FollowerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Followings", "FollowerId");
            DropColumn("dbo.Followings", "FllowerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Followings", "FllowerId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Followings");
            DropColumn("dbo.Followings", "FollowerId");
            AddPrimaryKey("dbo.Followings", "FllowerId");
            RenameIndex(table: "dbo.Followings", name: "IX_Follower_Id", newName: "IX_Fllower_Id");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_Fllowee_Id");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "Fllowee_Id");
            RenameColumn(table: "dbo.Followings", name: "Follower_Id", newName: "Fllower_Id");
        }
    }
}
