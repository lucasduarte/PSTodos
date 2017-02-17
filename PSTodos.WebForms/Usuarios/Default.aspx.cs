using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace PSTodos.WebForms.Usuarios
{
    public partial class Default : System.Web.UI.Page
    {
        private UsuarioRESTService _service = new UsuarioRESTService();
        protected bool Result { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var vm = _service.ObterUsuarios();
            Result = vm.Result.Any();
            rptUsuarios.DataSource = vm.Result;
            rptUsuarios.DataBind();
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            var vm = _service.RemoverUsuario(Convert.ToInt32(btn.CommandArgument));
        }
    }
}