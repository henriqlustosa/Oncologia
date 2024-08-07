﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroPreQuimio.aspx.cs" Inherits="Prescricao_CadastroPreQuimio" Title="Oncologia - HSPM" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../build/css/jquery.dataTable.css" rel="stylesheet" type="text/css" />

<%--    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>--%>
     <script src='<%= ResolveUrl("~/moment/jquery-3.7.0.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/build/js/jspdf.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/build/js/jspdf.plugin.autotable.min.js") %>' type="text/javascript"></script>

  



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

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
                        Tipo PreQuimio:
                    </label>
                    <asp:DropDownList ID="ddlPreQuimio" runat="server" class="form-control"
                        DataTextField="descricao" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Escolha uma das opções." ControlToValidate="ddlPreQuimio"
                        InitialValue="" runat="server" ForeColor="Red" />
                </div>
            </div>


            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Medicacao</label>
                    <asp:DropDownList ID="ddlMedicacao" runat="server" class="form-control"
                        DataTextField="descricao" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Escolha uma das opções." ControlToValidate="ddlMedicacao"
                        InitialValue="" runat="server" ForeColor="Red" />
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Quantidade
                    </label>



                    <asp:TextBox ID="txbQuantidade" class="form-control numeric" runat="server" />
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Unidade
                    </label>
                    <asp:DropDownList ID="ddlUnidadeQuantidade" runat="server" class="form-control">
                        <asp:ListItem Value="0">mg</asp:ListItem>
                        <asp:ListItem Value="1">g</asp:ListItem>
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
                    <asp:RequiredFieldValidator ErrorMessage="Escolha uma das opções." ControlToValidate="ddlViaDeAdministracao"
                        InitialValue="" runat="server" ForeColor="Red" />
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Diluicao
                    </label>
                    <asp:TextBox ID="txbDiluicao" class="form-control numeric" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Quimio</label>
                    <asp:DropDownList ID="ddlQuimio" runat="server" class="form-control"
                        DataTextField="descricao" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="Escolha uma das opções." ControlToValidate="ddlQuimio"
                        InitialValue="" runat="server" ForeColor="Red" />

                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Tempo de Infusão
                    </label>


                    <asp:TextBox ID="txbTempoDeInfusao" class="form-control numeric" runat="server" />
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Unidade
                    </label>
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="grdMain_RowCommand"
                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1"
                Width="100%" OnPreRender="GridView1_PreRender">

                <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="desc_pre_quimio" HeaderText="PREQUIMIO" SortExpression="desc_pre_quimio"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="desc_medicacao" HeaderText="MEDICACAO PREQUIMIO" SortExpression="desc_medicacao"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                    <asp:BoundField DataField="desc_quimio" HeaderText="QUIMIO" SortExpression="desc_quimio"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="desc_via_de_administracao" HeaderText="VIA DE ADMINISTRACAO" SortExpression="desc_via_de_administracao"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                   

                    <asp:BoundField DataField="quantidade" HeaderText="QUANTIDADE" SortExpression="quantidade"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                    <asp:BoundField DataField="unidadeQuantidade" HeaderText="UNIDADE_QUANTIDADE" SortExpression="unidadeQuantidade"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="diluicao" HeaderText="DILUICAO" SortExpression="diluicao"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="tempoDeInfusao" HeaderText="TEMPO DE INFUSAO" SortExpression="tempoDeInfusao"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                    <asp:BoundField DataField="unidadeTempoDeInfusao" HeaderText="UNIDADE TEMPO DE INFUSAO" SortExpression="unidadeTempoDeInfusao"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

               
                    <asp:BoundField DataField="nome_Usuario" HeaderText="USUARIO" SortExpression="nome_Usuario"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="dataCadastro" HeaderText="DATA" SortExpression="dataCadastro"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:TemplateField HeaderStyle-CssClass="sorting_disabled">


                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="gvlnkEdit" CommandName="editRecord" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="btn btn-info" runat="server" CausesValidation="false">
                                    <i class="fa fa-pencil-square-o" title="Informação"></i> 
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="sorting_disabled">

                        <ItemTemplate>

                            <div class="form-inline">
                                <asp:LinkButton ID="gvlnkDelete" CommandName="deleteRecord" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="btn btn-danger" runat="server" OnClientClick="return confirmation();" CausesValidation="false">
                                    <i class="fa fa-trash" title="Excluir"></i> 
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
            </asp:GridView>
        </div>
        <div>

            <asp:ImageButton ID="ImageButton1" runat="server" Height="45px" Width="45px" OnClientClick="salvaPlanilha();" ImageUrl="../imagens/excel.png" CausesValidation="false" />
            <asp:ImageButton ID="ImageButton2" runat="server" Height="45px" Width="45px" OnClientClick="generate();" ImageUrl="../imagens/pdf.png" CausesValidation="false" />

        </div>
    </div>

    <script src='<%= ResolveUrl("~/build/js/jquery.inputmask.min.js") %>' type="text/javascript"></script>









 <%--   <script src='<%= ResolveUrl("~/moment/jquery-3.7.0.js") %>' type="text/javascript"></script>--%>
 <script src='<%= ResolveUrl("~/moment/moment.min.js") %>' type="text/javascript"></script>
 <script src='<%= ResolveUrl("~/moment/jquery.dataTables.min.js") %>' type="text/javascript"></script>
 <script src='<%= ResolveUrl("~/moment/datetime.js") %>' charset="utf8" type="text/javascript"></script>


    <script type="text/javascript">

        $('#<%= txbQuantidade.ClientID %>').inputmask({ 'mask': "9{0,4},9{0,2}", greedy: false });

        $(document).ready(function () {
           

            $('#<%= GridView1.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                language: {
                    search: "<i class='fa fa-search' aria-hidden='true'></i>",
                    processing: "Processando...",
                    lengthMenu: "Mostrando _MENU_ registros por páginas",
                    info: "Mostrando página _PAGE_ de _PAGES_",
                    infoEmpty: "Nenhum registro encontrado",
                    infoFiltered: "(filtrado de _MAX_ registros no total)"
                },

                 columnDefs: [

                    { targets: [10], render: DataTable.render.moment('DD/MM/YYYY HH:mm:ss', 'DD/MM/YYYY HH:mm', 'pt-br') }

                ]
            });

        });
        function confirmation() {
            return confirm("Você realmente quer deletar registro?");
        }
        function file() {
            return confirm("Você realmente quer arquivar registro?");
        }
        $('#<%= txbQuantidade.ClientID %>').keypress(function (e) {
            var a = [];
            var k = e.which;

            for (i = 48; i < 58; i++)
                a.push(i);

            // allow a max of 1 decimal point to be entered

            if (!(a.indexOf(k) >= 0)) e.preventDefault();


        });
        $('#<%= txbTempoDeInfusao.ClientID %>').keypress(function (e) {
            var a = [];
            var k = e.which;

            for (i = 48; i < 58; i++)
                a.push(i);

            // allow a max of 1 decimal point to be entered

            if (!(a.indexOf(k) >= 0)) e.preventDefault();


        });
        function generate() {


            var dataAtual = new Date();
            const locale = 'pt-br';
            var data = dataAtual.toLocaleDateString(locale);
            var hora = dataAtual.toLocaleTimeString(locale);



            var doc = new jsPDF('l', 'pt');
            var htmlstring = '';
            var tempVarToCheckPageHeight = 0;
            var pageHeight = 0;
            pageHeight = doc.internal.pageSize.height;
            specialElementHandlers = {
                // element with id of "bypass" - jQuery style selector  
                '#bypassme': function (element, renderer) {
                    // true = "handled elsewhere, bypass text extraction"  
                    return true
                }
            };
            margins = {
                top: 150,
                bottom: 60,
                left: 40,
                right: 40,
                width: 600
            };
            var y = 20;
            doc.setLineWidth(2);
            doc.text(200, y = y + 30, "Data da impressão: " + data + "  " + "Horário: " + hora);
            doc.autoTable({
                html: '#<%= GridView1.ClientID %>',
        startY: 70,
        theme: 'grid',
        headStyles: { fillColor: [0, 0, 0] }
    })
            doc.save('Arquivo_' + ("0" + dataAtual.getDate()).slice(-2) + "_" + ("0" + (dataAtual.getMonth() + 1)).slice(-2) + "_" + dataAtual.getFullYear() + "_" + dataAtual.getHours() + "_" + dataAtual.getMinutes() + '.pdf');
        }

        function salvaPlanilha() {
            var htmlPlanilha = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name></x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>' + $('#<%= GridView1.ClientID %>').html() + '</table></body></html>';

            var htmlBase64 = btoa(htmlPlanilha);
            var link = "data:application/vnd.ms-excel;base64," + htmlBase64;


            var hyperlink = document.createElement("a");
            hyperlink.download = "Arquivo.xls";
            hyperlink.href = link;
            hyperlink.style.display = 'none';

            document.body.appendChild(hyperlink);
            hyperlink.click();
            document.body.removeChild(hyperlink);
        }

    </script>

</asp:Content>
