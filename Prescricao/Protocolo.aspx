<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Protocolo.aspx.cs" Inherits="Prescricao_Protocolo"
    Title="Protocolo - HSPM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">



        <meta http-equiv="refresh" content="1000" />
     <link href="../vendors/jquery/dist/jquery-ui.css" rel="stylesheet" />
    <asp:ScriptManagerProxy ID="ScriptManagerProxy2" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../vendors/jquery/dist/jquery.js" />
            <asp:ScriptReference Path="../vendors/jquery/dist/jquery-ui.js" />
        </Scripts>
    </asp:ScriptManagerProxy>


       <link href="../js/chosen.min.css" rel="stylesheet" type="text/css" />
  
            <div class="x_content">
                <div id="divCID" >
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
            </div>























      <script src="../js/chosen.jquery.min.js" type="text/javascript"></script>




    <script type="text/javascript">
    
        $(document).ready(function () {

            $("#<%=select1.ClientID %>").chosen({ no_results_text: "Nada encontrado!" });

       });

    </script>
</asp:Content>

