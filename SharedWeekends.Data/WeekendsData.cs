namespace SharedWeekends.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using SharedWeekends.Data.Common.Models;
    using SharedWeekends.Data.Common.Repositories;
    using SharedWeekends.Data.Common.Repository;
    using SharedWeekends.Models;

    public class WeekendsData : IWeekendsData
    {
        private IWeekendsDbContext context;
        private IDictionary<Type, object> repositories;

        public WeekendsData()
            : this(new WeekendsDbContext())
        {
        }

        public WeekendsData(IWeekendsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IDeletableEntityRepository<Weekend> Weekends
        {
            get
            {
                return this.GetRepository<Weekend>();
            }
        }

        public IDeletableEntityRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IDeletableEntityRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IDeletableEntityRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IDeletableEntityRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public IDeletableEntityRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeOfModel];
        }
    }
}
