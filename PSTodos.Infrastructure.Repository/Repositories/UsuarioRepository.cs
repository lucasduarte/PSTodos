using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;
using System;

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
    }
}
