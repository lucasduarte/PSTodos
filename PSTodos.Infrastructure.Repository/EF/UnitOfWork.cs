using Microsoft.Practices.ServiceLocation;
using PSTodos.Infrastructure.Repository.Interfaces;
using System.Data.Entity;

namespace PSTodos.Infrastructure.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public void BeginTransaction()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            _context = contextManager.Context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
