<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaAtendimentos.aspx.cs" Inherits="Controle_ListaAtendimentos" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Listagem de Atendimentos</h2>
                <div class="clearfix">
                </div>
            </div>
            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left input_mask">
                <div class="row">
                    <div class="form-group">
                        <label class="control-label col-md-5" for="UsernameTextBox">
                            Informe o dia: <span class="required">*</span>
                        </label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txbData" class="form-control numeric" runat="server" data-inputmask="'mask': '99/99/9999'" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obrigatório"
                                Text="Campo obrigatório" ControlToValidate="txbData"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-4 col-sm-4 col-xs-8 ">
                            <asp:Button ID="btnPesquisa" runat="server" Text="Pesquisar" class="btn btn-primary"
                                OnClick="btnCarregarDados_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="Div1" data-parsley-validate class="form-horizontal form-label-left input_mask">
                <div class="row">
                    <asp:Label ID="lbMensagem" ForeColor="maroon" runat="server" Text="Label">
                        <p>* Os dados serão exportados para uma planilha. Fique atento ao download do arquivo.</p></asp:Label>
                </div>
            </div>
        </div>
        <asp:GridView ID="gvAtendimentos" runat="server">
        </asp:GridView>
    </div>
</asp:Content>