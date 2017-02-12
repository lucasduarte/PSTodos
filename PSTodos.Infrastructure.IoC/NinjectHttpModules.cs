using Ninject.Modules;
using PSTodos.Infrastructure.Repository.EF;
using PSTodos.Infrastructure.Repository.Interfaces;
using PSTodos.Infrastructure.Repository.Repositories;

namespace PSTodos.Infrastructure.IoC
{
    public class NinjectHttpModules
    {
        //Return Lists of Modules in the Application
        public static NinjectModule[] Modules
        {
            get
            {
                return new[] { new MainModule() };
            }
        }

        //Main Module For Application
        public class MainModule : NinjectModule
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
}
