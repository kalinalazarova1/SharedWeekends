﻿namespace SharedWeekends.Data.Common.Repositories
 {
     using System.Linq;

     using SharedWeekends.Data.Common.Repository;

     public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
     {
         IQueryable<T> AllWithDeleted();
     }
 }
