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
    public class UsuariosController : ApiController
    {
        private readonly UsuarioApplication _usuarioApplication;
        private readonly UsuarioValidator _validator;

        public UsuariosController(UsuarioApplication usuarioApplication, UsuarioValidator validator)
        {
            _usuarioApplication = usuarioApplication;
            _validator = validator;
        }
        // GET api/usuarios
        public IHttpActionResult Get()
        {
            var result = new GenericResult<IEnumerable<UsuarioViewModel>>();

            try
            {
                result.Result = _usuarioApplication.Listar();
                result.Success = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return Content(HttpStatusCode.InternalServerError, result);
            }
        }

        // GET api/usuarios/5
        public IHttpActionResult Get(int id)
        {
            var result = new GenericResult<UsuarioViewModel>();
            try
            {
                result.Result = _usuarioApplication.ObterComPerfil(id);
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

        // POST api/usuarios
        [HttpPost]
        public IHttpActionResult Post([FromBody]UsuarioViewModel usuarioVM)
        {
            var result = new GenericResult<UsuarioViewModel>();

            var validatorResult = _validator.Validate(usuarioVM);
            if(validatorResult.IsValid)
            {
                try
                {
                    result.Result = _usuarioApplication.Cadastrar(usuarioVM);
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

        // PUT api/usuarios/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]UsuarioViewModel usuarioVM)
        {
            var result = new GenericResult();

            var validatorResult = _validator.Validate(usuarioVM);
            if (validatorResult.IsValid)
            {
                try
                {
                    var entity = _usuarioApplication.Obter(id);

                    if(entity != null)
                    {
                        result.Success = _usuarioApplication.Atualizar(usuarioVM, id);
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
                result.Errors = validatorResult.GetErrors();
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // DELETE api/usuarios/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = new GenericResult();

            try
            {
                var entity = _usuarioApplication.Obter(id);

                if(entity != null)
                {
                    result.Success = _usuarioApplication.Deletar(id);
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
    }
}