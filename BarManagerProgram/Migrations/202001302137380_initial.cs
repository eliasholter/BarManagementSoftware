namespace BarManagerProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bars",
                c => new
                    {
                        BarId = c.Int(nullable: false, identity: true),
                        InventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BarId)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        VodkaBottleCount = c.Int(nullable: false),
                        GinBottleCount = c.Int(nullable: false),
                        WhiteRumBottleCount = c.Int(nullable: false),
                        TequilaBottleCount = c.Int(nullable: false),
                        SpicedRumBottleCount = c.Int(nullable: false),
                        BrandyBottleCount = c.Int(nullable: false),
                        WhiskeyBottleCount = c.Int(nullable: false),
                        ScotchBottleCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            CreateTable(
                "dbo.Bartenders",
                c => new
                    {
                        BartenderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.BartenderId);
            
            CreateTable(
                "dbo.Bitters",
                c => new
                    {
                        BitterId = c.Int(nullable: false, identity: true),
                        BitterName = c.String(),
                    })
                .PrimaryKey(t => t.BitterId);
            
            CreateTable(
                "dbo.Cocktails",
                c => new
                    {
                        CocktailId = c.Int(nullable: false, identity: true),
                        CocktailName = c.String(),
                        CocktailType = c.String(),
                        FlavorProfile = c.String(),
                        IsBubble = c.Boolean(nullable: false),
                        CocktailRating = c.Int(nullable: false),
                        LiquorId = c.Int(),
                        LiquorAmount = c.Double(nullable: false),
                        JuiceId = c.Int(),
                        JuiceAmount = c.Double(nullable: false),
                        SyrupId = c.Int(nullable: false),
                        SyrupAmount = c.Double(nullable: false),
                        LiqueurId = c.Int(nullable: false),
                        LiqueurAmount = c.Double(nullable: false),
                        BitterId = c.Int(nullable: false),
                        BitterAmount = c.Double(nullable: false),
                        TopperId = c.Int(nullable: false),
                        TopperAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CocktailId)
                .ForeignKey("dbo.Bitters", t => t.BitterId, cascadeDelete: true)
                .ForeignKey("dbo.Juices", t => t.JuiceId)
                .ForeignKey("dbo.Liqueurs", t => t.LiqueurId, cascadeDelete: true)
                .ForeignKey("dbo.Liquors", t => t.LiquorId)
                .ForeignKey("dbo.Syrups", t => t.SyrupId, cascadeDelete: true)
                .ForeignKey("dbo.Toppers", t => t.TopperId, cascadeDelete: true)
                .Index(t => t.LiquorId)
                .Index(t => t.JuiceId)
                .Index(t => t.SyrupId)
                .Index(t => t.LiqueurId)
                .Index(t => t.BitterId)
                .Index(t => t.TopperId);
            
            CreateTable(
                "dbo.Juices",
                c => new
                    {
                        JuiceId = c.Int(nullable: false, identity: true),
                        JuiceName = c.String(),
                    })
                .PrimaryKey(t => t.JuiceId);
            
            CreateTable(
                "dbo.Liqueurs",
                c => new
                    {
                        LiqueurId = c.Int(nullable: false, identity: true),
                        LiqueurName = c.String(),
                    })
                .PrimaryKey(t => t.LiqueurId);
            
            CreateTable(
                "dbo.Liquors",
                c => new
                    {
                        LiquorId = c.Int(nullable: false, identity: true),
                        LiquorName = c.String(),
                    })
                .PrimaryKey(t => t.LiquorId);
            
            CreateTable(
                "dbo.Syrups",
                c => new
                    {
                        SyrupId = c.Int(nullable: false, identity: true),
                        SyrupName = c.String(),
                    })
                .PrimaryKey(t => t.SyrupId);
            
            CreateTable(
                "dbo.Toppers",
                c => new
                    {
                        TopperId = c.Int(nullable: false, identity: true),
                        TopperName = c.String(),
                    })
                .PrimaryKey(t => t.TopperId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagererId = c.Int(nullable: false, identity: true),
                        BarId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ManagererId)
                .ForeignKey("dbo.Bars", t => t.BarId, cascadeDelete: true)
                .Index(t => t.BarId);
            
            CreateTable(
                "dbo.ManagerCocktails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        CocktailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cocktails", t => t.CocktailId, cascadeDelete: false)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: false)
                .Index(t => t.ManagerId)
                .Index(t => t.CocktailId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ManagerCocktails", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.ManagerCocktails", "CocktailId", "dbo.Cocktails");
            DropForeignKey("dbo.Managers", "BarId", "dbo.Bars");
            DropForeignKey("dbo.Cocktails", "TopperId", "dbo.Toppers");
            DropForeignKey("dbo.Cocktails", "SyrupId", "dbo.Syrups");
            DropForeignKey("dbo.Cocktails", "LiquorId", "dbo.Liquors");
            DropForeignKey("dbo.Cocktails", "LiqueurId", "dbo.Liqueurs");
            DropForeignKey("dbo.Cocktails", "JuiceId", "dbo.Juices");
            DropForeignKey("dbo.Cocktails", "BitterId", "dbo.Bitters");
            DropForeignKey("dbo.Bars", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ManagerCocktails", new[] { "CocktailId" });
            DropIndex("dbo.ManagerCocktails", new[] { "ManagerId" });
            DropIndex("dbo.Managers", new[] { "BarId" });
            DropIndex("dbo.Cocktails", new[] { "TopperId" });
            DropIndex("dbo.Cocktails", new[] { "BitterId" });
            DropIndex("dbo.Cocktails", new[] { "LiqueurId" });
            DropIndex("dbo.Cocktails", new[] { "SyrupId" });
            DropIndex("dbo.Cocktails", new[] { "JuiceId" });
            DropIndex("dbo.Cocktails", new[] { "LiquorId" });
            DropIndex("dbo.Bars", new[] { "InventoryId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ManagerCocktails");
            DropTable("dbo.Managers");
            DropTable("dbo.Toppers");
            DropTable("dbo.Syrups");
            DropTable("dbo.Liquors");
            DropTable("dbo.Liqueurs");
            DropTable("dbo.Juices");
            DropTable("dbo.Cocktails");
            DropTable("dbo.Bitters");
            DropTable("dbo.Bartenders");
            DropTable("dbo.Inventories");
            DropTable("dbo.Bars");
        }
    }
}
