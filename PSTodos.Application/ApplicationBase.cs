using Microsoft.Practices.ServiceLocation;
using PSTodos.Infrastructure.Repository.Interfaces;

namespace PSTodos.Application
{
    public class ApplicationBase
    {
        private IUnitOfWork _unitOfWork;

        public void BeginTransaction()
        {
            _unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
