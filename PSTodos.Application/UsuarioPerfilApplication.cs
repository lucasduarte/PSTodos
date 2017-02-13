using AutoMapper;
using PSTodos.Application.ViewModels;
using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;

namespace PSTodos.Application
{
    public class UsuarioPerfilApplication : ApplicationBase
    {
        private readonly IUsuarioPerfilRepository _usuarioPerfilRepository;

        public UsuarioPerfilApplication(IUsuarioPerfilRepository usuarioPerfilRepository)
        {
            _usuarioPerfilRepository = usuarioPerfilRepository;
        }
        public UsuarioPerfilViewModel AdicionarPerfil(int usuarioId, int perfilId)
        {
            var usuario = new UsuarioPerfil
            {
                UsuarioId = usuarioId,
                PerfilId = perfilId
            };

            BeginTransaction();
            var result = _usuarioPerfilRepository.Add(usuario);
            Commit();

            return Mapper.Map<UsuarioPerfil,UsuarioPerfilViewModel>(result);
        }

        public bool RemoverPerfil(int usuarioId, int perfilId)
        {
            BeginTransaction();
            var result = _usuarioPerfilRepository.Remover(usuarioId, perfilId);
            Commit();

            return result;
        }
    }
}
