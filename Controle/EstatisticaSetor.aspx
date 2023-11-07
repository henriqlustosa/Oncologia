<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EstatisticaSetor.aspx.cs" Inherits="Controle_EstatisticaSetor" Title="Oncologia - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            Estatística por Setor</h2>
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
                
                
                <div id="Div1" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Clínica Médica</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvCM" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                
                <div id="Div2" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Cirurgia Geral</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvCG" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                
                <div id="Div3" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Neurocirurgia</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvNeuro" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                
                <div id="Div4" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Traumatologia</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvTrauma" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                
                <div id="Div5" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Buco Maxilo</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvBuco" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                <div id="Div6" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Pediatria</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvPediatria" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                <div id="Div7" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Obstetrícia</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvObstetricia" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                
                <div id="Div8" class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            COVID</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvCOVID" runat="server" OnRowDataBound="gvAplicaCor_RowDataBound" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
