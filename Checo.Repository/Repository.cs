using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Checo.Repository.Interface;
using Checo.Repository.Context;

namespace Checo.Repository
{
    public class Repository<TEntity> : BaseRepository, IRepository<TEntity> where TEntity : class
    {
        #region property
        protected DbSet<TEntity> entities;
        #endregion

        #region Constructor
        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<TEntity>();
        }
        #endregion

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            entities.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
