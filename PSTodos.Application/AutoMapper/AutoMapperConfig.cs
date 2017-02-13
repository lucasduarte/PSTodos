using AutoMapper;

namespace PSTodos.Application.AutoMapper
{
    public class AutoMapperConfig //: Profile
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<UsuarioProfile>();
                config.AddProfile<PerfilProfile>();
                config.AddProfile<UsuarioPerfilProfile>();             
            });
        }
    }
}
