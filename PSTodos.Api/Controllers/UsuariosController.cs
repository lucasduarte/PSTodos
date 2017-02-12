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
        public GenericResult<IEnumerable<UsuarioViewModel>> Get()
        {
            var result = new GenericResult<IEnumerable<UsuarioViewModel>>();

            try
            {
                result.Result = _usuarioApplication.Listar();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // GET api/usuarios/5
        public GenericResult<UsuarioViewModel> Get(int id)
        {
            var result = new GenericResult<UsuarioViewModel>();
            try
            {
                result.Result = _usuarioApplication.Obter(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // POST api/usuarios
        [HttpPost]
        public GenericResult<UsuarioViewModel> Post([FromBody]UsuarioViewModel usuarioVM)
        {
            var result = new GenericResult<UsuarioViewModel>();

            var validatorResult = _validator.Validate(usuarioVM);
            if(validatorResult.IsValid)
            {
                try
                {
                    result.Result = _usuarioApplication.Cadastrar(usuarioVM);
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

        // PUT api/usuarios/5
        [HttpPut]
        public GenericResult Put(int id, [FromBody]UsuarioViewModel usuarioVM)
        {
            var result = new GenericResult();

            var validatorResult = _validator.Validate(usuarioVM);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Success = _usuarioApplication.Atualizar(usuarioVM, id);
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

        // DELETE api/usuarios/5
        [HttpDelete]
        public GenericResult Delete(int id)
        {
            var result = new GenericResult();

            try
            {
                
                result.Success = _usuarioApplication.Deletar(id);
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;       

        }
    }
}