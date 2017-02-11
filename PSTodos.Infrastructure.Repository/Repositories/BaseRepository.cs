using Microsoft.Practices.ServiceLocation;
using PSTodos.Infrastructure.Repository.EF;
using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PSTodos.Infrastructure.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
    {
        protected DbContext Context { get; private set; }

        public BaseRepository()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            Context = contextManager.Context;
        }
        public virtual void Add(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
        }

        public void Remove(int id)
        {
            var obj = GetById(id);
            Remove(obj);
        }

        public void Remove(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }
    }
}
