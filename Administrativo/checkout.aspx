<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="checkout.aspx.cs" Inherits="Administrativo_checkout" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('.numeric').keyup(function() {
                $(this).val(this.value.replace(/\D/g, ''));
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
                            Check-Out</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left input_mask">
                        <div class="row">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="UsernameTextBox">
                                    B.E.: <span class="required">*</span>
                                </label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txbBE" class="form-control numeric" runat="server" AutoPostBack="true"
                                        required />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-sm-4 col-xs-8 ">
                                    <asp:Button ID="SearchButton" runat="server" Text="Pesquisar" class="btn btn-primary"
                                        OnClick="btnPesquisar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="x_panel">
                    <div class="row">
                        <div class="form-group">
                            <asp:Label ID="Msg" runat="server" ForeColor="maroon" class="control-label col-md-12" /><br />
                        </div>
                    </div>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="cod_ficha" OnRowCommand="grdMain_RowCommand" CellPadding="4" ForeColor="#333333"
                        GridLines="None" Width="100%">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="cod_ficha" HeaderText="Número BE" SortExpression="cod_ficha"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="dt_rh_be" HeaderText="Data" SortExpression="dt_rh_be"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="nome_paciente" HeaderText="Paciente" SortExpression="nome_paciente"
                                ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="idade" HeaderText="Idade" SortExpression="idade" ItemStyle-CssClass="hidden-xs"
                                HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="sexo" HeaderText="Sexo" SortExpression="sexo" ItemStyle-CssClass="hidden-xs"
                                HeaderStyle-CssClass="hidden-xs" />
                            <asp:BoundField DataField="setor" HeaderText="Setor" SortExpression="setor" ItemStyle-CssClass="hidden-xs"
                                HeaderStyle-CssClass="hidden-xs" />
                            <asp:TemplateField HeaderStyle-CssClass="sorting_disabled">
                                <ItemTemplate>
                                    <div class="form-inline">
                                        <asp:LinkButton ID="gvlnkCheckOut" CommandName="checkoutRecord" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                            CssClass="btn btn-success" runat="server">
                                    <i class="fa fa-check-square-o" title="Baixa"></i> 
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
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