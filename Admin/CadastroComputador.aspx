<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroComputador.aspx.cs" Inherits="Admin_CadastroComputador" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Cadastro de Computadores para Impressão de Etiquetas</h2>
                <div class="clearfix">
                </div>
            </div>
           
            
            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nome do Computador
                    </label>
                    <asp:TextBox ID="txbNomeComputador" class="form-control" runat="server"
                        AutoPostBack="true" required />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Descrição
                    </label>
                    <asp:TextBox ID="txbDescricao" class="form-control" runat="server" AutoPostBack="true" required />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        IP
                    </label>
                    <asp:TextBox ID="txbIp" class="form-control" runat="server" AutoPostBack="true" required />
                </div>
            </div>
            
            
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Impressora</label>
                   
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="nome_impressora" DataValueField="id_impressora">
                    </asp:DropDownList>
                    
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:psConnectionString %>"
                        SelectCommand="SELECT [id_impressora], [nome_impressora] FROM [Impressoras]">
                    </asp:SqlDataSource>
                </div>
            </div>
            
            
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" />
                </div>
            </div>
        </div>
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Lista de Computadores</h2>
                <div class="clearfix">
                </div>
            </div>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_computador"
                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1"
                Width="100%" OnPreRender="GridView1_PreRender">
                
                <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="id_computador" HeaderText="Id_computador" SortExpression="id_computador"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="nome_computador" HeaderText="Nome Computador" SortExpression="nome_computador"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />
                    <asp:BoundField DataField="descricao_computador" HeaderText="Descrição do Computador" SortExpression="descricao_computador"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />
                    <asp:BoundField DataField="ip_computador" HeaderText="IP Computador" SortExpression="ip_computador"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="nome_impressora" HeaderText="Impressora" SortExpression="nome_impressora"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />
                    <asp:BoundField DataField="descricao_impressora" HeaderText="Descricao da Impressora" SortExpression="descricao_impressora"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

