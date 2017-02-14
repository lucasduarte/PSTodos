using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;
using System;
using System.Linq;
using System.Data.Entity;

namespace PSTodos.Infrastructure.Repository.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly IBaseRepository<Usuario> _usuarioRepository;

        public UsuarioRepository(IBaseRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public override Usuario Add(Usuario obj)
        {
            obj.DtInclusao = DateTime.Now;
           return base.Add(obj);
        }

        public Usuario ObterComPerfil(int id)
        {
            var result = Context.Usuarios
                .Include(x => x.UsuarioPerfis)
                .FirstOrDefault(x => x.Id == id);

            return result;
        }

        public Usuario Atualizar(Usuario obj, int id)
        {
            if (obj == null)
            {
                return null;
            }

            Usuario existing = Context.Set<Usuario>().Find(id);
            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(obj);
                Context.Entry(existing).State = EntityState.Modified;
                Context.Entry(existing).Property(x => x.DtInclusao).IsModified = false;
            }

            return existing;
        }
    }
}
