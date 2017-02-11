using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;

namespace PSTodos.Infrastructure.Repository.Repositories
{
    public class UsuarioPerfilRepository : BaseRepository<UsuarioPerfil>, IUsuarioPerfilRepository
    {
        private readonly IBaseRepository<UsuarioPerfil> _usuarioPerfilRepository;

        public UsuarioPerfilRepository(IBaseRepository<UsuarioPerfil> usuarioPerfilRepository)
        {
            _usuarioPerfilRepository = usuarioPerfilRepository;
        }
    }
}
