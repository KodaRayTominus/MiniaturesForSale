namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPersonMessageClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "UserName", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.People", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.People", new[] { "UserName" });
            AlterColumn("dbo.People", "UserName", c => c.String(nullable: false));
        }
    }
}
