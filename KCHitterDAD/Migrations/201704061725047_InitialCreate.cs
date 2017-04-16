namespace KCHitterDAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        PlayerID = c.Int(nullable: false),
                        Pitches = c.Single(nullable: false),
                        TotalHits = c.Single(nullable: false),
                        GoodContact = c.Single(nullable: false),
                        BadContact = c.Single(nullable: false),
                        ExitVelocity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "PlayerID", "dbo.Players");
            DropIndex("dbo.Sessions", new[] { "PlayerID" });
            DropTable("dbo.Sessions");
            DropTable("dbo.Players");
            DropTable("dbo.Admins");
        }
    }
}
