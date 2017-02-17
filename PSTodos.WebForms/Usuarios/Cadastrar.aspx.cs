using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;

namespace PSTodos.WebForms.Usuarios
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        [Import]
        public IUsuarioRESTService Service { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDtInclusao.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var vm = new UsuarioViewModel
            {
                Login = txtLogin.Text,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Ativo = chkAtivo.Checked
            };

            var context = new ValidationContext(vm, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(vm, context, results, true);

            if (!isValid)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                        "toastr_message", "toastr.error('Falha ao cadastrar Usuário.', '')", true);
                return;
            }
            else
            {
                var result = Service.Cadastrar(vm);
                if (result.Success)
                {
                    Response.Redirect("/Usuarios/Editar?id=" + result.Result.Id);
                    Page.ClientScript.RegisterStartupScript(this.GetType(),
                            "toastr_message", "toastr.success('Usuário cadastrado com sucesso.', '')", true);
                }                 
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(),
                        "toastr_message", "toastr.error('Falha ao cadastrar Usuário.', '')", true);
                    return;               
                }       
            }
        }
    }
}