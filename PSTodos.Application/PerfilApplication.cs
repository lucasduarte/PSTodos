using AutoMapper;
using PSTodos.Application.ViewModels;
using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;
using System.Collections.Generic;

namespace PSTodos.Application
{
    public class PerfilApplication : ApplicationBase
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilApplication(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public PerfilViewModel Obter(int id)
        {
            return Mapper.Map<PerfilViewModel>(_perfilRepository.GetById(id));
        }

        public IEnumerable<PerfilViewModel> Listar()
        {
            return Mapper.Map<IEnumerable<PerfilViewModel>>(_perfilRepository.GetAll());
        }

        public PerfilViewModel Cadastrar(PerfilViewModel PerfilVM)
        {
            var perfil = Mapper.Map<Perfil>(PerfilVM);

            BeginTransaction();
            var result = _perfilRepository.Add(perfil);
            Commit();

            return Mapper.Map<PerfilViewModel>(result);
        }

        public bool Atualizar(PerfilViewModel PerfilVM, int id)
        {
            var perfil = Mapper.Map<Perfil>(PerfilVM);

            BeginTransaction();
            var result = _perfilRepository.Update(perfil, id);
            Commit();

            return result != null;
        }

        public bool Deletar(int id)
        {
            BeginTransaction();
            var result = _perfilRepository.Remove(id);
            Commit();

            return result;
        }
    }
}
