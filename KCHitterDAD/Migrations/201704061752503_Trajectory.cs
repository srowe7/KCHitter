namespace KCHitterDAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trajectory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "Trajectory", c => c.Single(nullable: false));
            AddColumn("dbo.Sessions", "Distance", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "Distance");
            DropColumn("dbo.Sessions", "Trajectory");
        }
    }
}
