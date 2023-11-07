<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Historico.aspx.cs" Inherits="Historico_Historico" Title="Oncologia - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../build/css/jquery.dataTable.css" rel="stylesheet" type="text/css" />
    
    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Histórico do Paciente</h2>
                <div class="clearfix">
                </div>
            </div>
            <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left input_mask">
                <div class="row">
                   <div class="col-auto form-group">
                        <label class="control-label" for="UsernameTextBox">
                            Informe o nome do paciente: 
                        </label>
                        </div>
                    <div class="form-group">
                        <div class="col-md-8">
                            <asp:TextBox ID="txbNome" class="form-control numeric" runat="server" AutoPostBack="true" />
                        </div>
                    
                        <div class="col-md-4 col-sm-4 col-xs-8 ">
                            <asp:Button ID="SearchButton" runat="server" Text="Pesquisar" class="btn btn-primary"
                                OnClick="btnPesquisar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="x_panel">
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_ficha"
                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1" OnRowCommand="grdMain_RowCommand"
                Width="100%" >
                
                <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="cod_ficha" HeaderText="BE" SortExpression="cod_ficha"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="dt_rh_be" HeaderText="DATA" SortExpression="dt_rh_be"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />
                    <asp:BoundField DataField="nome_paciente" HeaderText="Nome Paciente" SortExpression="nome_paciente"
                        HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                         <asp:BoundField DataField="setor" HeaderText="Setor" SortExpression="setor"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="tipo_paciente" HeaderText="Tipo Paciente" SortExpression="tipo_paciente"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="gvlnkPrint" CommandName="printFicha" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="btn btn-info" runat="server">
                                    <i class="fa fa-print" title="Ligar"></i> 
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
                    <div class="container">
                        <!-- Trigger the modal with a button 
        <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">
            Imprimir</button>-->
                        <!-- Modal -->
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">
                                            Selecione a Impressora</h4>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="lbBE" runat="server" Text=""></asp:Label>
                                        
                                        <div>
                                            Impressoras:
                                            <asp:DropDownList ID="ddlImpressora" class="form-control" runat="server">
                                            </asp:DropDownList>
                                            
                                            
                                            <asp:Button ID="btnGravar" runat="server" Text="Imprimir" class="btn btn-primary" OnClick="btnGravar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <!-- Bootstrap -->
    <script src='<%= ResolveUrl("~/vendors/bootstrap/dist/js/bootstrap431.js") %>' type="text/javascript"></script>
    
    <script src='<%= ResolveUrl("~/build/js/jquery.dataTables.js") %>' type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
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

</asp:Content>