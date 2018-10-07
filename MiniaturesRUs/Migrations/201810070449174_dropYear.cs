namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropYear : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Miniatures", "Speed", c => c.Int());
            AlterColumn("dbo.Miniatures", "Attack", c => c.Int());
            AlterColumn("dbo.Miniatures", "Strength", c => c.Int());
            AlterColumn("dbo.Miniatures", "HitPoints", c => c.Int());
            AlterColumn("dbo.Miniatures", "Defense", c => c.Int());
            DropColumn("dbo.Miniatures", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Miniatures", "Year", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Miniatures", "Defense", c => c.Int(nullable: false));
            AlterColumn("dbo.Miniatures", "HitPoints", c => c.Int(nullable: false));
            AlterColumn("dbo.Miniatures", "Strength", c => c.Int(nullable: false));
            AlterColumn("dbo.Miniatures", "Attack", c => c.Int(nullable: false));
            AlterColumn("dbo.Miniatures", "Speed", c => c.Int(nullable: false));
        }
    }
}
