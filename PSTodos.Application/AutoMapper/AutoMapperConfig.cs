using AutoMapper;
using PSTodos.Application.ViewModels;
using PSTodos.Model.Entities;

namespace PSTodos.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Usuario, UsuarioViewModel>()
                config.CreateMap<UsuarioViewModel, Usuario>();

                config.CreateMap<Perfil, PerfilViewModel>();
                config.CreateMap<PerfilViewModel, Perfil>();

                config.CreateMap<UsuarioPerfil, UsuarioPerfilViewModel>();
                config.CreateMap<UsuarioPerfilViewModel, UsuarioPerfil>();
            });
        }
    }
}
