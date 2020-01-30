namespace BarManagerProgram.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BarManagerProgram.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BarManagerProgram.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Liquor.AddOrUpdate(
                new Models.Liquor { LiquorName = "Vodka" },
                new Models.Liquor { LiquorName = "Gin" },
                new Models.Liquor { LiquorName = "White Rum" },
                new Models.Liquor { LiquorName = "Tequila" },
                new Models.Liquor { LiquorName = "Spiced Rum" },
                new Models.Liquor { LiquorName = "Brandy" },
                new Models.Liquor { LiquorName = "Whiskey" },
                new Models.Liquor { LiquorName = "Scotch" });
            context.Juice.AddOrUpdate(
                new Models.Juice { JuiceName = "Lemon" },
                new Models.Juice { JuiceName = "Lime" },
                new Models.Juice { JuiceName = "Orange" },
                new Models.Juice { JuiceName = "Grapefruit" });
            context.Syrup.AddOrUpdate(
                new Models.Syrup { SyrupName = "Simple" },
                new Models.Syrup { SyrupName = "Strawberry" },
                new Models.Syrup { SyrupName = "Blackberry" },
                new Models.Syrup { SyrupName = "Raspberry" },
                new Models.Syrup { SyrupName = "Peach-Mango" },
                new Models.Syrup { SyrupName = "Watermelon" }); 
            context.Liqueur.AddOrUpdate(
                 new Models.Liqueur { LiqueurName = "Orange" },
                 new Models.Liqueur { LiqueurName = "Framboise" },
                 new Models.Liqueur { LiqueurName = "Lychee" },
                 new Models.Liqueur { LiqueurName = "Elderflower" },
                 new Models.Liqueur { LiqueurName = "Amaretto" },
                 new Models.Liqueur { LiqueurName = "Sweet Vermouth" });
            context.Bitter.AddOrUpdate(
                 new Models.Bitter { BitterName = "Angostura" },
                 new Models.Bitter { BitterName = "Trinity" },
                 new Models.Bitter { BitterName = "Cherry Bark Vanilla" },
                 new Models.Bitter { BitterName = "Blackstrap" },
                 new Models.Bitter { BitterName = "Orange" },
                 new Models.Bitter { BitterName = "Bolivar" });
            context.Topper.AddOrUpdate(
                 new Models.Topper { TopperName = "Seltzer" },
                 new Models.Topper { TopperName = "Ginger Beer" },
                 new Models.Topper { TopperName = "Sprite" },
                 new Models.Topper { TopperName = "Coke" },
                 new Models.Topper { TopperName = "Diet Coke" },
                 new Models.Topper { TopperName = "Water" });
        }
    }
}
