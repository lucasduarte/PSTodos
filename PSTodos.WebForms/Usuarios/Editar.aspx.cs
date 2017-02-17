using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.UI.WebControls;

namespace PSTodos.WebForms.Usuarios
{
    public partial class Editar : System.Web.UI.Page
    {
        [Import]
        public IUsuarioRESTService Service { get; set; }
        [Import]
        public IUsuarioPerfilRESTService usuarioPerfilService { get; set; }
        [Import]
        public IPerfilRESTService perfilService { get; set; }
        protected UsuarioViewModel Usuario { get; set; }
        protected int Id { get; set; }
        protected bool PossuiPerfil { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Id = Convert.ToInt32(Request.QueryString["id"]);

                if (Id != 0)
                {
                    var vm = Service.Obter(Id);

                    if (vm.Success && vm.Result != null)
                    {
                        txtLogin.Text = vm.Result.Login;
                        txtNome.Text = vm.Result.Nome;
                        txtEmail.Text = vm.Result.Email;
                        txtSenha.Text = vm.Result.Senha;
                        chkAtivo.Checked = vm.Result.Ativo;
                        txtDtInclusao.Text = vm.Result.DtInclusao.ToString("dd/MM/yyyy");
                        PossuiPerfil = vm.Result.Perfis.Any();

                        var perfisList = perfilService.Listar().Result;

                        ddlPerfis.DataSource = perfisList;
                        ddlPerfis.DataValueField = "Id";
                        ddlPerfis.DataTextField = "Nome";
                        ddlPerfis.DataBind();
                        ddlPerfis.Items.Insert(0, "Selecione o perfil desejado");

                        rptPerfis.DataSource = vm.Result.Perfis;
                        rptPerfis.DataBind();
                    }
                    else
                    {
                        Response.Redirect("/Usuarios");
                    }
                }
                else
                {
                    Response.Redirect("/Usuarios");
                }

            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(Request.QueryString["id"]);
            var vm = new UsuarioViewModel
            {
                Id = Id,
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
                return;
            }
            else
            {
                if (Id != 0)
                {
                    var result = Service.Editar(Id, vm);
                    if (!result.Success)
                        return;
                }
                Response.Redirect("/Usuarios");
            }
        }

        protected void btnAdicionarPerfil_Click(object sender, EventArgs e)
        {
            int usuarioId = Convert.ToInt32(Request.QueryString["id"]);

            if(usuarioId != 0)
            {
                var vm = usuarioPerfilService.AdicionarPerfil(usuarioId, Convert.ToInt32(ddlPerfis.SelectedValue));

                if(vm.Success)
                {
                    
                }
                else
                {
                   
                }

                Response.Redirect("/Usuarios/Editar?id=" + usuarioId);
            }    
        }

        protected void btnRemoverPerfil_Click(object sender, EventArgs e)
        {
            int usuarioId = Convert.ToInt32(Request.QueryString["id"]);
            LinkButton btn = (LinkButton)sender;
            int perfilId = Convert.ToInt32(btn.CommandArgument);

            if (usuarioId != 0)
            {
                var vm = usuarioPerfilService.RemoverPerfil(usuarioId, perfilId);

                if (vm.Success)
                {

                }
                else
                {

                }

                Response.Redirect("/Usuarios/Editar?id=" + usuarioId);
            }
        }
    }
}