<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="checkoutbe.aspx.cs" Inherits="Administrativo_checkoutbe" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $('.hidden').hide();
            $('.hidden').prop('required', false);

            $('.ddlStatus').change(function() {
                var value = $(".ddlStatus option:selected").val();
                if (value == 4) {
                    $('.hidden').show();
                    $('.hidden').prop('required', true);
                } else {
                    $('.hidden').hide();
                    $('.hidden').prop('required', false);
                }
            });
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Boletim de Emergência -<small>Nº
                    <asp:Label ID="lbBE" runat="server" Text="lbBE"></asp:Label></small></h2>
            <div class="clearfix">
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Setor</label>
                <asp:TextBox ID="txbSetor" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Tipo Paciente</label>
                <asp:TextBox ID="txbTipoPaciente" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Data da Ficha</label>
                <asp:TextBox ID="txbDtFicha" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    RH/Prontuário</label>
                <asp:TextBox ID="txbProntuario" runat="server" class="form-control numeric"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Documento</label>
                <asp:TextBox ID="txbDocumento" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Cartão SUS</label>
                <asp:TextBox ID="txbCNS" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-5 col-sm-12 col-xs-12 form-group" enabled="false">
                <label>
                    Nome</label>
                <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Nascimento</label>
                <asp:TextBox ID="txbNascimento" runat="server" class="form-control" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                <label>
                    Idade</label>
                <asp:TextBox ID="txbIdade" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <label>
                    Queixa</label>
                <asp:TextBox ID="txbQueixa" runat="server" class="form-control" TextMode="MultiLine"
                    Rows="4" required Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                <label>
                    Endereço</label>
                <asp:TextBox ID="txbEndereco" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                <label>
                    Número</label>
                <asp:TextBox ID="txbNumero" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                <label>
                    Complemento</label>
                <asp:TextBox ID="txbComplemento" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Bairro</label>
                <asp:TextBox ID="txbBairro" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Município</label>
                <asp:TextBox ID="txbMunicipio" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                <label>
                    UF</label>
                <asp:TextBox ID="txbUF" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                <label>
                    CEP</label>
                <asp:TextBox ID="txbCEP" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                <label>
                    Nome do Pai/Mãe</label>
                <asp:TextBox ID="txbPais" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                <label>
                    Responsável</label>
                <asp:TextBox ID="txbResponsavel" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                <label>
                    Telefone</label>
                <asp:TextBox ID="txbTelefone" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                <label>
                    Procedência</label>
                <asp:TextBox ID="txbProcedencia" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Button ID="btUpdate" runat="server" Text="Atualizar Dados" class="btn btn-primary" />
            </div>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Baixa</h2>
            <div class="clearfix">
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Status</label>
                <asp:DropDownList ID="ddlStatusFicha" runat="server" class="form-control ddlStatus"
                    AutoPostBack="False" DataSourceID="SqlDataSource1" DataTextField="descricao_status"
                    DataValueField="cod_status">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:psConnectionString %>"
                    SelectCommand="SELECT [cod_status], [descricao_status], [ativo] FROM [status_ficha] WHERE ([ativo] = 'true') AND ([cod_status] != 0)">
                </asp:SqlDataSource>
            </div>
            <div class="col-md-4 col-sm-12 col-xs-12 form-group hidden">
                <label>
                    Justificativa</label>
                <asp:TextBox ID="txbJustifica" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                <label>
                    Profissional</label>
                <asp:DropDownList ID="ddlProfissional" runat="server" DataTextField="nome_profissional"
                    DataValueField="cod_profissional" class="form-control" AutoPostBack="False">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" OnClick="btnGravar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
