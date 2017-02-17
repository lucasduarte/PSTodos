using PSTodos.Api.Results;
using PSTodos.Api.Validators;
using PSTodos.Application;
using PSTodos.Application.ViewModels;
using System;
using System.Net;
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
        [Route("api/Usuarios/{usuarioId}/Perfis/{perfilId}")]
        public IHttpActionResult Post(int usuarioId, int perfilId)
        {
            var result = new GenericResult<UsuarioPerfilViewModel>();

            try
            {
                result.Result = _usuarioPerfilApplication.AdicionarPerfil(usuarioId, perfilId);
                result.Success = true;

                return Content(HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return Content(HttpStatusCode.InternalServerError, result);
            }
        }

        // DELETE api/usuarios/1/perfis/1
        [HttpDelete]
        [Route("api/Usuarios/{usuarioId}/Perfis/{perfilId}")]
        public IHttpActionResult Delete(int usuarioId, int perfilId)
        {
            var result = new GenericResult();

            try
            {
                var entity = _usuarioPerfilApplication.Obter(usuarioId, perfilId);

                if(entity != null)
                {
                    result.Success = _usuarioPerfilApplication.RemoverPerfil(usuarioId, perfilId);
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
                result.Success = false;
                result.Errors = new string[] { ex.Message };
                return Content(HttpStatusCode.InternalServerError, result);
            }
        }
    }
}