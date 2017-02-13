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
        protected PSTodosContext Context { get; private set; }

        public BaseRepository()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            Context = (PSTodosContext) contextManager.Context;
        }
        public virtual TEntity Add(TEntity obj)
        {
            return Context.Set<TEntity>().Add(obj);
        }

        public bool Remove(int id)
        {
            var obj = GetById(id);
            if(obj != null)
            {
                Remove(obj);
                return true;
            }
            else
            {
                return false;
            }          
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

        public TEntity Update(TEntity obj, int id)
        {
            if (obj == null)
            {
                return null;
            }

            TEntity existing = Context.Set<TEntity>().Find(id);
            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(obj);
                Context.Entry(existing).State = EntityState.Modified;
            }

            return existing;     
        }
    }
}
