using PSTodos.RESTServices.Results;
using PSTodos.RESTServices.ViewModels;
using System.Collections.Generic;

namespace PSTodos.RESTServices
{
    public interface IBaseRESTService<T> where T : BaseViewModel
    {
        GenericResult<T> Obter(int id);
        GenericResult<List<T>> Listar();
        GenericResult<T> Cadastrar(T vm);
        GenericResult Editar(int id, T vm);
        GenericResult Remover(int id);
    }
}
