using PSTodos.RESTServices.Results;
using PSTodos.RESTServices.ViewModels;

namespace PSTodos.RESTServices
{
    public interface IUsuarioPerfilRESTService : IBaseRESTService<UsuarioPerfilViewModel>
    {
        GenericResult<UsuarioPerfilViewModel> AdicionarPerfil(int usuarioId, int perfilId);
        GenericResult RemoverPerfil(int usuarioId, int perfilId);
    }
}