using AutoMapper;
using PSTodos.Application.ViewModels;
using PSTodos.Model.Entities;

namespace PSTodos.Application.AutoMapper
{
    public class UsuarioPerfilProfile : Profile
    {
        public UsuarioPerfilProfile()
        {
            CreateMap<UsuarioPerfil, UsuarioPerfilViewModel>();
        }
    }
}
