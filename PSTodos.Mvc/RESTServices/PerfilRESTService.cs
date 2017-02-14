using Newtonsoft.Json;
using PSTodos.Mvc.Results;
using PSTodos.Mvc.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PSTodos.Mvc.RESTServices
{
    public class PerfilRESTService : BaseRESTService
    {
        private readonly string perfilUri = apiUri + "/perfis";

        public async Task<GenericResult<PerfilViewModel>> ObterPerfil(int id)
        {
            using (var httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<GenericResult<PerfilViewModel>>(
                        await httpClient.GetStringAsync(perfilUri + "/" + id)
                    );
            }
        }

        public async Task<GenericResult<List<PerfilViewModel>>> ObterPerfilsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<GenericResult<List<PerfilViewModel>>>(
                        await httpClient.GetStringAsync(perfilUri)
                    );
            }
        }

        public async Task<GenericResult<PerfilViewModel>> CadastrarPerfilAsync(PerfilViewModel perfilViewModel)
        {
            var content = JsonConvert.SerializeObject(perfilViewModel);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(perfilUri, new StringContent(content, Encoding.UTF8, "application/json"));
                return JsonConvert.DeserializeObject<GenericResult<PerfilViewModel>>(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<GenericResult> EditarPerfilAsync(int id, PerfilViewModel perfilViewModel)
        {
            var content = JsonConvert.SerializeObject(perfilViewModel);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(perfilUri + "/" + id, new StringContent(content, Encoding.UTF8, "application/json"));
                return JsonConvert.DeserializeObject<GenericResult<PerfilViewModel>>(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<GenericResult> RemoverPerfilAsync(int id)
        {
            var content = JsonConvert.SerializeObject(new { id = id });

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(perfilUri + "/" + id);
                return JsonConvert.DeserializeObject<GenericResult<PerfilViewModel>>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}