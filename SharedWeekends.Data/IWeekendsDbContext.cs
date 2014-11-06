namespace SharedWeekends.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using SharedWeekends.Models;

    public interface IWeekendsDbContext
    {
        IDbSet<Weekend> Weekends { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Picture> Pictures { get; set; }

        IDbSet<User> Users { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
