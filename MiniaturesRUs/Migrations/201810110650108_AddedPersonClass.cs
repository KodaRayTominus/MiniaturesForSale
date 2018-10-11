namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPersonClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Personid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        UserName = c.String(nullable: false),
                        AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.Personid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
