<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImprimirEtiqueta.aspx.cs" Inherits="Etiqueta_ImprimirEtiqueta" Title="Pronto Socorro - HSPM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página teste para impressão de etiquetas</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Ip Computador:
        <asp:Label ID="lbIp" runat="server" Text="IP"></asp:Label>
        <br />
        Nome Computador:
        <asp:Label ID="lbHostname" runat="server" Text="hostname"></asp:Label>
        <br />
        Nome Impressora:
        <asp:Label ID="lbNomeImpressora" runat="server" Text="nome_impressora"></asp:Label>
    </div>
    <div>
    Número do BE:
        <asp:TextBox ID="txbNumBE" runat="server"></asp:TextBox>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" 
            onclick="btnImprimir_Click" />
    </div>
    </form>
</body>
</html>
