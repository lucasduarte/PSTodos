using System.Collections.Generic;
using PSTodos.RESTServices.Results;
using PSTodos.RESTServices.ViewModels;
using RestSharp;
using Newtonsoft.Json;
using System.Configuration;

namespace PSTodos.RESTServices
{
    public class BaseRESTService<T> : IBaseRESTService<T> where T : BaseViewModel
    {
        protected static readonly string _baseApiUrl = ConfigurationManager.AppSettings["baseApiUrl"];

        protected readonly RestClient _restClient;

        public BaseRESTService(string apiUrl)
        {
            _restClient = new RestClient(_baseApiUrl + apiUrl);
        }

        public GenericResult<T> Cadastrar(T vm)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddJsonBody(vm);
            var requestResult = _restClient.Execute<GenericResult<T>>(restRequest);

            if (requestResult.Data == null)
            {
                return JsonConvert.DeserializeObject<GenericResult<T>>(requestResult.Content);
            }
            else
            {
                return requestResult.Data;
            }
        }

        public GenericResult Editar(int id, T vm)
        {
            var restRequest = new RestRequest($"/{id}", Method.PUT);
            restRequest.AddJsonBody(vm);

            var requestResult = _restClient.Execute<GenericResult<T>>(restRequest);

            if (requestResult.Data == null)
            {
                return JsonConvert.DeserializeObject<GenericResult<T>>(requestResult.Content);
            }
            else
            {
                return requestResult.Data;
            }
        }

        public GenericResult<List<T>> Listar()
        {
            var restRequest = new RestRequest(Method.GET);
            var requestResult = _restClient.Execute<GenericResult<List<T>>>(restRequest);
            if (requestResult.Data == null)
            {
                return JsonConvert.DeserializeObject<GenericResult<List<T>>>(requestResult.Content);
            }
            else
            {
                return requestResult.Data;
            }
        }

        public GenericResult<T> Obter(int id)
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddParameter("id", id);
            var requestResult = _restClient.Execute<GenericResult<T>>(restRequest);

            if(requestResult.Data == null)
            {
                return JsonConvert.DeserializeObject<GenericResult<T>>(requestResult.Content);
            }
            else
            {
                return requestResult.Data;
            }
        }

        public GenericResult Remover(int id)
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddParameter("id", id);
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