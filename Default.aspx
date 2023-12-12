<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/login.css" rel="stylesheet" />
    <link href="bootstrap5/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="shortcut icon" href="img/Logo_HSPM_.png" type="image/x-icon" />
    <title>Login - Chamado Informática</title>
</head>
<body class="text-center img-background">
    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Home.aspx">
            <LayoutTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>
                                <h4 class="title-login">Sistema Oncologia</h4>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <br />
                                <tr class="txb-lbl">
                                    <div class="form-floating">
                                        <td>
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:  &nbsp</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="form-control txb-login">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="O Nome do Usuário é obrigatório." ToolTip="O Nome do Usuário é obrigatório." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </div>
                                </tr>
                                <tr class="txb-lbl">
                                    <div class="form-floating">
                                        <td>
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:  &nbsp &nbsp </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" CssClass="form-control txb-login" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="A senha é obrigatória." ToolTip="A senha é obrigatória." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </div>
                                </tr>
                                <tr>
                                    <div class="mb-3 checkbox-login">
                                        <td>
                                            <%--<asp:CheckBox ID="RememberMe" runat="server" Text=" &nbsp Lembrar na próxima vez." />--%>
                                        </td>
                                    </div>
                                </tr>

                                <tr>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Button ID="LoginButton" runat="server" class="w-100 btn-lg button-login " CommandName="Login" Text="Entrar" ValidationGroup="Login1" />
                                    </td>
                                </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td>
                                <img class="img-login" src="img/Logo_HSPM_Pref-01.jpg" />
                            </td>
                        </tr>
                    </tfoot>

                    </td>
                    </tr>
                </table>
                <script src="bootstrap5/dist/js/bootstrap.min.js"></script>
            </LayoutTemplate>
        </asp:Login>
    </form>
</body>
</html>