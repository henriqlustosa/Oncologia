<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Prescricao.aspx.cs" Inherits="Prescricao_Prescricao"
    Title="Historico de Documentos - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <meta http-equiv="refresh" content="1000" />
    <link href="../vendors/jquery/dist/jquery-ui.css" rel="stylesheet" />
    <style type="text/css">
        fieldset.scheduler-border {
            border: 1px groove #ddd !important;
            padding: 0 1.4em 1.4em 1.4em !important;
            margin: 0 0 1.5em 0 !important;
            -webkit-box-shadow: 0px 0px 0px 0px #000;
        }

        legend.scheduler-border {
            font-size: 1.2em !important;
            font-weight: bold !important;
            text-align: center !important;
        }

        .clock {
            width: 100%;
            margin: 0 auto;
            padding: 10px;
            color: #2A3F54;
        }

        .message {
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

        @media screen and (max-width: 500px) {
            .message {
                bottom: 0;
            }
        }

        .sucess {
            background-color: #2ecc71;
            color: #fff;
        }

        .warning {
            background-color: #e67e22;
            color: #fff;
        }

        .alert {
            background-color: #e74c3c;
            color: #fff;
        }

        .danger {
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
                <h2>Prescrição</h2>
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












            <div id="divCalculoCorpo" >
                <%--<h4 class="text-center">
            Alta Paciente Pagina Unica</h4>--%>







                <form name="BodySurfaceArea_form" id="BodySurfaceArea_form" action="" onsubmit="return false;" onkeydown="clrResults(); resetInTime();" onkeyup="BodySurfaceArea_fx();">

                    <table width="100%" cellpadding="4" cellspacing="0" summary="EBMcalc Table">
                        <tr>
                            <td class="medCalcTitleBox" width="1%">
                                <br />
                            </td>
                            <td class="medCalcTitleBox">
                                <span class="medCalcFontTitleBox">Body Surface Area (Du Bois Method)
                                </span></td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;<br />

                    <div id="calc_main">

                        <div id="calc_input">
                            <center>
                                <span class="medCalcFontIO">Input
                                </span>
                                <br />
                                &nbsp;<br />
                                <table cellpadding="3" cellspacing="0" summary="EBMcalc Table">
                                    <tr>
                                        <td align="right" width="42%"><span class="medCalcFontOneBold">Height</span> </td>
                                        <td align="left" valign="top" nowrap="nowrap" width="5%">&nbsp;
                                            <input type="text" name="Height_param" size="6" value="" onblur="BodySurfaceArea_fx(); minMaxCheck();" onchange="BodySurfaceArea_fx();" aria-label="Use this input box to enter the value Height" /></td>
                                        <td align="left" valign="top">
                                            <select name="Height_unit" onchange="BodySurfaceArea_fx(); minMaxCheck();" style="width: 115px;" class="medCalcFontSelect" aria-label="Use this pulldown selector to set the unit of measure for the value Height">
                                                <option value="1|0|cm" selected="selected">cm</option>
                                                <option value="30.48|0|ft">ft</option>
                                                <option value="2.54|0|in">in</option>
                                                <option value="0.0001|0|micm">micm</option>
                                                <option value="0.1|0|mm">mm</option>
                                                <option value="100|0|m">m</option>
                                                <option value="1e-07|0|nm">nm</option>
                                                <option value="91.44|0|yd">yd</option>
                                            </select></td>
                                    </tr>

                                    <tr>
                                        <td align="right" width="42%"><span class="medCalcFontOneBold">Weight</span> </td>
                                        <td align="left" valign="top" nowrap="nowrap" width="5%">&nbsp;
                                            <input type="text" name="Weight_param" size="6" value="" onblur="BodySurfaceArea_fx(); minMaxCheck();" onchange="BodySurfaceArea_fx();" aria-label="Use this input box to enter the value Weight" /></td>
                                        <td align="left" valign="top">
                                            <select name="Weight_unit" onchange="BodySurfaceArea_fx(); minMaxCheck();" style="width: 115px;" class="medCalcFontSelect" aria-label="Use this pulldown selector to set the unit of measure for the value Weight">
                                                <option value="0.001|0|gm">gm</option>
                                                <option value="1|0|kg" selected="selected">kg</option>
                                                <option value="0.45359237|0|lb">lb</option>
                                                <option value="1e-06|0|mg">mg</option>
                                            </select></td>
                                    </tr>


                                </table>

                            </center>

                        </div>
                        <br />
                        &nbsp;<br />
                        <div id="calc_result">
                            <center>
                                <span class="medCalcFontIO">Result</span>

                                <br />
                                &nbsp;<br />
                                <table summary="EBMcalc Table" class="medCalcResultBox" cellpadding="4">
                                    <tr>
                                        <td colspan="3">&nbsp;<br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><span class="medCalcFontResultParam">BSA</span></td>
                                        <td valign="top" nowrap="nowrap">&nbsp;
                                            <input type="text" name="BSA_param" size="6" aria-readonly="true" aria-label="This output box will display the calculated value BSA" /></td>
                                        <td valign="top" align="left"><span class="medCalcFontResultParam">
                                            <select name="BSA_unit" onchange="BodySurfaceArea_fx();" style="width: 115px;" class="medCalcFontSelect" aria-label="Use this pulldown selector to set the unit of measure for the result value BSA">
                                                <option value="0.0001|0|cm^2">cm^2</option>
                                                <option value="0.0001|0|sqcm">sqcm</option>
                                                <option value="1|0|sqm" selected="selected">sqm</option>
                                                <option value="0.0001|0|sqrcm">sqrcm</option>
                                                <option value="1|0|sqrm">sqrm</option>
                                            </select>
                                        </span></td>
                                    </tr>


                                    <tr>
                                        <td colspan="3">&nbsp;<br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center"><span class="medCalcFontResultParam">Decimal Precision &nbsp;</span>
                                            <select name="decpts" onchange="BodySurfaceArea_fx();" class="medCalcFontSelect" aria-label="Use this pulldown selector to set the decimal precision of calculations">
                                                <option>0</option>
                                                <option>1</option>
                                                <option selected="selected">2</option>
                                                <option>3</option>

                                            </select></td>
                                    </tr>

                                </table>
                            </center>


                        </div>
                    </div>
                    <div id="pretextrefs">
                        &nbsp;
                    </div>

                    <div id="calc_tables_above_notes">
                    </div>
                    <br />
                    &nbsp;<br />

                    <div id="calc_notes">
                        <span class="medCalcFontOneBold">Notes</span>
                        <ul class="medCalcFontOne">
                            <li><font color="#aa0000">The default unit of measure for weight is kilograms.  Please verify that the correct unit of measure has been selected.</font></li>


                        </ul>
                    </div>

                    <br />
                    &nbsp;<br />
                    <span class="medCalcFontRef"><b>Equations used</b></span>

                    <br />
                    &nbsp;<br />
                    <center>
                        <div id="calc_equation">
                            <table cellspacing="0" cellpadding="10" summary="EBMcalc Table">
                                <tr>
                                    <td class="medCalcFormuliBox"><span class="medCalcFontFormuli">BSA = 0.007184 * Height<sup>0.725</sup> * Weight<sup>0.425</sup></span></td>
                                </tr>
                            </table>
                            <br />
                            &nbsp;<br />
                        </div>
                    </center>

                    <div id="calc_tables">
                    </div>

                    <br />
                    &nbsp;<br />

                    <div id="calc_refs">
                        <span class="medCalcFontRef"><b>References</b></span>
                        <ol>
                            <li><span class="medCalcFontRef">Dubois D, Dubois EF. A formula to estimate the approximate surface area if height and weight be known. <i>Arch Intern Med</i>. 1916; 17:863-871.</span></li>

                        </ol>
                    </div>

                </form>

            </div>
            <br />
            <div class="nav justify-content-md-center">
                <input id="btnCID" type="button" value="CID" onclick="mostraCID()" class="btn btn-outline-info btn-block" />
            </div>
            <div class="x_content">
                <div id="divCID">
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
                <div id="divProtocolo">
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
        <%--    function validaEntrada(args) {
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
        }--%>

        function log(i) {
            return Math.log(i) * Math.LOG10E;
        }

        function ln(i) {
            return Math.log(i);
        }

        function sq(i) {
            return i * i;
        }

        function sqr(i) {
            return Math.sqrt(i);
        }


        function power(x, y) {
            return Math.pow(x, y);
        }

        function eTo(x) {
            return Math.exp(x);
        }


        function fixDP(r, dps) {
            if (isNaN(r)) return "NaN";
            var msign = '';
            var mfin = '';
            if (r < 0) msign = '-';
            x = Math.abs(r);
            if (x > Math.pow(10, 21)) return msign + x.toString();
            var m = Math.round(x * Math.pow(10, dps)).toString();
            if (dps == 0) return msign + m;
            while (m.length <= dps) m = "0" + m;
            mfin = msign + m.substring(0, m.length - dps) + "." + m.substring(m.length - dps);
            if (dps == 1) return mfin.replace('.0', '');
            if (dps == 2) return mfin.replace('.00', '');
            if (dps == 3) return mfin.replace('.000', '');
            if (dps == 4) return mfin.replace('.0000', '');
            return mfin;
        }

        function fixNearest(x, y) {
            return Math.round(x / y) * y;
        }

        function alertNaN(thisparam) {
            alert(thisparam + ' is improperly formatted. You may only input the digits 0-9 and a decimal point.');
            doCalc = false;
            clrResults();
        }

        function clrValue(field) {
            field.value = '';
        }

        var currenttimeout;

        function resetInTime() {
            if (currenttimeout) clearTimeout(currenttimeout);
            currenttimeout = setTimeout('minMaxCheck();', 3000);
        }



        var curelement;

        function togCB(thisid) {
            thischeckbox = document.getElementById(thisid);
            if (thischeckbox.checked) { thischeckbox.checked = false; }
            else { thischeckbox.checked = true; }
            BodySurfaceArea_fx();
        }

        function setRB(thisid) {
            document.getElementById(thisid).checked = true;
            BodySurfaceArea_fx();
        }


        var calctxt = '';
        var xmltxt = '';
        var xmlresult = '';
        var htmtxt = '';
        var postNow = false;
        var printing = false;
        var interptxt = '';
        var interphtm = '';
        var interpxml = '';
        var rbchk = false;

        function BodySurfaceArea_fx() {
           
            with (document.forms[0]) {
                

                doCalc = true;
                param_value = parseFloat(Height_param.value);
                if (isNaN(param_value)) { param_value = ""; doCalc = false; }
                unit_parts = Height_unit.options[Height_unit.selectedIndex].value.split('|');
                Height = param_value * parseFloat(unit_parts[0]) + parseFloat(unit_parts[1]);
                param_value = parseFloat(Weight_param.value);
                if (isNaN(param_value)) { param_value = ""; doCalc = false; }
                unit_parts = Weight_unit.options[Weight_unit.selectedIndex].value.split('|');
                Weight = param_value * parseFloat(unit_parts[0]) + parseFloat(unit_parts[1]);
                dp = decpts.options[decpts.selectedIndex].text;
                BSA = 0.007184 * power(Height, 0.725) * power(Weight, 0.425);

                unit_parts = BSA_unit.options[BSA_unit.selectedIndex].value.split('|');
                if (doCalc) BSA_param.value = fixDP((BSA - parseFloat(unit_parts[1])) / parseFloat(unit_parts[0]), dp);





            }




        }

        function minMaxCheck() {
            if (printing) return;



            with (document.forms[0]) {

                if (Height_param.value && isNaN(Height_param.value)) { clrValue(Height_param); alertNaN('Height'); }
                if (Weight_param.value && isNaN(Weight_param.value)) { clrValue(Weight_param); alertNaN('Weight'); }


            }

        }

        function clrResults() {


            with (document.forms[0]) {

                BSA_param.value = '';


            }

        }

        var Height = null,
            Weight = null,
            BSA = null,
            param_value = null;


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
