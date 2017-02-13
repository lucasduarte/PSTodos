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
        public UsuarioPerfilViewModel AdicionarPerfil(UsuarioPerfilViewModel usuarioPerfilVM)
        {
            var usuario = Mapper.Map<UsuarioPerfilViewModel, UsuarioPerfil>(usuarioPerfilVM);

            BeginTransaction();
            var result = _usuarioPerfilRepository.Add(usuario);
            Commit();

            return Mapper.Map<UsuarioPerfil,UsuarioPerfilViewModel>(result);
        }

        public bool RemoverPerfil(UsuarioPerfil usuarioPerfilVm)
        {
            BeginTransaction();
            var result = _usuarioPerfilRepository.Remover(usuarioPerfilVm.UsuarioId, usuarioPerfilVm.PerfilId);
            Commit();

            return result;
        }
    }
}
