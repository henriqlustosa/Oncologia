<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroProfissional.aspx.cs" Inherits="Administrativo_CadastroProfissional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">



    <script type="text/javascript">

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        .button-container {
            display: flex;
          
            width: 100%;
            justify-content: space-evenly;
        }

     

        /* Center the modal title */
        #myModalProfissional .modal-header {
            text-align: center;
        }

        #myModalProfissional .modal-title {
            width: 100%;
        }
        /* Modal parent container */
        #myModalProfissional .modal-dialog {
            display: flex;
            
            justify-content: center;
            height: 100vh; /* Ensure it takes the full viewport height */
            margin: 0 auto; /* Ensure no extra margin */
        }

        /* Modal content */
        #myModalProfissional .modal-content {
            width: 1200px;
            height: 300px;
            background-color: white;
        }

        #myModalProfissional .modal-body {
            width: 1000px;
            height: 300px;
            background-color: white;
        }
           #myModalProfissional .btn {
       padding: 5px 80px;
   }
          
    </style>
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>



            <asp:ScriptReference Path="../js_datepicker/jquery-ui.js" />



        </Scripts>
    </asp:ScriptManagerProxy>
    <link href="../build/css/jquery.dataTable.css" rel="stylesheet" type="text/css" />
    <link href="../js_datepicker/jquery-ui.css" rel="stylesheet" />
    <link href="../js/chosen.min.css" rel="stylesheet" type="text/css" />
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>Cadastro de Profissional</h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nome do Profissional:
                    </label>
                    <asp:TextBox ID="txbNomeProfissional" class="form-control numeric" runat="server"
                        AutoPostBack="true" />
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Login</label>
                    <asp:DropDownList ID="ddlLogin" runat="server" class="form-control"
                        DataTextField="UserName" DataValueField="UserId">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Conselho</label>
                    <asp:DropDownList ID="ddlConselho" runat="server" class="form-control"
                        DataTextField="sigla_conselho" DataValueField="cod_conselho">
                    </asp:DropDownList>

                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Número do Conselho
                    </label>
                    <asp:TextBox ID="txbNumeroconselho" class="form-control numeric" runat="server" />
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
                <h2>Lista de Profissional</h2>
                <div class="clearfix">
                </div>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_profissional" OnRowCommand="gridView1_RowCommand"
                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1"
                Width="100%" OnPreRender="GridView1_PreRender">

                <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="cod_profissional" HeaderText="COD PROFISSIONAL" SortExpression="cod_profissional"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="nome_profissional" HeaderText="Nome Profissional" SortExpression="nome_profissional"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                    <asp:BoundField DataField="sigla_conselho" HeaderText="CONSELHO" SortExpression="sigla_conselho"
                        HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                    <asp:BoundField DataField="nr_conselho" HeaderText="NR CONSELHO" SortExpression="nr_conselho"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:TemplateField HeaderText="Status" SortExpression="status_profissional">
                        <HeaderStyle CssClass="hidden-xs" />
                        <ItemStyle CssClass="hidden-xs" />
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server"
                                Text='<%# Eval("status_profissional").ToString() == "1" ? "Ativo" : "Inativo" %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderStyle-CssClass="sorting_disabled">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="gvlnkEdit" CommandName="editRecord" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="btn btn-info" runat="server" CausesValidation="false">
                                    <i class="fa fa-pencil-square-o" title="Editar"></i>
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
    </div>
    <!-- Modal -->
    <div class="modal fade two" id="myModalProfissional" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Atualização do Profissional</h4>
                </div>

                <div class="modal-body">
                    <asp:Label ID="lblNome" runat="server"></asp:Label>
                    <fieldset class="scheduler-border">
                        <div class="row">
                            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                                <label>Codigo:</label>
                                <asp:TextBox ID="txbCodProfissionalEdicao" class="form-control numeric" runat="server" ReadOnly="true" />
                            </div>
                            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                                <label>Nome do Profissional:</label>
                                <asp:TextBox ID="txbNomeProfissionalEdicao" class="form-control numeric" runat="server" />
                            </div>
                            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                                <label>Login:</label>

                                <asp:DropDownList ID="ddlLoginEdicao" runat="server" class="form-control" DataTextField="UserName" DataValueField="UserId">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                                <label>Conselho:</label>
                                <asp:DropDownList ID="ddlConselhoEdicao" runat="server" class="form-control" DataTextField="sigla_conselho" DataValueField="cod_conselho">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                                <label>Número do Conselho:</label>
                                <asp:TextBox ID="txbNumeroconselhoEdicao" class="form-control numeric" runat="server" />
                            </div>
                            <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                                <label>Status:</label>
                                <asp:DropDownList ID="ddlStatusEdicao" runat="server" class="form-control">
                                    <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inativo" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </fieldset>
                </div>


                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12 form-group button-container">
                        <div >
                            <asp:Button ID="btnGravarProfissional" runat="server" Text="Gravar" class="btn btn-primary btn-sm" OnClick="btnGravarProfissional_Click" data-toggle="modal" />
                        </div>
                        <div >
                            <asp:Button ID="btnCancelarProfissional" runat="server" Text="Cancelar" class="btn btn-info btn-sm" OnClick="btnCancelarProfissional_Click" data-toggle="modal" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    </div>
      <script src='<%= ResolveUrl("~/build/js/popper.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/build/js/bootstrap.min.js") %>' type="text/javascript"></script>

    
    <script src='<%= ResolveUrl("~/build/js/jquery.dataTables.js") %>' type="text/javascript"></script>

    <script type="text/javascript">
        function showModal(modalId) {
            $('#' + modalId).modal('show');
        }
        $(document).ready(function () {


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

            $('#<%=txbNumeroconselho.ClientID%>').keyup(function () {
                $(this).val(this.value.replace(/\D/g, ''));
            });


        });
    </script>
</asp:Content>

