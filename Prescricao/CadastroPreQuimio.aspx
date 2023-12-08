<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroPreQuimio.aspx.cs" Inherits="Prescricao_CadastroPreQuimio" Title="Oncologia - HSPM" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../build/css/jquery.dataTable.css" rel="stylesheet" type="text/css" />

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <script type="text/javascript">

</script>

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



                    <asp:TextBox ID="txbQuantidade" class="form-control numeric" runat="server" AutoPostBack="true" />
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
                    <asp:TextBox ID="txbDiluicao" class="form-control numeric" runat="server" AutoPostBack="true" />
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
                  
               
                    <asp:TextBox ID="txbTempoDeInfusao" class="form-control numeric" runat="server" AutoPostBack="true" />
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

                    <asp:BoundField DataField="desc_medicacao_pre_quimio" HeaderText="MEDICACAO PREQUIMIO" SortExpression="desc_medicacao_pre_quimio"
                        ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                    <asp:BoundField DataField="desc_quimio" HeaderText="QUIMIO" SortExpression="desc_quimio"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="desc_via_de_administracao" HeaderText="VIA DE ADMINISTRACAO" SortExpression="desc_via_de_administracao"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                    <asp:BoundField DataField="nome_Usuario" HeaderText="USUARIO" SortExpression="nome_Usuario"
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
        function confirmation() {
            return confirm("Você realmente quer deletar registro?");
        }
        function file() {
            return confirm("Você realmente quer arquivar registro?");
        }
    </script>

</asp:Content>
