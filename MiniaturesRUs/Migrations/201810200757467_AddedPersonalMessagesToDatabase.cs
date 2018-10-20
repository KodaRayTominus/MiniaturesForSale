namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPersonalMessagesToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalMessages",
                c => new
                    {
                        SenderID = c.String(nullable: false, maxLength: 128),
                        RecipientID = c.String(nullable: false, maxLength: 128),
                        MessageID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderID, cascadeDelete: false)
                .Index(t => t.SenderID)
                .Index(t => t.RecipientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalMessages", "SenderID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalMessages", "RecipientID", "dbo.AspNetUsers");
            DropIndex("dbo.PersonalMessages", new[] { "RecipientID" });
            DropIndex("dbo.PersonalMessages", new[] { "SenderID" });
            DropTable("dbo.PersonalMessages");
        }
    }
}
