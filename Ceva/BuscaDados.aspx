<%@ Page Title="" Language="vb"  AutoEventWireup="false"  CodeBehind="BuscaDados.aspx.vb" Inherits="Ceva.BuscaDados"  MasterPageFile="~/Site.Master"  Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
        <div class="form-group">
            <label for="txtViagem">Digite a Viagem:</label>
            <asp:TextBox ID="txtViagem"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvViagem" runat="server" ControlToValidate="txtViagem" 
            ErrorMessage="O campo Viagem é obrigatório." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:Button ID="btnPesquisa" runat="server" Text="Pesquisar" CssClass="btn btn-primary"   OnClick="btnBuscar_Click" />
        </div>
      
        <div>
            <asp:Panel ID="pnlReport" runat="server" Visible="False">
                <table class="table table-striped"> 
                       <thead class="thead-dark">
                    <tr>

                        <th>Code 5C</th>
                        <th>Code 5P</th>
                        <th>Fornecedor</th>
                        <th>Codes</th>
                        <th>Pedidos</th>
                    </tr>
                           </thead>
                 <asp:Repeater ID="rptViagem" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Code_5C") %></td>
                                <td><%# Eval("Code_5P") %></td>
                                <td><%# Eval("Fornecedor") %></td>
                                <td>
                                    <ul class="list-unstyled">
                                        <%# ModulandoLista(CType(Eval("Codes"), List(Of String))) %>
                                    </ul>
                                </td>
                                <td>
                                    <ul class="list-unstyled">
                                         <%# ModulandoLista(CType(Eval("Pedidos"), List(Of String))) %>
                                    </ul>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </asp:Panel>
              <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
    
        </div>
 
      
</asp:Content>