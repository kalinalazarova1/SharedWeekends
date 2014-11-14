namespace SharedWeekends.Data
{
    using SharedWeekends.Data.Common.Models;
    using SharedWeekends.Data.Common.Repositories;
    using SharedWeekends.Data.Common.Repository;
    using SharedWeekends.Models;

    public interface IWeekendsData
    {
        IDeletableEntityRepository<Weekend> Weekends { get; }

        IDeletableEntityRepository<Category> Categories { get; }

        IDeletableEntityRepository<User> Users { get; }

        IDeletableEntityRepository<Message> Messages { get; }

        IDeletableEntityRepository<Like> Likes { get; }

        IDeletableEntityRepository<T> GetRepository<T>() where T : class, IDeletableEntity;

        int SaveChanges();
    }
}
