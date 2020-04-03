<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AberturaFicha.aspx.cs" Inherits="Atendimento_AberturaFicha" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js") %>'
        type="text/javascript"></script>
  <!-- iCheck -->
    <script src='<%= ResolveUrl("~/vendors/iCheck/icheck.min.js") %>' type="text/javascript"></script>

    <!-- iCheck -->
    <link href="../vendors/iCheck/skins/line/blue.css" rel="stylesheet" />
    
    
    
    <script type="text/javascript">
        $(document).ready(function() {
            $('input').each(function() {
                var self = $(this),
               label = self.next(),
               label_text = label.text();

                label.remove();
                self.iCheck({
                    checkboxClass: 'icheckbox_line-blue',
                    insert: '<div class="icheck_line-icon"></div>' + label_text
                });
            });
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <h1>
        Boletin de Emergência</h1>
    <div class="container">
        <div class="form-group row">
            <label for="txtBE" class="col-sm-1 col-form-label">
                BE:</label>
            <div class="col-sm-2">
                <asp:Label ID="txbBE" runat="server" Text="123456789"></asp:Label>
            </div>
            <label for="txtData" class="col-sm-1 col-form-label">
                Data:</label>
            <div>
                <asp:Label ID="txtData" runat="server" Text="__/__/____"></asp:Label>
            </div>
        </div>
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Informações do Paciente
                    <asp:Label ID="lbProntuario" runat="server" Text="" Style="color: Black"></asp:Label></h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        RH/Prontuário</label>
                    <asp:TextBox ID="txbProntuario" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Documento</label>
                    <asp:TextBox ID="txbDocumento" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nome</label>
                    <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control"></asp:TextBox>
                </div>
                
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nascimento</label>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        Idade</label>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Sexo</label>
                    <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Raça/Cor</label>
                    <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
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
                    <label>
                        Queixa</label>
                    <asp:TextBox ID="TextBox5" runat="server" class="form-control" TextMode="MultiLine"
                        Rows="4"></asp:TextBox>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                    <asp:checkboxlist runat="server" id="chkFormaChegada" RepeatDirection="Horizontal" >
                        <asp:listitem text="Caso Policial" value="1"></asp:listitem>
                        <asp:listitem text="Plano de Saúde" value="2"></asp:listitem>
                        <asp:listitem text="Trauma" value="3"></asp:listitem>
                        <asp:listitem text="Acidente de Trabalho" value="4"></asp:listitem>
                        <asp:listitem text="Veio de Ambulância" value="5"></asp:listitem>
                    </asp:checkboxlist>
                </div>
            </div>
      
        </div>
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Encaminhamento
                    <asp:Label ID="Label1" runat="server" Text="" Style="color: Black"></asp:Label></h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="form-group row">
                <label for="txbSetor" class="col-sm-1 col-form-label">
                    Setor:</label>
                <div>
                    <asp:TextBox ID="txbSetor" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="x_content">
            <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" />
        </div>
    </div>
    
</asp:Content>
