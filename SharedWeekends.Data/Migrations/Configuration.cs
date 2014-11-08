namespace SharedWeekends.Data.Migrations
{
    using SharedWeekends.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

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
            if(db.Users.Any())
            {
                return;
            }
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole("admin"));
            roleManager.Create(new IdentityRole("moderator"));

            var userAdmin = new User
            {
                UserName = "a@a.a",
                Email = "a@a.a"
            };
            var userMod = new User
            {
                UserName = "m@m.m",
                Email = "m@m.m"
            };

            var resultAdmin = userManager.Create(userAdmin, "123456");
            var resultMod = userManager.Create(userMod, "123456");
            if (resultAdmin.Succeeded && resultMod.Succeeded)
            {
                userManager.AddToRole(userAdmin.Id, "admin");
                userManager.AddToRole(userMod.Id, "moderator");
            }
            var message = new Message()
            {
                Content = "Bla bal",
                CreationDate = DateTime.Now,
                IsRead = false
            };

            db.Messages.Add(message);
            message.Sender = userAdmin.UserName;
            message.Receiver = userMod.UserName;

            db.SaveChanges();

            var category = new Category()
            {
                Name = "Common"
            };

            var weekend = new Weekend()
            {
                 AuthorId = userAdmin.Id,
                 Category = category,
                 Lattitude = 42.60m,
                 Longitude = 23.18m,
                 CreationDate = DateTime.Now,
                 Content = "Best weekend so far",
                 Title = "Nlkwd"
            };

            db.Weekends.Add(weekend);
            db.SaveChanges();
        }
    }
}
