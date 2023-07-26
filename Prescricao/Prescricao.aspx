<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Prescricao.aspx.cs" Inherits="Prescricao_Prescricao"
    Title="Prescricao - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
  <meta http-equiv="refresh" content="1000" />

   
     <link href="../vendors/jquery/dist/jquery-ui.css" rel="stylesheet" />

    <style type="text/css">
        fieldset.scheduler-border
        {
            border: 1px groove #ddd !important;
            padding: 0 1.4em 1.4em 1.4em !important;
            margin: 0 0 1.5em 0 !important;
            -webkit-box-shadow: 0px 0px 0px 0px #000;
        }
        legend.scheduler-border
        {
            font-size: 1.2em !important;
            font-weight: bold !important;
            text-align: center !important;
        }
       
        .clock
        {
            width: 100%;
            margin: 0 auto;
            padding: 10px;
            color: #2A3F54;
        }
    </style>
  
    
  

   
           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
   <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
      <Scripts>
       <asp:ScriptReference Path="../vendors/jquery/dist/jquery.js" />
          <asp:ScriptReference Path="../vendors/jquery/dist/jquery-ui.js" />
     
         
      </Scripts>
          </asp:ScriptManagerProxy>
      
          
            <div class="container">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            Prescrição</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                RH

                            </label>
                            <asp:TextBox ID="txbProntuario" runat="server" class="form-control numeric"></asp:TextBox>
                        </div>
                        <div class="col-md-5 col-sm-12 col-xs-12 form-group">
                            <label>
                                Nome </label>
                            <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control"></asp:TextBox>
                       
                        </div>
                       
                                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                                      
                                            <asp:Button  ID="btnAdd" runat="server" Text="Adicionar Paciente" class="btn btn-primary gravar" 
                                                OnClick="btnAdd_Click"  />
                                        
                                        
                                     </ContentTemplate>

    </asp:UpdatePanel>     
                              
                           
                    </div>
                 
                <div class="x_content">
                </div>
            </div>
                </div>
    <!-- Large modal -->
                    <div class="modal fade" id="modalAdicionarPaciente" tabindex="-1" role="dialog"
                        aria-hidden="true">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="myModalLabel">
                                        Novo Paciente </h4>
                                    <button type="button" class="close" data-dismiss="modal">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="container">
                                        <div class="modal-body">
                                          <label class="col-sm-2 col-form-label">
                                                    Digite abaixo o RH do paciente:</label>
                                            <div class="form-group row">
                                               
                                                <label for="txbProntuario" class="col-sm-2 col-form-label">
                                                    Prontuário:</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="TextBox1" runat="server" Enabled="true" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                  <ContentTemplate>
                                            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click"  />
                                                                                     
                                     </ContentTemplate>

    </asp:UpdatePanel>    
                               
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                    <!-- fim modal large -->

                        <!-- Large modal -->
                    <div class="modal fade" id="modalDadosDoPaciente" tabindex="-1" role="dialog"
                        aria-hidden="true">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title" id="myModalLabel">
                                        Novo Paciente </h4>
                                    <button type="button" class="close" data-dismiss="modal">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="container">
                                        <div class="row">
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                RH</label>
                            <asp:TextBox ID="TextBox2" runat="server" class="form-control numeric"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                RF</label>
                            <asp:TextBox ID="txbRF" runat="server" class="form-control numeric"></asp:TextBox>
                        </div>
                        <!--div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Outro Documento</label>
                            <asp:TextBox ID="txbDocumento" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Cartão SUS</label>
                            <asp:TextBox ID="txbCNS" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
                        </div-->
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Tipo Paciente</label>
                            <asp:RadioButtonList ID="rbTipoPaciente"  RepeatDirection="Horizontal" runat="server" AutoPostBack="true"  >
                                <asp:ListItem   Value="Munícipe" >Munícipe</asp:ListItem>
                                <asp:ListItem  Value="Servidor">Servidor</asp:ListItem>
                                 <asp:ListItem  Value="Dependente">Dependente</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                    <!-- fim modal large -->
           
 <script type="text/javascript">

     $(document).ready(function () {


         $("#<%= txbNomePaciente.ClientID %>").autocomplete({

        source: function (request, response) {
            var param = { prefixo: $('#<%= txbNomePaciente.ClientID %>').val() };
            $.ajax({
                url: "Prescricao.aspx/GetNomeDePacientes",
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    console.log(JSON.stringify(data.d));

                    response($.map(data.d, function (item) {

                        return {

                            label: item.nm_nome,
                            value: item.nm_nome,

                            
                            prontuario: item.cd_prontuario,
                           
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                }
            });
        },


        select: function (e, i) {



           
            $("[id$=txbProntuario").val(i.item.prontuario);
            
            $("[id$=txbNomePaciente").val(i.item.nome_paciente);
           
        },
        minLength: 1 //This is the Char length of inputTextBox    

    });
     });
   
 </script>

</asp:Content>
