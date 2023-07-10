<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EtiquetasAvulso.aspx.cs" Inherits="Atendimento_EtiquetasAvulso" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="refresh" content="1000" />

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("input").attr("autocomplete", "off");

            $('.numeric').keyup(function() {
                $(this).val(this.value.replace(/\D/g, ''));
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--<div>
        Ip Computador:
        <asp:Label ID="lbIp" runat="server" Text="IP"></asp:Label>
        <br />
        Nome Computador:
        <asp:Label ID="lbHostname" runat="server" Text="hostname"></asp:Label>
        <br />
        <asp:Label ID="lbhostname1" runat="server" Text="hostname"></asp:Label>
        <br />
        Nome Impressora:
        <asp:Label ID="lbNomeImpressora" runat="server" Text="nome_impressora"></asp:Label>
    </div>--%>
    <hr />
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Impressão de Etiquetas Avulso</h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Número da Ficha:</label>
                    <asp:TextBox ID="txbNumBE" runat="server" class="form-control numeric" required></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                                    <label>Impressoras:</label>
                                    <asp:DropDownList ID="ddlImpressoraEtiqueta" class="form-control" runat="server" >
                                            <asp:ListItem>PSI - Guichê</asp:ListItem>
                                            <asp:ListItem>TSC_GUICHE_PS</asp:ListItem>
                                            <asp:ListItem>TSC_GRIPARIO</asp:ListItem>
                                            <asp:ListItem>TSC_CO</asp:ListItem>
                                            <%--<asp:ListItem>Informatica</asp:ListItem>--%>
                                           
                                    </asp:DropDownList>
                                    </div>
                <div class="form-group">
                    <label>
                        Quantidade de Etiquetas:</label>
                    <asp:DropDownList ID="ddlQtdEtiquetas" class="form-control" runat="server">
                        <asp:ListItem Selected="True">1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" OnClick="btnImprimir_Click"
                        class="btn btn-primary gravar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>