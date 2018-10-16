namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPersonClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Bio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Bio");
        }
    }
}
