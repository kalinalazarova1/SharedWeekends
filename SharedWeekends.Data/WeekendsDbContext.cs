namespace SharedWeekends.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    
    using SharedWeekends.Data.Common.Models;
    using SharedWeekends.Data.Migrations;
    using SharedWeekends.Models;
    
    public class WeekendsDbContext : IdentityDbContext<User>, IWeekendsDbContext
    {
        public WeekendsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WeekendsDbContext, Configuration>());
        }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Weekend> Weekends { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Like> Likes { get; set; }

        public static WeekendsDbContext Create()
        {
            return new WeekendsDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
