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





    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>Cadastro de PreQuimio</h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                    <label>
                        Lista de Protocolo:
                    </label>
                    <asp:DropDownList ID="ddlProtocolo" runat="server" class="form-control"
                        DataTextField="ddlProtocolo" DataValueField="Id">
                    </asp:DropDownList>
                </div>
            </div>


            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Lista de Medicamentos:</label>
                    <asp:DropDownList ID="ddlMedicacao" runat="server" class="form-control"
                        DataTextField="descricao" DataValueField="Id">
                    </asp:DropDownList>

                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Dose
                    </label>
                    <asp:TextBox ID="txbDose" class="form-control numeric" runat="server"  />
                    <asp:DropDownList ID="ddlUnidadeDose" runat="server" class="form-control">
                        <asp:ListItem Value="0">mg</asp:ListItem>
                        <asp:ListItem Value="1">mg/m² </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        ViaDeAdministracao</label>
                    <asp:DropDownList ID="ddlViaDeAdministracao" runat="server" class="form-control"
                        DataTextField="descricao" DataValueField="Id">
                    </asp:DropDownList>

                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Diluicao
                    </label>
                    <asp:TextBox ID="txbDiluicao" class="form-control numeric" runat="server"  />
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        PreQuimio</label>
                    <asp:DropDownList ID="ddlPreQuimio" runat="server" class="form-control"
                        DataTextField="descricao" DataValueField="Id">
                    </asp:DropDownList>

                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Tempo de Infusão
                    </label>
                    <asp:TextBox ID="txbTempoDeInfusao" class="form-control numeric" runat="server" />
                    <asp:DropDownList ID="ddlUnidadeTempoDeInfusao" runat="server" class="form-control">
                        <asp:ListItem Value="0">min</asp:ListItem>
                        <asp:ListItem Value="1">hr</asp:ListItem>
                    </asp:DropDownList>


                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" OnClick="btnGravar_Click" />
                </div>
            </div>
        </div>
        <div class="x_panel">
            <div class="x_title">
                <h2>Lista de PreQuimio</h2>
                <div class="clearfix">
                </div>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1"
                Width="100%" OnPreRender="GridView1_PreRender">

                <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="desc_descricao_protocolo" HeaderText="PREQUIMIO" SortExpression="desc_descricao_protocolo"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="desc_medicacao" HeaderText="MEDICACAO PREQUIMIO" SortExpression="desc_medicacao"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                    <asp:BoundField DataField="desc_pre_quimio" HeaderText="QUIMIO" SortExpression="desc_pre_quimio"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="desc_via_de_administracao" HeaderText="VIA DE ADMINISTRACAO" SortExpression="desc_via_de_administracao"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="nome_Usuario" HeaderText="USUARIO" SortExpression="nome_Usuario"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="dose" HeaderText="DOSE" SortExpression="dose"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                    <asp:BoundField DataField="unidadeDose" HeaderText="UNIDADE_DOSE" SortExpression="unidadeDose"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="diluicao" HeaderText="DILUICAO" SortExpression="diluicao"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="tempoDeInfusao" HeaderText="TEMPO DE INFUSAO" SortExpression="tempoDeInfusao"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                    <asp:BoundField DataField="unidadeTempoDeInfusao" HeaderText="UNIDADE TEMPO DE INFUSAO" SortExpression="unidadeTempoDeInfusao"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="dataCadastro" HeaderText="DATA" SortExpression="dataCadastro"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
            </asp:GridView>
        </div>
    </div>

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <script src='<%= ResolveUrl("~/build/js/jquery.dataTables.js") %>' type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $.noConflict();

            $('#<%= GridView1.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
            language: {
                search: "<i class='fa fa-search' aria-hidden='true'></i>",
                processing: "Processando...",
                lengthMenu: "Mostrando _MENU_ registros por páginas",
                info: "Mostrando página _PAGE_ de _PAGES_",
                infoEmpty: "Nenhum registro encontrado",
                infoFiltered: "(filtrado de _MAX_ registros no total)"
            }
        });

    });
    </script>
























    <script src="../js/chosen.jquery.min.js" type="text/javascript"></script>




    <script type="text/javascript">

        <%--$(document).ready(function () {

            $("#<%=select1.ClientID %>").chosen({ no_results_text: "Nada encontrado!" });

        });--%>

    </script>
</asp:Content>

