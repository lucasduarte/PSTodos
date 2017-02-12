using System.Collections.Generic;

namespace PSTodos.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        void Remove(TEntity obj);
        bool Remove(int id);
        TEntity Update(TEntity obj, int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
