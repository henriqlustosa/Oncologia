<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="checkoutbe.aspx.cs" Inherits="Administrativo_checkoutbe" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        </div>
        <div class="row">
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    RH/Prontuário</label>
                <asp:TextBox ID="txbProntuario" runat="server" class="form-control numeric" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-5 col-sm-12 col-xs-12 form-group" enabled="false">
                <label>
                    Nome</label>
                <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>
                    Nascimento</label>
                <asp:TextBox ID="txbNascimento" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                <label>
                    Idade</label>
                <asp:TextBox ID="txbIdade" runat="server" class="form-control" Enabled="false"></asp:TextBox>
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
                <asp:DropDownList ID="ddlStatusFicha" runat="server" class="form-control" 
                    AutoPostBack="True" DataSourceID="SqlDataSource1" 
                    DataTextField="descricao_status" DataValueField="cod_status">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:psConnectionString %>" 
                    SelectCommand="SELECT [cod_status], [descricao_status], [ativo] FROM [status_ficha] WHERE ([ativo] = 'true') AND ([cod_status] != 0)">
                </asp:SqlDataSource>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                <label>
                    Profissional</label>
                <asp:DropDownList ID="ddlProfissional" runat="server" class="form-control" 
                    AutoPostBack="True" DataSourceID="SqlDataSource2" 
                    DataTextField="nome_profissional" DataValueField="cod_profissional">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:psConnectionString %>" 
                    SelectCommand="SELECT [cod_profissional], [nome_profissional], [conselho], [nr_conselho], [status_profissional] FROM [Profissional]">
                </asp:SqlDataSource>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
