namespace SharedWeekends.Data
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;

    using SharedWeekends.Models;
    using SharedWeekends.Data.Repositories;
    
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

        public IRepository<Weekend> Weekends
        {
            get
            {
                return this.GetRepository<Weekend>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public IRepository<Picture> Pictures
        {
            get
            {
                return this.GetRepository<Picture>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];

        }
    }
}
