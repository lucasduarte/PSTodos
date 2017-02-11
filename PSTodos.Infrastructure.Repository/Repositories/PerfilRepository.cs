using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;

namespace PSTodos.Infrastructure.Repository.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        private readonly IBaseRepository<Perfil> _perfilRepository;

        public PerfilRepository(IBaseRepository<Perfil> perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }
    }
}
