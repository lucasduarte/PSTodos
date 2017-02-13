using System.Collections.Generic;
using System.Threading.Tasks;
using PSTodos.Mvc.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using PSTodos.Mvc.Results;

namespace PSTodos.Mvc.RESTServices
{
    public class UsuarioRESTService : BaseRESTService
    {
        private readonly string usuarioUri = apiUri + "/usuarios";

        public async Task<GenericResult<List<UsuarioViewModel>>> ObterUsuariosAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<GenericResult<List<UsuarioViewModel>>>(
                        await httpClient.GetStringAsync(usuarioUri)
                    );
            }
        }
    }
}