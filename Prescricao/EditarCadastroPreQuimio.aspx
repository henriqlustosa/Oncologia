<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditarCadastroPreQuimio.aspx.cs" Inherits="Prescricao_EditarCadastroPreQuimio" Title="Oncologia - HSPM" %>



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
                <h2>Editar cadastro de PreQuimio</h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                    <label>
                        Id PreQuimio:
                    </label>
                    <asp:TextBox ID="txbId" class="form-control numeric" runat="server" Enabled="false" />

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

                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>

    </div>

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <script src='<%= ResolveUrl("~/build/js/jquery.dataTables.js") %>' type="text/javascript"></script>

    <script type="text/javascript">

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
    </script>

</asp:Content>
