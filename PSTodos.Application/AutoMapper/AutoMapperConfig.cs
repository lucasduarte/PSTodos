using AutoMapper;

namespace PSTodos.Application.AutoMapper
{
    public class AutoMapperConfig //: Profile
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                //config.CreateMap<Usuario, UsuarioViewModel>();
                //config.CreateMap<UsuarioViewModel, Usuario>()
                //   .ForSourceMember(s => s.Perfis, opt => opt.Ignore());

                config.AddProfile<UsuarioProfile>();
                config.AddProfile<PerfilProfile>();

                //config.CreateMap<Perfil, PerfilViewModel>();
                //config.CreateMap<PerfilViewModel, Perfil>();

                //config.CreateMap<UsuarioPerfil, UsuarioPerfilViewModel>();
                //config.CreateMap<UsuarioPerfilViewModel, UsuarioPerfil>();
            });
        }
    }
}
