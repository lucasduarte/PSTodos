using AutoMapper;
using PSTodos.Application.ViewModels;
using PSTodos.Model.Entities;

namespace PSTodos.Application.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForSourceMember(x => x.UsuarioPerfis, opt => opt.Ignore());

            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
