<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroImpressora.aspx.cs" Inherits="Admin_CadastroImpressora" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Cadastro de Impressora</h2>
                <div class="clearfix">
                </div>
            </div>
           
            <h4>Para a impressão de Ficha e Etiquetas as impressoras devem estar instaladas no servidor HSPMINS18</h4>
            
            <h4>Importante renomear e especificar o nome da impressora e a localização no servidor . Ex. TSC_Pronto_Socorro</h4>
            
            <h4>Posteriormente cadastradas no sistema com o mesmo nome da impressora do servidor</h4>
            
            
            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nome da Impressora
                    </label>
                    <asp:TextBox ID="txbNomeImpressora" class="form-control" runat="server"
                        AutoPostBack="true" required />
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Tipo</label>
                    <asp:DropDownList ID="ddlTipo" runat="server" class="form-control">
                    <asp:ListItem Selected="True"  >Térmica</asp:ListItem>
                    <asp:ListItem>Laser</asp:ListItem>
                    </asp:DropDownList>
                   
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
                    <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" OnClick="btnGravar_Click" />
                </div>
            </div>
        </div>
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Lista de Impressoras</h2>
                <div class="clearfix">
                </div>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_impressora"
                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1"
                Width="100%" OnPreRender="GridView1_PreRender">
                
                <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="id_impressora" HeaderText="Id_impressora" SortExpression="id_impressora"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="nome_impressora" HeaderText="Nome impressora" SortExpression="nome_impressora"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />
                    <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo"
                        HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                    <asp:BoundField DataField="descricao_impressora" HeaderText="Descrição" SortExpression="descricao_impressora"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="ip_impressora" HeaderText="ip_impressora" SortExpression="ip_impressora"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
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

