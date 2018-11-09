namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReadPropertyToPersonalMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalMessages", "Read", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalMessages", "Read");
        }
    }
}
