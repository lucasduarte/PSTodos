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
                config.CreateMap<Usuario, UsuarioViewModel>();
            });
        }
    }
}
