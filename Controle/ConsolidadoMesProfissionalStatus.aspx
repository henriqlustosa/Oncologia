<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsolidadoMesProfissionalStatus.aspx.cs" Inherits="Controle_ConsolidadoMesProfissionalStatus" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <asp:TextBox ID="txbData" runat="server" data-inputmask="'mask': '99/9999'"></asp:TextBox>
    <asp:Button ID="btnGerar" runat="server" Text="Gerar Relatório" 
        onclick="btnGerar_Click" />
    
    <asp:Panel ID="Panel1" runat="server">
        <div>
         
         <CR:CrystalReportViewer ID="crvRelatorio" runat="server" 
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"  
            HasCrystalLogo="False" ToolPanelView="None" AutoDataBind="True" 
             HasToggleParameterPanelButton="False" BestFitPage="False" Width="1024px"  />  
    </div>
    </asp:Panel>
    
</asp:Content>

