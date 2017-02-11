using System;
using Ninject.Modules;
using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Infrastructure.Repository.Repositories;
using PSTodos.Infrastructure.Repository.EF;

namespace PSTodos.Infrastructure.IoC
{
    internal class IoCModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IOperacaoUsuarioRepository>().To<OperacaoUsuarioRepository>();
            Bind<IUsuarioPerfilRepository>().To<UsuarioPerfilRepository>();
            Bind<IPerfilRepository>().To<PerfilRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<ContextManager>().ToSelf();
        }
    }
}