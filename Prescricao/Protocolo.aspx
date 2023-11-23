<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Protocolo.aspx.cs" Inherits="Prescricao_Protocolo"
    Title="Protocolo - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <link href="../js/chosen.min.css" rel="stylesheet" type="text/css" />

    <meta http-equiv="refresh" content="1000" />
    <link href="../vendors/jquery/dist/jquery-ui.css" rel="stylesheet" />
    <asp:ScriptManagerProxy ID="ScriptManagerProxy2" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../vendors/jquery/dist/jquery.js" />
            <asp:ScriptReference Path="../vendors/jquery/dist/jquery-ui.js" />
        </Scripts>
    </asp:ScriptManagerProxy>





    <div class="x_content">
        <div id="divProtocolo">
            <div class="x_panel">

                <div class="col-5">
                    Lista de Protocolo:
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlProtocolo" runat="server" class="form-control" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlProtocolo_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <%--  <div class="x_content">
        <div id="divMedicamento">
            <div class="x_panel">
                <div class="col-5">
                    Lista de Medicamentos:
                </div>
              <div>
                    <select data-placeholder="Selecione uma opção" id="select1" multiple style="width: 750px"
                        runat="server" clientidmode="Static">
                    </select>
                </div>
            </div>
            <br />
        </div>
        <br />
    </div>--%>
      <div class="x_content">
        <div id="divMedicamento_Protocolo">
            <div class="x_panel">
                <div class="col-5">
                    Lista de Medicamentos:
                </div>
                <div>
                  <asp:DropDownList ID="ddlLista_Medicamento" runat="server" class="form-control" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div class="col-5">
                    Dose:
                </div>
                <div>
                    <asp:TextBox ID="txbDose" runat="server"></asp:TextBox>
                </div>
                <div class="col-5">
                    Unidade da dose:
                </div>
                <div>
                    <asp:TextBox ID="txbUnidadeDose" runat="server"></asp:TextBox>
                </div>
                <div class="col-5">
                    Via de Administração:
                </div>
                <div>
                  <asp:DropDownList ID="ddlViaDeAdministracao" runat="server" class="form-control" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div class="col-5">
                   Diluição:
                </div>
                <div>
                   <asp:TextBox ID="txbDiluicao" runat="server"></asp:TextBox>
                </div>
                <div class="col-5">
                    Tempo de Infusão:
                </div>
                <div>
                  <asp:TextBox ID="txbTempoDeInfusao" runat="server"></asp:TextBox>
                </div>
                  <div class="col-5">
                    Unidade de Tempo de Infusao:
                </div>
                <div>
                  <asp:TextBox ID="txbUnidadeTempoInfusao" runat="server"></asp:TextBox>
                </div>
                  <div class="col-5">
                   Codigo Pre Quimioterapia:
                </div>
                <div>
                  <asp:DropDownList ID="ddlPreQuimio" runat="server" class="form-control" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
        </div>
        <br />
    </div>

    <div class="x_content">
        <asp:Button ID="btnBravar" runat="server" Text="Gravar" class="btn btn-primary" OnClick="btnGravar_Click" />
    </div>


    <asp:GridView ID="grvMedicamentos" runat="server"></asp:GridView>




















    <script src="../js/chosen.jquery.min.js" type="text/javascript"></script>




    <script type="text/javascript">

        <%--$(document).ready(function () {

            $("#<%=select1.ClientID %>").chosen({ no_results_text: "Nada encontrado!" });

        });--%>

    </script>
</asp:Content>

