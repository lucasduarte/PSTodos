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
                Session["ToastrMsg"] = "Dados inválidos.";
                Session["ToastrType"] = "warning";
                return;
            }
            else
            {
                var result = Service.Cadastrar(vm);
                if (result.Success)
                {
                    Session["ToastrMsg"] = "Usuário cadastrado com sucesso.";
                    Session["ToastrType"] = "success";
                    Response.Redirect("/Usuarios/Editar?id=" + result.Result.Id);           
                }                 
                else
                {
                    Session["ToastrMsg"] = "Falha ao cadastrar Usuário.";
                    Session["ToastrType"] = "error";
                    return;               
                }       
            }
        }
    }
}