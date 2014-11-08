namespace SharedWeekends.Data
{
    using SharedWeekends.Data.Repositories;
    using SharedWeekends.Models;

    public interface IWeekendsData
    {
        IRepository<Weekend> Weekends { get; }

        IRepository<Category> Categories { get; }

        IRepository<User> Users { get; }

        IRepository<Message> Messages { get; }

        IRepository<Like> Likes { get; }

        IRepository<T> GetRepository<T>() where T : class;

        void SaveChanges();

    }
}
