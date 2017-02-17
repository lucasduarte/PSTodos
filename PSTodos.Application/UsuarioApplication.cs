using AutoMapper;
using PSTodos.Application.ViewModels;
using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Model.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public UsuarioViewModel ObterComPerfil(int id)
        {
            var query = _usuarioRepository.ObterComPerfil(id);
            var result = Mapper.Map<UsuarioViewModel>(query);

            if(result != null)
                result.Perfis = Mapper.Map<IEnumerable<PerfilViewModel>>
                    (query.UsuarioPerfis.Select(x => new Perfil { Id = x.Perfil.Id, Ativo = x.Ativo, Nome = x.Perfil.Nome }));

            return result;
        }

        public IEnumerable<UsuarioViewModel> Listar()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.GetAll());
        }

        public UsuarioViewModel Cadastrar(UsuarioViewModel usuarioVM)
        {
            var usuario = Mapper.Map<Usuario>(usuarioVM);         
              
            BeginTransaction();
            var result = _usuarioRepository.Add(usuario);
            Commit();

            return Mapper.Map<UsuarioViewModel>(result);
        }

        public bool Atualizar(UsuarioViewModel usuarioVM, int id)
        {
            var usuario = Mapper.Map<Usuario>(usuarioVM);

            BeginTransaction();
            var result = _usuarioRepository.Atualizar(usuario, id);
            Commit();

            return result != null;
        }

        public bool Deletar(int id)
        {
            BeginTransaction();
            var result = _usuarioRepository.Remove(id);
            Commit();

            return result;
        }
    }
}
