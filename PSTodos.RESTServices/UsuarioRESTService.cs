using System.Collections.Generic;
using PSTodos.RESTServices.ViewModels;
using PSTodos.RESTServices.Results;
using RestSharp;

namespace PSTodos.RESTServices
{
    public class UsuarioRESTService : BaseRESTService
    {
        private readonly RestClient _restClient;

        public UsuarioRESTService()
        {
            _restClient = new RestClient(apiUri);
        }

        public GenericResult<UsuarioViewModel> ObterUsuario(int id)
        {
            var restRequest = new RestRequest("/Usuarios", Method.GET);
            restRequest.AddParameter("id", id);

            return _restClient.Execute<GenericResult<UsuarioViewModel>>(restRequest).Data;
        }

        public GenericResult<List<UsuarioViewModel>> ObterUsuarios()
        {
            var restRequest = new RestRequest("/Usuarios", Method.GET);         

            return _restClient.Execute<GenericResult<List<UsuarioViewModel>>>(restRequest).Data;
        }

        public GenericResult<UsuarioViewModel> CadastrarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var restRequest = new RestRequest("/Usuarios", Method.POST);
            restRequest.AddJsonBody(restRequest);

            return _restClient.Execute<GenericResult<UsuarioViewModel>>(restRequest).Data;
        }

        public GenericResult EditarUsuario(int id, UsuarioViewModel usuarioViewModel)
        {
            var restRequest = new RestRequest("/Usuarios", Method.PUT);
            restRequest.AddParameter("id", id);
            restRequest.AddJsonBody(restRequest);

            return _restClient.Execute<GenericResult>(restRequest).Data;
        }

        public GenericResult RemoverUsuario(int id)
        {
            var restRequest = new RestRequest("/Usuarios", Method.DELETE);
            restRequest.AddParameter("id", id);

            return _restClient.Execute<GenericResult>(restRequest).Data;
        }
    }
}