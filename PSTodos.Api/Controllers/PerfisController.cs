using PSTodos.Api.Extensions;
using PSTodos.Api.Results;
using PSTodos.Api.Validators;
using PSTodos.Application;
using PSTodos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PSTodos.Api.Controllers
{
    public class PerfisController : ApiController
    {
        private readonly PerfilApplication _perfilApplication;
        private readonly PerfilValidator _validator;

        public PerfisController(PerfilApplication perfilApplication, PerfilValidator validator)
        {
            _perfilApplication = perfilApplication;
            _validator = validator;
        }

        // GET api/perfis
        public GenericResult<IEnumerable<PerfilViewModel>> Get()
        {
            var result = new GenericResult<IEnumerable<PerfilViewModel>>();

            try
            {
                result.Result = _perfilApplication.Listar();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // GET api/perfis/5
        public GenericResult<PerfilViewModel> Get(int id)
        {
            var result = new GenericResult<PerfilViewModel>();
            try
            {
                result.Result = _perfilApplication.Obter(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // POST api/perfis
        [HttpPost]
        public GenericResult<PerfilViewModel> Post([FromBody]PerfilViewModel perfilVM)
        {
            var result = new GenericResult<PerfilViewModel>();

            var validatorResult = _validator.Validate(perfilVM);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = _perfilApplication.Cadastrar(perfilVM);
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
            {
                result.Errors = validatorResult.GetErrors();
            }

            return result;
        }

        // PUT api/perfis/5
        [HttpPut]
        public GenericResult Put(int id, [FromBody]PerfilViewModel perfilVM)
        {
            var result = new GenericResult();

            var validatorResult = _validator.Validate(perfilVM);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Success = _perfilApplication.Atualizar(perfilVM, id);
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
            {
                result.Errors = validatorResult.GetErrors();
            }

            return result;
        }

        // DELETE api/perfis/5
        [HttpDelete]
        public GenericResult Delete(int id)
        {
            var result = new GenericResult();

            try
            {
                result.Success = _perfilApplication.Deletar(id);
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;

        }
    }
}
