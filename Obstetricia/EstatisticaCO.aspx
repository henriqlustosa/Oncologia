<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EstatisticaCO.aspx.cs" Inherits="Obstetricia_EstatisticaCO" Title="Oncologia - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js") %>'
        type="text/javascript"></script>

    <script src='<%= ResolveUrl("https://cdn.jsdelivr.net/npm/chart.js@2.8.0") %>' type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('.titulo').hide();
            $('#<%= btnPesquisa.ClientID %>').click(function() {
                $('.titulo').show();
            });
        });
    </script>

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
                            Estatística Obstetrícia</h2>
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
                <!-- Tabela -->
                <div class="titulo col-md-6 col-sm-12 col-xs-12">
                    <div class="x_panel tile ">
                        <div class="x_title">
                            <h2>
                                Quantitativo por Status</h2>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="gvQuantitativo" runat="server" CssClass="table table-sm table-striped table-bordered">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <!-- -->
                <div id="Div7" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Estatística</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvObstetricia" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound"
                            ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                <!-- Tabela -->
                <div class="x_panel titulo">
                    <div class="x_panel tile ">
                        <div class="x_title">
                            <h2>
                                Fichas em Aberto</h2>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="gvBeAbertos" runat="server" AutoGenerateColumns="False" CssClass="table table-sm table-striped table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="cod_ficha" HeaderText="Número BE" SortExpression="cod_ficha"
                                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                    <asp:BoundField DataField="dt_rh_be" HeaderText="Data do BE" SortExpression="dt_rh_be"
                                        HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                    <asp:BoundField DataField="nome_paciente" HeaderText="Paciente" SortExpression="nome_paciente"
                                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />
                                    <asp:BoundField DataField="tipo_paciente" HeaderText="Grupo Paciente" SortExpression="tipo_paciente"
                                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />
                                </Columns>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <!-- -->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
