using Newtonsoft.Json;
using PSTodos.Mvc.Results;
using PSTodos.Mvc.ViewModels;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PSTodos.Mvc.RESTServices
{
    public class UsuarioPerfilRESTService : BaseRESTService
    {
        private readonly string usuarioPerfilUri = apiUri + "/usuarios/{0}/perfis/{1}";

        public async Task<GenericResult<UsuarioPerfilViewModel>> CadastrarUsuarioPerfilAsync(int usuarioId, int perfilId)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(string.Format(usuarioPerfilUri, usuarioId, perfilId), new StringContent("", Encoding.UTF8, "application/json"));
                return JsonConvert.DeserializeObject<GenericResult<UsuarioPerfilViewModel>>(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<GenericResult> RemoverUsuarioPerfilAsync(int usuarioId, int perfilId)
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(string.Format(usuarioPerfilUri, usuarioId, perfilId));
                return JsonConvert.DeserializeObject<GenericResult<PerfilViewModel>>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}