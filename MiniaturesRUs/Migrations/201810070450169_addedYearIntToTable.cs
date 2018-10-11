namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedYearIntToTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Miniatures", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Miniatures", "Year");
        }
    }
}
