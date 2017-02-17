using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;

namespace PSTodos.WebForms.Perfis
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        [Import]
        public IPerfilRESTService Service { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var vm = new PerfilViewModel
            {
                Nome = txtNome.Text,
                Ativo = chkAtivo.Checked
            };

            var context = new ValidationContext(vm, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(vm, context, results, true);

            if (!isValid)
            {
                return;
            }
            else
            {
                var result = Service.Cadastrar(vm);
                if (result.Success)
                    Response.Redirect("/Perfis");
                else
                    return;
            }
        }
    }
}