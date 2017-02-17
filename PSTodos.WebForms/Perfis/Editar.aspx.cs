using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;

namespace PSTodos.WebForms.Perfis
{
    public partial class Editar : System.Web.UI.Page
    {
        [Import]
        public IPerfilRESTService Service { get; set; }
        protected PerfilViewModel Perfil { get; set; }
        protected int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);

                if(Id != 0)
                {
                    var vm = Service.Obter(Id);

                    if (vm.Success && vm.Result != null)
                    {
                        txtNome.Text = vm.Result.Nome;
                        chkAtivo.Checked = vm.Result.Ativo;
                    }
                    else
                    {
                        Session["ToastrMsg"] = "Falha ao carregar Perfil.";
                        Session["ToastrType"] = "error";
                        Response.Redirect("/Perfis");
                    }
                }
                else
                {
                    Session["ToastrMsg"] = "Falha ao carregar Perfil.";
                    Session["ToastrType"] = "error";
                    Response.Redirect("/Perfis");
                }
                
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(Request.QueryString["id"]);
            var vm = new PerfilViewModel
            {
                Id = Id,
                Nome = txtNome.Text,
                Ativo = chkAtivo.Checked
            };

            var context = new ValidationContext(vm, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(vm, context, results, true);

            if (!isValid)
            {
                Session["ToastrMsg"] = "Dados inválidos.";
                Session["ToastrType"] = "warning";
                return;
            }
            else
            {                
                if(Id != 0)
                {
                    var result = Service.Editar(Id, vm);
                    if (!result.Success)
                    {
                        Session["ToastrMsg"] = "Falha ao alterar Perfil.";
                        Session["ToastrType"] = "error";
                        return;
                    }
                    else
                    {
                        Session["ToastrMsg"] = "Perfil alterado com sucesso.";
                        Session["ToastrType"] = "success";
                    }
                        
                }
                else
                {
                    Session["ToastrMsg"] = "Falha ao alterar Perfil.";
                    Session["ToastrType"] = "error";
                }

                Response.Redirect("/Perfis");
            }
        }
    }
}