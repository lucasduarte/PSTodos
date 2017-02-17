<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="PSTodos.WebForms.Perfis.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="section">
        <div class="container">
            <h4 style="float: left">Cadastro de Perfil</h4>
            <div class="row"> 
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s6">                         
                            <asp:TextBox ID="txtNome" CssClass="validate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ErrorMessage="O campo Nome é Obrigatório." 
                                ControlToValidate="txtNome" ForeColor="Red"></asp:RequiredFieldValidator> 
                            <asp:RegularExpressionValidator ID="revNome" runat="server" ErrorMessage="O campo Nome deve conter no máximo 150 caracteres."
                                ControlToValidate="txtNome" ValidationExpression = "^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                            <label for="txtNome">Nome</label>
                        </div>
                        <div class="input-field col s6">                   
                            <asp:CheckBox runat="server" ID="chkAtivo"/>  
                            <label for="MainContent_chkAtivo">Ativo</label>     
                        </div>
                    </div>
                    <asp:LinkButton CssClass="waves-effect waves-light btn" runat="server" OnClick="btnAlterar_Click"><i class="material-icons left">save</i>salvar</asp:LinkButton>           
                </div>                                   
            </div>
        </div>
    </div>
</asp:Content>
