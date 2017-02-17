using PSTodos.RESTServices.ViewModels;

namespace PSTodos.RESTServices
{
    public class UsuarioRESTService : BaseRESTService<UsuarioViewModel>, IUsuarioRESTService
    {

        public UsuarioRESTService()
            :base("/Usuarios")
        {
        }
    }
}