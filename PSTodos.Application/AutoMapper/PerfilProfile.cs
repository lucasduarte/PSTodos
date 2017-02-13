using AutoMapper;
using PSTodos.Application.ViewModels;
using PSTodos.Model.Entities;

namespace PSTodos.Application.AutoMapper
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<Perfil, PerfilViewModel>().ReverseMap();
        }
    }
}
