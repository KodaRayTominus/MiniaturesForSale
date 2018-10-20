namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishedPersonClassForProfilePage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "FavoriteGame", c => c.String());
            AddColumn("dbo.People", "NickName", c => c.String());
            AddColumn("dbo.People", "PhoneNumber", c => c.String());
            AddColumn("dbo.People", "FactionFanFiction", c => c.String());
            AddColumn("dbo.People", "PastExperience", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PastExperience");
            DropColumn("dbo.People", "FactionFanFiction");
            DropColumn("dbo.People", "PhoneNumber");
            DropColumn("dbo.People", "NickName");
            DropColumn("dbo.People", "FavoriteGame");
        }
    }
}
