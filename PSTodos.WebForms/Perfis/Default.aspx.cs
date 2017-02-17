using PSTodos.RESTServices;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web.UI.WebControls;

namespace PSTodos.WebForms.Perfis
{
    public partial class Default : System.Web.UI.Page
    {
        [Import]
        public IPerfilRESTService Service { get; set; }
        protected bool Result { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var vm = Service.Listar();
            Result = vm.Result.Any();
            rptPerfis.DataSource = vm.Result;
            rptPerfis.DataBind();
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            
            LinkButton btn = (LinkButton)sender;

            var vm = Service.Remover(Convert.ToInt32(btn.CommandArgument));

            if(vm.Success)
            {
                Session["ToastrMsg"] = "Perfil excluído com sucesso.";
                Session["ToastrType"] = "success";
            }
            else
            {
                Session["ToastrMsg"] = "Erro ao excluir Perfil.";
                Session["ToastrType"] = "error";
            }

            Response.Redirect("~/Perfis");
        }

    }
}