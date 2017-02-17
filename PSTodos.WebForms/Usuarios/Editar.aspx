<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="PSTodos.WebForms.Usuarios.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="section">
        <div class="container">
            <h4 style="float: left">Alteração de Usuário</h4>
            <div class="row"> 
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s6">                         
                            <asp:TextBox ID="txtLogin" CssClass="validate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ErrorMessage="O campo Login é Obrigatório." 
                                ControlToValidate="txtLogin" ForeColor="Red"></asp:RequiredFieldValidator>  
                            <asp:RegularExpressionValidator ID="revLogin" runat="server" ErrorMessage="O campo Login deve conter no máximo 20 caracteres."
                                ControlToValidate="txtLogin" ValidationExpression = "^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                            <label for="MainContent_txtLogin">Login</label>
                        </div>
                        <div class="input-field col s6">                         
                            <asp:TextBox ID="txtNome" CssClass="validate" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revNome" runat="server" ErrorMessage="O campo Nome deve conter no máximo 250 caracteres."
                                ControlToValidate="txtNome" ValidationExpression = "^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            <label for="MainContent_txtNome">Nome</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s6">                         
                            <asp:TextBox ID="txtEmail" CssClass="validate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="O campo Email é Obrigatório." 
                                ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>  
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="O campo Email deve conter no máximo 150 caracteres."
                                ControlToValidate="txtEmail" ValidationExpression = "^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                            <label for="MainContent_txtEmail">Email</label>
                        </div>
                        <div class="input-field col s6">      
                            <asp:TextBox ID="txtSenha" CssClass="validate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ErrorMessage="O campo Senha é Obrigatório." 
                                ControlToValidate="txtSenha" ForeColor="Red"></asp:RequiredFieldValidator>  
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="O campo Senha deve conter no máximo 50 caracteres."
                                ControlToValidate="txtSenha" ValidationExpression = "^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            <label for="MainContent_txtSenha">Senha</label>                            
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s6">  
                            <asp:CheckBox runat="server" ID="chkAtivo"/>  
                            <label for="MainContent_chkAtivo">Ativo</label>   
                        </div>
                        <div class="input-field col s6">    
                            <asp:TextBox ID="txtDtInclusao" CssClass="validate" runat="server" Enabled="false"></asp:TextBox>
                            <label for="MainContent_txtDtInclusao">Data de Inclusão</label>
                        </div>        
                    </div>
                    <asp:LinkButton CssClass="waves-effect waves-light btn" runat="server" OnClick="btnAlterar_Click"><i class="material-icons left">save</i>salvar</asp:LinkButton>           
                </div>                                   
            </div>

            <div class="row">
            <br><br>
            <h5>Perfis do Usuário</h5>
            <div class="row">
                <div class="input-field col s10">
                    <asp:DropDownList ID="ddlPerfis" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="input-field col s2">
                    <asp:LinkButton runat="server" class="waves-effect waves-light btn" OnClick="btnAdicionarPerfil_Click">
                        <i class="material-icons">add</i></asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <% if (PossuiPerfil)
                    {%>
                    
                    <table class="highlight bordered">
                        <thead>
                            <tr>
                                <th data-field="perfil">Perfil</th>
                                <th data-field="excluir">Remover</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptPerfis">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Nome") %></td>
                                        <td>
                                            <asp:LinkButton runat="server" class="waves-effect waves-light btn red" 
                                                style="padding: 0 1rem" CommandArgument='<%# Eval("Id") %>' OnClick="btnRemoverPerfil_Click"><i class="material-icons">delete</i></asp:LinkButton>                                   
                                        </td>
                                    </tr>
                                </ItemTemplate>      
                            </asp:Repeater>                
                        </tbody>
                    </table>

                <%} %>
                <% else
                {%>
                    <br /><br />
                    <h5>Nenhum Perfil cadastrado.</h5>
                <%} %>              
            </div>
        </div>  
        </div>
    </div>
</asp:Content>
