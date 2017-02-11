using System.Collections.Generic;

namespace PSTodos.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Remove(TEntity obj);
        void Remove(int id);
        void Update(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
