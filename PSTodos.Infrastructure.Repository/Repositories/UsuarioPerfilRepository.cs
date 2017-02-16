using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;
using System.Linq;

namespace PSTodos.Infrastructure.Repository.Repositories
{
    public class UsuarioPerfilRepository : BaseRepository<UsuarioPerfil>, IUsuarioPerfilRepository
    {
        private readonly IBaseRepository<UsuarioPerfil> _usuarioPerfilRepository;

        public UsuarioPerfilRepository(IBaseRepository<UsuarioPerfil> usuarioPerfilRepository)
        {
            _usuarioPerfilRepository = usuarioPerfilRepository;
        }

        public bool Remover(int usuarioId, int perfilId)
        {
            var obj = Obter(usuarioId, perfilId);
            if (obj != null)
            {
                Remove(obj);
                return true;
            }
            else
            {
                return false;
            }
        }

        public UsuarioPerfil Obter(int usuarioId, int perfilId)
        {
            return Context.UsuariosPerfis.FirstOrDefault(x => x.PerfilId == perfilId && x.UsuarioId == usuarioId);
        }
    }
}
