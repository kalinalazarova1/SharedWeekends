namespace SharedWeekends.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using SharedWeekends.Models;
    using SharedWeekends.Data.Migrations;

    public class WeekendsDbContext : IdentityDbContext<User>, IWeekendsDbContext
    {
        public WeekendsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WeekendsDbContext, Configuration>());
        }

        public static WeekendsDbContext Create()
        {
            return new WeekendsDbContext();
        }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Weekend> Weekends { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
