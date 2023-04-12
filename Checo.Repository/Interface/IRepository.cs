using System;
using System.Collections.Generic;

namespace Checo.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Remove(TEntity entity);
        void SaveChanges();
    }
}
