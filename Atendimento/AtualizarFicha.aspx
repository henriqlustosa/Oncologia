<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AtualizarFicha.aspx.cs" Inherits="Atendimento_AtualizarFicha" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Atualização do Boletim de Emergência <small><asp:Label ID="lbBE" runat="server" Text=""></asp:Label></small></h2>
            <div class="clearfix">
            </div>
        </div>
        
        <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left input_mask">
                <div class="row">
                    <div class="form-group">
                        <label class="control-label col-md-5" for="UsernameTextBox">
                            Informe o Número do BE:
                        </label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txbBE" class="form-control numeric" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obrigatório"
                                Text="Campo obrigatório" ControlToValidate="txbBE"></asp:RequiredFieldValidator>
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
        
        <div class="row">
        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Setor</label>
                <asp:TextBox ID="txbSetor" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Data da Ficha</label>
                <asp:TextBox ID="txbDtFicha" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    RH</label>
                <asp:TextBox ID="txbProntuario" runat="server" class="form-control numeric"></asp:TextBox>
            </div>
             <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    RF</label>
                <asp:TextBox ID="txbRF" runat="server" class="form-control numeric"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Outro Documento</label>
                <asp:TextBox ID="txbDocumento" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Cartão SUS</label>
                <asp:TextBox ID="txbCNS" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Tipo Paciente</label>
                <asp:DropDownList ID="ddlTipoPaciente" class="form-control" runat="server">
                    <asp:ListItem Text="MUNÍCIPE" Value="M"></asp:ListItem>
                    <asp:ListItem Text="FUNCIONÁRIO" Value="F"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            
            
            <div class="col-md-5 col-sm-12 col-xs-12 form-group" enabled="false">
                <label>
                    Nome</label>
                <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Nascimento</label>
                <asp:TextBox ID="txbNascimento" runat="server" class="form-control" ></asp:TextBox>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                <label>
                    Idade</label>
                <asp:TextBox ID="txbIdade" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Sexo</label>
                    <asp:DropDownList ID="ddlSexo" runat="server" AutoPostBack="true" class="form-control">
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Feminino</asp:ListItem>
                        <asp:ListItem>Não Informado</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Raça/Cor</label>
                    <asp:DropDownList ID="ddlRaca" runat="server" class="form-control" AutoPostBack="true">
                        <asp:ListItem>Branca</asp:ListItem>
                        <asp:ListItem>Preta</asp:ListItem>
                        <asp:ListItem>Parda</asp:ListItem>
                        <asp:ListItem>Amarela</asp:ListItem>
                        <asp:ListItem>Indígena</asp:ListItem>
                    </asp:DropDownList>
                </div>
        </div>
         
         <div class="row">
            <div class="col-md-3 col-sm-12 col-xs-12 form-group">
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
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
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
            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Procedência</label>
                    <asp:DropDownList ID="ddlProcedencia" runat="server" class="form-control">
                        <asp:ListItem Text="Espontânea"></asp:ListItem>
                        <asp:ListItem Text="Bombeiro"></asp:ListItem>
                        <asp:ListItem Text="Polícia Militar"></asp:ListItem>
                        <asp:ListItem Text="GCM"></asp:ListItem>
                        <asp:ListItem Text="Metrô"></asp:ListItem>
                        <asp:ListItem Text="AMA - Sé"></asp:ListItem>
                        <asp:ListItem Text="SAMU"></asp:ListItem>
                        <asp:ListItem Text="Ambulância Particular"></asp:ListItem>
                    </asp:DropDownList>
                </div>
        </div>
     
           <div class="row">
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Telefone 1</label>
                    <asp:TextBox ID="txbTelefone" MaxLength="20" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Telefone 2</label>
                    <asp:TextBox ID="txbTelefone1" MaxLength="20" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Telefone 3</label>
                    <asp:TextBox ID="txbTelefone2" MaxLength="20" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        E-mail</label>
                    <asp:TextBox ID="txbEmail" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
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
            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Button ID="btUpdate" runat="server" Text="Atualizar Dados" class="btn btn-primary" OnClick="btnAtualizar_Click" />
            </div>
        </div>
    </div>

</asp:Content>

