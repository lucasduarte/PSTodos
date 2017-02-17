using PSTodos.Api.Extensions;
using PSTodos.Api.Results;
using PSTodos.Api.Validators;
using PSTodos.Application;
using PSTodos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
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
        public IHttpActionResult Get()
        {
            var result = new GenericResult<IEnumerable<PerfilViewModel>>();

            try
            {
                result.Result = _perfilApplication.Listar();
                result.Success = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return Content(HttpStatusCode.InternalServerError, result);
            }         
        }

        // GET api/perfis/5
        public IHttpActionResult Get(int id)
        {
            var result = new GenericResult<PerfilViewModel>();
            try
            {
                result.Result = _perfilApplication.Obter(id);
                result.Success = true;

                if(result.Result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return Content(HttpStatusCode.InternalServerError, result);
            }        
        }

        // POST api/perfis
        [HttpPost]
        public IHttpActionResult Post([FromBody]PerfilViewModel perfilVM)
        {
            var result = new GenericResult<PerfilViewModel>();

            var validatorResult = _validator.Validate(perfilVM);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = _perfilApplication.Cadastrar(perfilVM);
                    result.Success = true;
                    return Content(HttpStatusCode.Created, result);
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                    return Content(HttpStatusCode.InternalServerError, result);
                }
            }
            else
            {
                result.Errors = validatorResult.GetErrors();
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // PUT api/perfis/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]PerfilViewModel perfilVM)
        {
            var result = new GenericResult();

            var validatorResult = _validator.Validate(perfilVM);
            if (validatorResult.IsValid)
            {
                try
                {
                    var entity = _perfilApplication.Obter(id);

                    if(entity != null)
                    {
                        result.Success = _perfilApplication.Atualizar(perfilVM, id);
                        return Ok(result);
                    }
                    else
                    {
                        result.Success = false;
                        return Content(HttpStatusCode.NotFound, result);
                    }                 
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                    return Content(HttpStatusCode.InternalServerError, result);
                }
            }
            else
            {
                result.Success = false;
                result.Errors = validatorResult.GetErrors();
                return Content(HttpStatusCode.BadRequest, result);
            }     
        }

        // DELETE api/perfis/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = new GenericResult();

            try
            {
                var entity = _perfilApplication.Obter(id);
                if(entity != null)
                {
                    result.Success = _perfilApplication.Deletar(id);
                    return Ok(result);
                }
                else
                {
                    result.Success = false;
                    return Content(HttpStatusCode.NotFound, result);
                }
                
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                result.Success = false;
                return Content(HttpStatusCode.InternalServerError, result);
            }
        }
    }
}
