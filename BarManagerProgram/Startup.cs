using BarManagerProgram.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarManagerProgram.Startup))]
namespace BarManagerProgram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            createRolesandUsers();
            ConfigureAuth(app);
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                
                var user = new ApplicationUser();
                user.UserName = "eholter";
                user.Email = "eliasholter1@gmail.com";

                string userPWD = "C0d3Stuff!";

                var chkUser = UserManager.Create(user, userPWD);
   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }
    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Bartender"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Bartender";
                roleManager.Create(role);

            }
        }
    }
}
