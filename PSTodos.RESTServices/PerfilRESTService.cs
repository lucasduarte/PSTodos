using PSTodos.RESTServices.ViewModels;

namespace PSTodos.RESTServices
{
    public class PerfilRESTService : BaseRESTService<PerfilViewModel>, IPerfilRESTService
    {
        public PerfilRESTService()
            :base("/Perfis")
        {
        }
   
    }
}