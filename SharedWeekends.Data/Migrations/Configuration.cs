namespace SharedWeekends.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using SharedWeekends.Models;
    
    public sealed class Configuration : DbMigrationsConfiguration<WeekendsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WeekendsDbContext context)
        {
            var db = new WeekendsDbContext();
            if (db.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole("admin"));

            var userAdmin = new User
            {
                UserName = "a@a.a",
                Email = "a@a.a"
            };

            var resultAdmin = userManager.Create(userAdmin, "ad123456min");
            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(userAdmin.Id, "admin");
            }
        }
    }
}
