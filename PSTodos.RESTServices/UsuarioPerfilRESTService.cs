using Newtonsoft.Json;
using PSTodos.RESTServices.Results;
using PSTodos.RESTServices.ViewModels;
using RestSharp;

namespace PSTodos.RESTServices
{
    public class UsuarioPerfilRESTService : BaseRESTService<UsuarioPerfilViewModel>, IUsuarioPerfilRESTService
    {
        public UsuarioPerfilRESTService()
            : base("")
        {
        }

        public GenericResult<UsuarioPerfilViewModel> AdicionarPerfil(int usuarioId, int perfilId)
        {
            var restRequest = new RestRequest($"/Usuarios/{usuarioId}/Perfis/{perfilId}", Method.POST);

            var requestResult = _restClient.Execute<GenericResult<UsuarioPerfilViewModel>>(restRequest);

            if (requestResult.Data == null)
            {
                return JsonConvert.DeserializeObject<GenericResult<UsuarioPerfilViewModel>>(requestResult.Content);
            }
            else
            {
                return requestResult.Data;
            }
        }

        public GenericResult RemoverPerfil(int usuarioId, int perfilId)
        {
            var restRequest = new RestRequest($"/Usuarios/{usuarioId}/Perfis/{perfilId}", Method.DELETE);

            var requestResult = _restClient.Execute<GenericResult>(restRequest);

            if (requestResult.Data == null)
            {
                return JsonConvert.DeserializeObject<GenericResult>(requestResult.Content);
            }
            else
            {
                return requestResult.Data;
            }
        }
    }
}