<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConsolidadoMes.aspx.cs" Inherits="Controle_ConsolidadoMes" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Consolidado Mês</h2>
                <div class="clearfix">
                </div>
            </div>
            
            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left input_mask">
                <div class="row">
                    <div class="form-group">
                        <label class="control-label col-md-5" for="UsernameTextBox">
                            Informe o mês e ano: <span class="required">*</span>
                        </label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txbData" class="form-control numeric" runat="server" data-inputmask="'mask': '99/9999'" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obrigatório"
                                Text="Campo obrigatório" ControlToValidate="txbData"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4 col-sm-4 col-xs-8 ">
                            <asp:Button ID="btnPesquisa" runat="server" Text="Pesquisar" class="btn btn-primary"
                                OnClick="btnPesquisar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
      
         <div id="con_porta" class="x_panel">
            <div class="x_title">
                <h2>
                    Consultas Porta</h2>
                <div class="clearfix">
                </div>
            </div>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </div>
       
       
    </div>
     </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
