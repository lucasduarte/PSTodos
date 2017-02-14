using PSTodos.Api.Extensions;
using PSTodos.Api.Results;
using PSTodos.Api.Validators;
using PSTodos.Application;
using PSTodos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PSTodos.Api.Controllers
{
    public class UsuariosPerfisController : ApiController
    {
        private readonly UsuarioPerfilApplication _usuarioPerfilApplication;
        private readonly UsuarioPerfilValidator _validator;

        public UsuariosPerfisController(UsuarioPerfilApplication usuarioPerfilApplication, UsuarioPerfilValidator validator)
        {
            _usuarioPerfilApplication = usuarioPerfilApplication;
            _validator = validator;
        }

        // POST api/usuarios/1/perfil/1
        [HttpPost]
        [Route("api/usuarios/{usuarioId}/perfis/{perfilId}")]
        public GenericResult<UsuarioPerfilViewModel> Post(int usuarioId, int perfilId)
        {
            var result = new GenericResult<UsuarioPerfilViewModel>();

            try
            {
                result.Result = _usuarioPerfilApplication.AdicionarPerfil(usuarioId, perfilId);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }
           
            return result;
        }

        // DELETE api/usuarios/1/perfis/1
        [HttpDelete]
        [Route("api/usuarios/{usuarioId}/perfis/{perfilId}")]
        public GenericResult Delete(int usuarioId, int perfilId)
        {
            var result = new GenericResult();

            try
            {
                result.Success = _usuarioPerfilApplication.RemoverPerfil(usuarioId, perfilId);
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;

        }
    }
}