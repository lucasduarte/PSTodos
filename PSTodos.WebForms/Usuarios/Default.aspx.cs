using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web.UI.WebControls;

namespace PSTodos.WebForms.Usuarios
{
    public partial class Default : System.Web.UI.Page
    {
        [Import]
        public IUsuarioRESTService Service { get; set; }
        protected bool Result { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var vm = Service.Listar();
            Result = vm.Result.Any();
            rptUsuarios.DataSource = vm.Result;
            rptUsuarios.DataBind();
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            var vm = Service.Remover(Convert.ToInt32(btn.CommandArgument));

            if(vm.Success)
            {
                Session["ToastrMsg"] = "Usuário excluído com sucesso.";
                Session["ToastrType"] = "success";
            }
            else
            {
                Session["ToastrMsg"] = "Falha ao excluir Usuário.";
                Session["ToastrType"] = "error";
            }

            Response.Redirect("~/Usuarios");
        }
    }
}