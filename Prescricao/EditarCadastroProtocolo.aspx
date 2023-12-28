<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EditarCadastroProtocolo.aspx.cs" Inherits="Prescricao_EditarCadastroProtocolo"
    Title="Protocolo - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">







    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>Editar cadastro de Protocolo</h2>
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
                    <asp:TextBox ID="txbDose" class="form-control numeric" runat="server" />
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Unidade
                    </label>
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
                    <asp:TextBox ID="txbDiluicao" class="form-control numeric" runat="server" />
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

        </div>

    <div class="row">
        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
            <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" OnClick="btnGravar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click" />
        </div>
    </div>


    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <script src='<%= ResolveUrl("~/build/js/jquery.dataTables.js") %>' type="text/javascript"></script>
 <script src='<%= ResolveUrl("~/build/js/jquery.inputmask.min.js") %>' type="text/javascript"></script>
  
 
     
     <script type="text/javascript">

         $('#<%= txbDose.ClientID %>').inputmask({ 'mask': "9{0,4},9{0,2}", greedy: false });
   

 
 </script>


























    <script src="../js/chosen.jquery.min.js" type="text/javascript"></script>




    <script type="text/javascript">

        $('#<%= txbDose.ClientID %>').keypress(function (e) {
            var a = [];
            var k = e.which;

            for (i = 48; i < 58; i++)
                a.push(i);

            // allow a max of 1 decimal point to be entered

            if (!(a.indexOf(k) >= 0)) e.preventDefault();


        });

    </script>
</asp:Content>

