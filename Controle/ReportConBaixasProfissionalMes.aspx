<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportConBaixasProfissionalMes.aspx.cs" Inherits="Report_ReportConBaixasProfissionalMes" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <div>
     <asp:TextBox ID="txbData" runat="server" data-inputmask="'mask': '99/9999'"></asp:TextBox>
    <asp:Button ID="btnGerar" runat="server" Text="Gerar Relatório" 
        onclick="btnGerar_Click" />
      
      
        <asp:Panel ID="Panel1" runat="server">
        
           <CR:CrystalReportViewer ID="crvRelatorioProf" runat="server" 
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"  
            HasCrystalLogo="False" ToolPanelView="None" AutoDataBind="True" 
             HasToggleParameterPanelButton="False" BestFitPage="False" Width="1300px"  />  
        
        </asp:Panel>    
        
    </div>
</asp:Content>

