namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDataTypeSize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalMessages", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.PersonalMessages", "Message", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalMessages", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.PersonalMessages", "Title", c => c.String());
        }
    }
}
