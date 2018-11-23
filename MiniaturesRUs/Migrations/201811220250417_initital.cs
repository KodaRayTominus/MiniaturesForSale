namespace MiniaturesRUs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Miniatures",
                c => new
                    {
                        MiniId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        GameName = c.String(nullable: false),
                        Faction = c.String(nullable: false),
                        Speed = c.Int(),
                        Attack = c.Int(),
                        Strength = c.Int(),
                        HitPoints = c.Int(),
                        Defense = c.Int(),
                    })
                .PrimaryKey(t => t.MiniId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        BuyerId = c.String(maxLength: 128),
                        SellerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.BuyerId)
                .ForeignKey("dbo.AspNetUsers", t => t.SellerId)
                .Index(t => t.BuyerId)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        AccountId = c.Int(),
                        Bio = c.String(),
                        FavoriteGame = c.String(),
                        NickName = c.String(),
                        FactionFanFiction = c.String(),
                        PastExperience = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ImageUrl = c.String(),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PersonalMessages",
                c => new
                    {
                        SenderID = c.String(nullable: false, maxLength: 128),
                        RecipientID = c.String(nullable: false, maxLength: 128),
                        MessageID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Message = c.String(nullable: false, maxLength: 500),
                        Read = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderID, cascadeDelete: false)
                .Index(t => t.SenderID)
                .Index(t => t.RecipientID);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Miniatures", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "ProductId", "dbo.Miniatures");
            DropForeignKey("dbo.PersonalMessages", "SenderID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalMessages", "RecipientID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "SellerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserImages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductOrders", new[] { "ProductId" });
            DropIndex("dbo.ProductOrders", new[] { "OrderId" });
            DropIndex("dbo.PersonalMessages", new[] { "RecipientID" });
            DropIndex("dbo.PersonalMessages", new[] { "SenderID" });
            DropIndex("dbo.UserImages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Orders", new[] { "SellerId" });
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.PersonalMessages");
            DropTable("dbo.UserImages");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.Miniatures");
        }
    }
}
