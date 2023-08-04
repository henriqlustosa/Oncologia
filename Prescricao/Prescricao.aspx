<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Prescricao.aspx.cs" Inherits="Prescricao_Prescricao"
    Title="Historico de Documentos - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
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
        .message
        {
            display: block;
            width: 100%;
            height: 50px;
            text-align: center;
            line-height: 50px;
            font-size: 1.2rem;
            font-style: italic;
            position: fixed;
            box-shadow: 0 0 4px #333;
        }
        @media screen and (max-width: 500px)
        {
            .message
            {
                bottom: 0;
            }
        }
        .sucess
        {
            background-color: #2ecc71;
            color: #fff;
        }
        .warning
        {
            background-color: #e67e22;
            color: #fff;
        }
        .alert
        {
            background-color: #e74c3c;
            color: #fff;
        }
        .danger
        {
            background-color: #c0392b;
            color: #fff;
        }
    </style>
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../vendors/jquery/dist/jquery.js" />
            <asp:ScriptReference Path="../vendors/jquery/dist/jquery-ui.js" />
        </Scripts>
    </asp:ScriptManagerProxy>

  

    <!-- CDN for chosen plugin -->
    <link href="../js/chosen.min.css" rel="stylesheet" type="text/css" />
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
                        Nome
                    </label>
                    <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="nav justify-content-md-center">
                <input id="btnCalculo" type="button" value="Cálculo da Superfície Corpórea" onclick="mostraCalculo()"
                    class="btn btn-outline-info btn-block" />
            </div>
            <div id="divCalculoCorpo" style='display: none;'>
                <%--<h4 class="text-center">
            Alta Paciente Pagina Unica</h4>--%>
                <div class="row">
                    <div class="col-5">
                        Peso Atual:
                        <asp:TextBox ID="txbPesoAtual" runat="server" class="form-control align-self-sm-start"></asp:TextBox>
                    </div>
                    <div class="col-5">
                        Altura:
                        <asp:TextBox ID="txbAltura" runat="server" class="form-control align-self-sm-start"></asp:TextBox>
                    </div>
                      <div class="col-5">
                        IMC:
                        <asp:TextBox ID="txbIMC" Enabled=false runat="server" class="form-control align-self-sm-start"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAdd" runat="server" Text="Calcular" class="btn btn-primary gravar"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <div class="nav justify-content-md-center">
                <input id="btnCID" type="button" value="CID" onclick="mostraCID()" class="btn btn-outline-info btn-block" />
            </div>
            <div class="x_content">
                <div id="divCID" >
                    <div class="x_panel">
                        <div class="col-5">
                            CID 10:
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
             <div class="nav justify-content-md-center">
                <input id="btnProtocolo" type="button" value="Protocolo" onclick="mostraProtocolo()" class="btn btn-outline-info btn-block" />
            </div>
            <div class="x_content">
                <div id="divProtocolo" >
                    <div class="x_panel">
                        <div class="col-5">
                            Protocolo:
                        </div>
                        <div>
                            <select data-placeholder="Selecione uma opção" id="select2" multiple style="width: 750px"
                                runat="server" clientidmode="Static">
                            </select>
                        </div>
                    </div>
                    <br />
                </div>
                <br />
            </div>
        </div>
    </div>
    <!-- Large modal -->
    <div class="modal fade" id="modalAdicionarPaciente" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">
                        Cálculo</h4>
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="modal-body">
                            <label class="col-sm-5 col-form-label">
                                Cálculo da Superfície Córporea:</label>
                            <div class="form-group row">
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txbValorCalculado" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div id="mensagem" class="form-group row">
                                <div class="example">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <!-- fim modal large -->
    <!-- Large modal -->
    <div class="modal fade" id="modalDadosDoPaciente" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabe">
                        Novo Paciente
                    </h4>
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
                                <asp:RadioButtonList ID="rbTipoPaciente" RepeatDirection="Horizontal" runat="server"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="Munícipe">Munícipe</asp:ListItem>
                                    <asp:ListItem Value="Servidor">Servidor</asp:ListItem>
                                    <asp:ListItem Value="Dependente">Dependente</asp:ListItem>
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
        function validaEntrada(args) {
            for (let i = 0; i < arguments.length; i++) {
                if (!!arguments[i] == false || arguments[i] < 0) {
                    return false;
                }
            }
            return true;
        }

        function calcularIMC(kilos, altura) {
            altura = altura / 100;
            return (kilos / (altura * altura));
        };
        var botaoCalcular = document.getElementById('<%=btnAdd.ClientID%>');
        botaoCalcular.addEventListener('click', calculandoIMC);
        function calculandoIMC(){
            event.preventDefault();

            const kilos = parseFloat(document.getElementById('<%=txbPesoAtual.ClientID%>').value);
            const altura = parseFloat(document.getElementById('<%=txbAltura.ClientID%>').value);

            if (validaEntrada(kilos, altura)) {
                const imc = calcularIMC(kilos, altura);
                document.getElementById('<%=txbIMC.ClientID%>').value = parseFloat(imc).toFixed(2);
                verificarIMC(imc);
            } else {
                document.getElementById('<%=txbIMC.ClientID%>').value = "## ERRO ##";
            }
        };

        function verificarIMC(imc) {
            if (imc < 17) {
                createMessage("Muito abaixo do peso", "alert")
            } else if (imc > 17 && imc <= 18.49) {
                createMessage("Abaixo do peso", "warning")
            } else if (imc >= 18.5 && imc <= 24.99) {
                createMessage("Peso normal", "sucess")
            } else if (imc >= 25 && imc <= 29.99) {
                createMessage("Acima do peso", "warning")
            } else if (imc >= 30 && imc <= 34.99) {
                createMessage("Obesidade I", "alert")
            } else {
                createMessage("Obesidade II", "danger")
            }
        }

        function createMessage(msg, type) {
        
            document
                .querySelector("body")
                .insertAdjacentHTML("beforebegin",  `<div class='message ${type}'>${msg}</div>`);

            setTimeout(function () {
                deleteMessage();
            }, 3000);
        }

        function deleteMessage() {
            const list = document.querySelectorAll(".message");
            for (const item of list) {
                item.remove();
            }
        }
        function mostraCalculo() {

            var div = document.getElementById('divCalculoCorpo');

            if (div.style.display == 'none') {
                div.style.display = 'block';
            }
            else {
                div.style.display = 'none';
            }
        }
        function mostraCID() {

            var div = document.getElementById('divCID');

            if (div.style.display == 'none') {
                div.style.display = 'block';
            }
            else {
                div.style.display = 'none';
            }
        }
    function mostraProtocolo() {

            var div = document.getElementById('divProtocolo');

            if (div.style.display == 'none') {
                div.style.display = 'block';
            }
            else {
                div.style.display = 'none';
            }
        }

            $(document).ready(function () {

                $("#<%=select1.ClientID %>").chosen({ no_results_text: "Nada encontrado!" });




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
  <script src="../js/chosen.jquery.min.js" type="text/javascript"></script>
</asp:Content>
