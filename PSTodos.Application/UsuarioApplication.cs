using AutoMapper;
using PSTodos.Application.ViewModels;
using PSTodos.Infrastructure.Repository.Interfaces;

namespace PSTodos.Application
{
    public class UsuarioApplication : ApplicationBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplication(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioViewModel Obter(int id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioRepository.GetById(id));
        }
    }
}
