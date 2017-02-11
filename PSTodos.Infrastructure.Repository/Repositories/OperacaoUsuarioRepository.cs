using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;

namespace PSTodos.Infrastructure.Repository.Repositories
{
    public class OperacaoUsuarioRepository : BaseRepository<OperacaoUsuario>, IOperacaoUsuarioRepository
    {
        private readonly IBaseRepository<OperacaoUsuario> _operacaoUsuarioRepository;

        public OperacaoUsuarioRepository(IBaseRepository<OperacaoUsuario> operacaoUsuarioRepository)
        {
            _operacaoUsuarioRepository = operacaoUsuarioRepository;
        }
    }
}
