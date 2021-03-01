<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsolidadoMesProfissional.aspx.cs" Inherits="Controle_ConsolidadoMesProfissional" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('.titulo').hide();
            $('#<%= btnPesquisa.ClientID %>').click(function() {
                $('.titulo').show();
            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            CONTROLE GERAL CONSULTAS DIA POR PROFISSIONAL - HSPM e RESGATE</h2>
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
                            <div class="form-group">
                                <div class="col-md-4 col-sm-4 col-xs-8 ">
                                    <asp:Button ID="Button1" runat="server" Text="Visualizar Impressão" class="btn btn-warning"
                                        OnClick="btnVisImpressao_Click" />
                                </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
                <div class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Baixas de Fichas por Profissional</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

