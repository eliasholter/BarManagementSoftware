namespace BarManagerProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCavaToInventoryAndPhoneNumberToManager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "PhoneNumber", c => c.String());
            AddColumn("dbo.Inventories", "CavaBottleCount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "CavaBottleCount");
            DropColumn("dbo.Managers", "PhoneNumber");
        }
    }
}
