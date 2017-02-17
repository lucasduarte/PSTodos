<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/Site.Master" Inherits="PSTodos.WebForms.Usuarios.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="section">
        <div class="container">
            <h4 style="float: left">Listagem de Usuários</h4>
            <div style="float: right; margin-top: 20px;">
                <a class="waves-effect waves-light btn teal" href="~/Usuarios/Cadastrar" runat="server"><i class="material-icons left">add</i>Novo Registro</a>
            </div>
            <br /><br />
            <% if (Result)
                { %>
                <table class="highlight bordered">
                    <thead>
                        <tr>
                            <th data-field="id">Id</th>
                            <th data-field="login">Login</th>
                            <th data-field="nome">Nome</th>
                            <th data-field="email">Email</th>
                            <th data-field="ativo">Status</th>
                            <th data-field="acoes">Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptUsuarios" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Id") %></td>
                                    <td><%# Eval("Login") %></td>
                                    <td><%# Eval("Nome") %></td>
                                    <td><%# Eval("Email") %></td>
                                    <td class="center-align">
                                        <asp:Panel runat="server" Visible='<%# (bool) Eval("Ativo") %>'>
                                            <span class="new badge green" data-badge-caption="Ativo" style="float: left"></span>
                                        </asp:Panel>
                                        <asp:Panel runat="server" Visible='<%# !((bool) Eval("Ativo")) %>'>
                                            <span class="new badge red" data-badge-caption="Inativo" style="float: left"></span>
                                        </asp:Panel>                                  
                                    </td>
                                    <td>                  
                                        <a class="waves-effect waves-light btn" style="padding: 0 1rem" 
                                            href='<%= ResolveClientUrl("~/Usuarios/Editar?id=") %><%# Eval("Id") %>'>
                                            <i class="material-icons">edit</i>
                                        </a>
                                        <asp:LinkButton runat="server" CssClass="waves-effect waves-light btn red" 
                                            style="padding: 0 1rem" ID="btnDeletar" OnClick="btnDeletar_Click"
                                            CommandArgument='<%# Eval("Id") %>'><i class="material-icons">delete</i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            <%} %>
            <% else
                { %>
                <h5>Nenhum resultado.</h5>
            <%} %>
        </div>
    </div>


</asp:Content>
