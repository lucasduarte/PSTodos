using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using PSTodos.RESTServices.ViewModels;
using PSTodos.RESTServices.Results;

namespace PSTodos.RESTServices
{
    public class UsuarioRESTService : BaseRESTService
    {
        private readonly  string usuarioUri = apiUri + "/usuarios";

        public async Task<GenericResult<UsuarioViewModel>> ObterUsuario(int id)
        {
            using (var httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<GenericResult<UsuarioViewModel>>(
                        await httpClient.GetStringAsync(usuarioUri + "/" + id)
                    );
            }
        }

        public async Task<GenericResult<List<UsuarioViewModel>>> ObterUsuariosAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<GenericResult<List<UsuarioViewModel>>>(
                        await httpClient.GetStringAsync(usuarioUri)
                    );
            }
        }

        public async Task<GenericResult<UsuarioViewModel>> CadastrarUsuarioAsync(UsuarioViewModel usuarioViewModel)
        {
            var content = JsonConvert.SerializeObject(usuarioViewModel);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(usuarioUri, new StringContent(content, Encoding.UTF8, "application/json"));
                return JsonConvert.DeserializeObject<GenericResult<UsuarioViewModel>>(await response.Content.ReadAsStringAsync());
            }       
        }

        public async Task<GenericResult> EditarUsuarioAsync(int id, UsuarioViewModel usuarioViewModel)
        {
            var content = JsonConvert.SerializeObject(usuarioViewModel);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(usuarioUri + "/" + id, new StringContent(content, Encoding.UTF8, "application/json"));
                return JsonConvert.DeserializeObject<GenericResult<UsuarioViewModel>>(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<GenericResult> RemoverUsuarioAsync(int id)
        {
            var content = JsonConvert.SerializeObject(new { id = id });

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(usuarioUri + "/" + id);
                return JsonConvert.DeserializeObject<GenericResult<UsuarioViewModel>>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}