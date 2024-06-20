<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="Prescricao.aspx.cs" Inherits="Prescricao_Prescricao"
    Title="Prescricao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <%-- <meta http-equiv="refresh" content="1000" />--%>


    <link href="../js_datepicker/jquery-ui.css" rel="stylesheet" />



    <style type="text/css">
        /* Custom styles to ensure the second modal appears above the first */
        /* Custom styles to ensure the second modal appears above the first */
        /*.modal-backdrop {
            z-index: 1040;
        }

        .modal {
            z-index: 1050;
        }*/
        .button-container {
            display: flex;
            flex-wrap: wrap;
            width: 100%;
        }

        .button-wrapper {
            /*flex: 1 0 33.33%;*/ /* Three buttons per row */
            flex: 1 0 25%; /* Four buttons per row */
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 10px;
        }

            .button-wrapper .btn {
                width: 100%;
                max-width: 200px; /* Set a max width if needed */
                padding: 10px;
                font-size: 16px;
                cursor: pointer;
                border: 1px solid #ccc;
                transition: background-color 0.3s;
            }

        .btn-primary.atualizar {
            background-color: #007bff;
            border-color: #007bff;
            color: white;
        }

        .btn-info.visualizar-medicamento {
            background-color: #17a2b8;
            border-color: #17a2b8;
            color: white;
        }

        .btn-success.imprimir {
            background-color: #28a745;
            border-color: #28a745;
            color: white;
        }

        .btn-secondary.visualizar-agendamento {
            background-color: #023020;
            border-color: #023020;
            color: white;
        }

        .button-wrapper .btn:hover {
            opacity: 0.8;
        }

        @media (max-width: 768px) {
            .button-wrapper {
                flex: 1 0 50%; /* Two buttons per row on smaller screens */
            }
        }

        @media (max-width: 480px) {
            .button-wrapper {
                flex: 1 0 100%; /* One button per row on very small screens */
            }
        }



        .modal-dialog-custom {
            max-width: 50%; /* Adjust width as needed */
        }



        .modal-body-custom {
            height: 500px; /* Adjust height as needed */
            width: 500px;
            overflow-y: auto; /* Enable scrolling if content overflows */
        }

        /* Container for the modal that covers the entire viewport 	*/
        .custom-green-button {
            background-color: green;
            border-color: green;
            color: white; /* Optional: To change the text color to white */
        }

        .modal-container {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: rgba(0, 0, 0, 0.4);
            Optional: Dim background
        }
        /*
        Styles for the modal content itself*/
        .modal-content {
            width: 800px;
            Fixed width height: 800px;
            Fixed height background: white;
            Optional: Background color border-radius: 8px;
            Optional: Rounded corners box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            Optional: Box shadow for better visibility Centering the modal content within the container display: flex;
            justify-content: center;
            align-items: center;
        }

        /*  Custom styles for the first modal*/
        .modal-fade-one .modal-content {
            /*  background-color: #f0f8ff;
            AliceBlue background border: 1px solid #0000ff;
            Blue border*/
        }

        /* Custom styles for the second modal*/
        .modal-fade-two .modal-content {
            width: 800px;
            Fixed width height: 400px;
            Fixed height background-color: #fff0f5;
            /* LavenderBlush background border: 1px solid #ff69b4;
            HotPink border*/
        }



        .modal-content-custom {
            width: 700px;
            border-radius: 15px;
            justify-content: center;
            align-items: center;
            height: 300px;
        }

        .modal-fade-two .modal-header {
            padding: 1rem;
            border-bottom: 1px solid #e9ecef;
        }

        .modal-fade-two .modal-body {
            padding: 4rem;
            border-bottom: 1px solid #e9ecef;
        }

        #myModalAgendamento .modal-body {
            max-height: 1000px; /* Altura específica para o modal customizado */
            width: 500px; /* Largura específica para o modal customizado */
        }

        .modal-body {
            max-height: 1000px;
            overflow-y: auto;
        }


        .gridview-custom th, .gridview-custom td {
            padding: 8px;
            text-align: left;
        }

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
    </style>

    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>



            <asp:ScriptReference Path="../js_datepicker/jquery-ui.js" />



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
                    <asp:RequiredFieldValidator ErrorMessage="Preencher o campo selecionado." ControlToValidate="txbProntuario"
                        InitialValue="" runat="server" ForeColor="Red" />
                </div>
                <div class="col-md-5 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nome
                    </label>
                    <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Preencher o campo selecionado." ControlToValidate="txbNomePaciente"
                        InitialValue="" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="row">

                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        DDD
                    </label>
                    <asp:TextBox ID="txbDdd" runat="server" class="form-control"></asp:TextBox>
                </div>

                <div class="col-md-5 col-sm-12 col-xs-12 form-group">
                    <label>
                        Telefone
                    </label>
                    <asp:TextBox ID="txbTelefone" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>


            <div class="row">

                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nascimento</label>
                    <asp:TextBox ID="txbNascimento" runat="server" class="form-control nasc"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Preencher o campo selecionado." ControlToValidate="txbNascimento"
                        InitialValue="" runat="server" ForeColor="Red" />
                </div>
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        Idade</label>
                    <asp:TextBox ID="txbIdade" runat="server" class="form-control age"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Sexo</label>
                    <asp:DropDownList ID="ddlSexo" runat="server" class="form-control">
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Feminino</asp:ListItem>
                        <asp:ListItem Selected="True">Não Informado</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nome do Pai/Mãe</label>
                    <asp:TextBox ID="txbPais" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="Preencher o campo selecionado." ControlToValidate="txbPais"
                        InitialValue="" runat="server" ForeColor="Red" />
                </div>
            </div>
            <br />
            <div class="nav justify-content-md-center">
                <input id="btnCalculo" type="button" value="Cálculo da Superfície Corpórea" onclick="mostraCalculo()"
                    class="btn btn-outline-info btn-block" />
            </div>












            <div id="divCalculoCorpo" style="display: none;">
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
                                <span class="medCalcFontIO">Entrada
                                </span>
                                <br />
                                &nbsp;<br />
                                <table cellpadding="3" cellspacing="0" summary="EBMcalc Table">
                                    <tr>
                                        <td align="right" width="42%"><span class="medCalcFontOneBold">Altura</span> </td>
                                        <td align="left" valign="top" nowrap="nowrap" width="5%">&nbsp;
                                            <input type="text" id="txbAltura" name="Height_param" size="6" value="" onblur="BodySurfaceArea_fx(); minMaxCheck();" onchange="BodySurfaceArea_fx();" aria-label="Use this input box to enter the value Height" runat="server" /></td>
                                        <td align="left" valign="top">
                                            <select name="Height_unit" onchange="BodySurfaceArea_fx(); minMaxCheck();" style="width: 115px;" class="medCalcFontSelect" aria-label="Use this pulldown selector to set the unit of measure for the value Height">
                                                <option value="1|0|cm" selected="selected">cm</option>

                                            </select></td>
                                    </tr>

                                    <tr>
                                        <td align="right" width="42%"><span class="medCalcFontOneBold">Peso</span> </td>
                                        <td align="left" valign="top" nowrap="nowrap" width="5%">&nbsp;
                                            <input type="text" id="txbPeso" name="Weight_param" size="6" value="" onblur="BodySurfaceArea_fx(); minMaxCheck();" onchange="BodySurfaceArea_fx();" aria-label="Use this input box to enter the value Weight" runat="server" /></td>
                                        <td align="left" valign="top">
                                            <select name="Weight_unit" onchange="BodySurfaceArea_fx(); minMaxCheck();" style="width: 115px;" class="medCalcFontSelect" aria-label="Use this pulldown selector to set the unit of measure for the value Weight">

                                                <option value="1|0|kg" selected="selected">kg</option>

                                            </select></td>
                                    </tr>


                                </table>

                            </center>

                        </div>
                        <br />
                        &nbsp;<br />
                        <div id="calc_result">
                            <center>
                                <span class="medCalcFontIO">Resultado</span>

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
                                            <input type="text" id="txbBSA" name="BSA_param" size="6" aria-readonly="true" aria-label="This output box will display the calculated value BSA" runat="server" /></td>
                                        <td valign="top" align="left"><span class="medCalcFontResultParam">
                                            <select name="BSA_unit" onchange="BodySurfaceArea_fx();" style="width: 115px;" class="medCalcFontSelect" aria-label="Use this pulldown selector to set the unit of measure for the result value BSA">

                                                <option value="1|0|sqm" selected="selected">sqm</option>

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

                                                <option selected="selected">2</option>


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
                        <span class="medCalcFontOneBold">Nota</span>
                        <ul class="medCalcFontOne">
                            <li><font color="#aa0000">O valor padrão para a unidade de medida para peso é kilograma.  Por favor verifique se a correta unidade de medida foi selecionada.</font></li>


                        </ul>
                    </div>

                    <br />
                    &nbsp;<br />
                    <span class="medCalcFontRef"><b>Equação utilizada</b></span>

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
                        <span class="medCalcFontRef"><b>Referência</b></span>
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
              
            </div>
            <div class="nav justify-content-md-center">
                <input id="btnGeral" type="button" value="Geral" onclick="mostraGeral()" class="btn btn-outline-info btn-block" />
            </div>
            <div class="x_content">
                <div id="divGeral" style="display: none;">
                    <div class="x_panel">


                        <div class="row">
                            <div class="col-md-5 col-sm-12 col-xs-12 form-group">
                                <label>
                                    Lista de Protocolo:
                                </label>



                                <asp:DropDownList ID="ddlProtocolo" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-2 form-group">
                                <label>
                                    Ciclos Prováveis:
                                </label>
                                <asp:TextBox ID="txbCiclos" runat="server" class="form-control numeric"></asp:TextBox>
                                <asp:RequiredFieldValidator ErrorMessage="Preencher o campo selecionado." ControlToValidate="txbCiclos"
                                    InitialValue="" runat="server" ForeColor="Red" />
                            </div>
                            <div class="col-md-2  form-group">
                                <label>
                                    Com Intervalo de:(DIAS)
                                </label>
                                <asp:TextBox ID="txbIntervalos" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ErrorMessage="Preencher o campo selecionado." ControlToValidate="txbIntervalos"
                                    InitialValue="" runat="server" ForeColor="Red" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                                <label>
                                    Data de Início:
                                </label>
                                <asp:TextBox ID="txbDtInicio" class="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ErrorMessage="Preencher o campo selecionado." ControlToValidate="txbDtInicio"
                                    InitialValue="" runat="server" ForeColor="Red" />
                            </div>
                            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                                <label>
                                    Creatinina(mg/dl):
                                </label>
                                <asp:TextBox ID="txbCreatinina" class="form-control" runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                                <label>
                                    Finalidade:
                                </label>
                                <asp:DropDownList ID="ddlFinalidade" runat="server" class="form-control"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5 col-sm-12 col-xs-12 form-group">
                                <label>
                                    Observação:
                                </label>
                                <asp:TextBox ID="txbObservacao" runat="server" class="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>




            </div>

            <div class="nav justify-content-md-center">
                <input id="btnViaDeAcesso" type="button" value="Vias de Acesso" onclick="mostraViasDeAcesso()" class="btn btn-outline-info btn-block" />
            </div>
            <div class="x_content">
                <div id="divViasDeAcesso" style="display: none;">
                    <div class="x_panel">
                        <div class="col-5">
                            Vias de Acesso:
                        </div>
                        <div>

                            <asp:CheckBoxList ID="cblViasDeAcesso" RepeatDirection="Horizontal" runat="server" Font-Size="Large" Width="1000"></asp:CheckBoxList>
                        </div>



                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" OnClientClick="openConfirmationModal(); return false;" />
            </div>
            <%--<button type="button" class="btn btn-primary" onclick="showModal('myModalMedicamento')">
                    Open First Modal
                </button>--%>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12 form-group button-container">
                <div class="button-wrapper">
                    <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" class="btn btn-primary atualizar" OnClick="btnAtualizar_Click" data-toggle="modal" />
                </div>
                <div class="button-wrapper">
                    <asp:Button ID="btnVisualizarMedicamento" runat="server" Text="Visualizar Medicamento" class="btn btn-info visualizar-medicamento" OnClick="btnVisualizarMedicamento_Click" data-toggle="modal" />
                </div>
                <div class="button-wrapper">
                    <asp:Button ID="btnAgendar" runat="server" Text="Visualizar Agendamento" class="btn btn-secondary visualizar-agendamento" data-toggle="modal" OnClick="btnAgendar_Click" />
                </div>
                <div class="button-wrapper">
                    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" class="btn btn-success imprimir" OnClientClick="openConfirmationModal2(); return false;" />
                </div>

            </div>
        </div>
    </div>
    <!-- Modal -->
        <div class="modal fade" id="confirmationModal" tabindex="-1" role="dialog" aria-labelledby="confirmationModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="confirmationModalLabel">Confirmation</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Are you sure you want to proceed?
     
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>

                        <asp:Button ID="btnTeste" runat="server" Text="Confirm" CssClass="btn btn-success imprimir"
                            OnClick="btnGravar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Large modal -->
        <%--  <div class="container">--%>
        <!-- Trigger the modal with a button -->
        <%--<button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModalImpressora">
                Imprimir</button>--%>
        <!-- Modal -->
        <div class="modal fade" id="myModalImpressora" role="dialog">
            <div class="modal-dialog modal-dialog-custom">
                <!-- Modal content-->
                <div class="modal-content modal-content-custom">
                    <div class="modal-header">
                        <h4 class="modal-title">Selecione a Impressora</h4>
                    </div>
                    <div class="modal-body modal-body-custom">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Ficha</legend>
                            <div class="row">



                                <div class="col-md-12 col-sm-12 col-xs-12 form-group">

                                    <div class="col-md-6 col-sm-12">
                                        Impressoras:
    <asp:DropDownList ID="ddlImpressora" class="form-control" runat="server">
        <asp:ListItem>Microsoft Print to PDF</asp:ListItem>
        <asp:ListItem>ONCO_SEC</asp:ListItem>
        <asp:ListItem>ONCO_ENF</asp:ListItem>
        <asp:ListItem>INFO</asp:ListItem>
        <asp:ListItem>IMPRESSORA</asp:ListItem>
    </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-12">
                                        Cópias:
                                        <asp:DropDownList ID="ddlVias" class="form-control " runat="server">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>




                                </div>
                            </div>


                        </fieldset>

                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-4 col-sm-4 col-xs-8 ">
                                    <asp:Button ID="btn" runat="server" Text="Gravar" class="btn btn-primary gravar"
                                        OnClick="btnImprimir_Click" data-toggle="modal" />
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- </div>--%>
        <%-- <div class="container">--%>
        <!-- Trigger the modal with a button -->
        <%--<div class="col-md-4 col-sm-4 col-xs-8 ">
                <asp:Button ID="Button1" runat="server" Text="Gravar" EnableViewState="true"  
                    OnClick="btnGravar_Click"  />
            </div>--%>

        <!-- Modal -->
        <div class="modal fade three" id="myModalAgendamento">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Informações dos Agendamento</h4>
                    </div>
                    <div class="modal-body">
                        <div class="modal-header">
                            <h4 class="modal-title">Agenda</h4>
                        </div>
                        <asp:GridView ID="GridViewAgendamento" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_agenda" OnRowCommand="gridViewAgendamento_RowCommand"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1"
                            Width="100%">


                            <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="posicao" HeaderText="Posicao" SortExpression="posicao"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />





                                <asp:BoundField DataField="data_agendada" HeaderText="Data Agendada" SortExpression="data_agendada"
                                    DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />







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
                    <div class="modal-footer">


                        <asp:Button ID="Button2" runat="server" Text="Confirmar" CssClass="btn btn-success imprimir"
                            data-dismiss="modal" />
                    </div>
                </div>
            </div>
        </div>




        <!-- Modal -->
        <div class="modal fade one" id="myModalMedicamento">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Informações dos Medicamentos</h4>
                    </div>
                    <div class="modal-body">
                        <div class="modal-header">
                            <h4 class="modal-title">PreQuimio</h4>
                        </div>
                        <asp:GridView ID="GridViewPreQuimio" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_CalculoDosagemPreQuimio" OnRowCommand="gridViewPreQuimio_RowCommand"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1"
                            Width="100%">


                            <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="desc_medicacao" HeaderText="Medicação" SortExpression="desc_medicacao"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />



                                <asp:TemplateField HeaderText="Dosagem" SortExpression="quantidade">
                                    <ItemTemplate>
                                        <%# Eval("dose_alterada") %> <%# Eval("unidade_dose") %>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="hidden-md" />
                                    <HeaderStyle CssClass="hidden-md" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="desc_via_de_administracao" HeaderText="Via de Administração" SortExpression="desc_via_de_administracao"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />

                                <asp:BoundField DataField="desc_quimio" HeaderText="Quimio" SortExpression="desc_quimio"
                                    ItemStyle-CssClass="hidden-md" HeaderStyle-CssClass="hidden-md" />

                                <asp:BoundField DataField="diluicao" HeaderText="Diluicao" SortExpression="diluicao"
                                    HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />



                                <asp:TemplateField HeaderText="Infusão" SortExpression="tempoDeInfusao">
                                    <ItemTemplate>
                                        <%# Eval("tempoDeInfusao") %> <%# Eval("unidadeTempoDeInfusao") %>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="hidden-md" />
                                    <HeaderStyle CssClass="hidden-md" />
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
                        <div class="modal-header">
                            <h4 class="modal-title">Protocolo</h4>
                        </div>
                        <asp:GridView ID="GridViewProtocolo" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_CalculoDosagem" OnRowCommand="gridViewProtocolo_RowCommand"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" BorderColor="#e0ddd1"
                            Width="100%">

                            <RowStyle BackColor="#f7f6f3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="desc_medicacao" HeaderText="Medicação" SortExpression="desc_medicacao"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />


                                <asp:TemplateField HeaderText="Dosagem" SortExpression="dosagem">
                                    <ItemTemplate>
                                        <%# Eval("dose_alterada") %> <%# Eval("unidade_dosagem") %>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="hidden-md" />
                                    <HeaderStyle CssClass="hidden-md" />
                                </asp:TemplateField>



                                <asp:BoundField DataField="desc_via_de_administracao" HeaderText="Via de Administração" SortExpression="desc_via_de_administracao"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />



                                <asp:BoundField DataField="diluicao" HeaderText="Diluicao" SortExpression="diluicao"
                                    HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />


                                <asp:TemplateField HeaderText="Infusao" SortExpression="tempoDeInfusao">
                                    <ItemTemplate>
                                        <%# Eval("tempoDeInfusao") %> <%# Eval("unidadeTempoDeInfusao") %>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="hidden-md" />
                                    <HeaderStyle CssClass="hidden-md" />
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
                    <div class="modal-footer">


                        <asp:Button ID="Button1" runat="server" Text="Confirmar" CssClass="btn btn-success imprimir"
                            data-dismiss="modal" />
                    </div>
                </div>
            </div>
        </div>

        <%--   <div class="container">--%>
        <!-- Modal -->
        <div class="modal fade two" id="myModalEdicaoAgenda" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Atualização da Agenda</h4>
                    </div>



                    <div class="modal-body">

                        <fieldset class="scheduler-border">
                            <legend id="lbPaciente" class="scheduler-border" runat="server"></legend>
                            <div class="row">
                                <div class="col-md-3 col-sm-12">
                                    <label id="lbCodigoAgenda" for="txbCodigoAgenda" runat="server">
                                        Codigo:
                                    </label>
                                    <asp:TextBox ID="txbCodigoAgenda" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                                    <div class="row">

                                        <div class="col-md-6 col-sm-12">
                                            <label for="txbDataAgenda">
                                                Data Agenda:
                                            </label>
                                            <asp:TextBox ID="txbDataAgenda" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>

                                        <div class="col-md-6 col-sm-12">
                                            <label for="txbDataAlterada">
                                                Data Atualizada:
                                            </label>
                                            <asp:TextBox ID="txbDataAlterada" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>

                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                                <div class="col-md-6 col-sm-4 col-xs-8 ">
                                    <asp:Button ID="Button3" runat="server" Text="Gravar" class="btn btn-primary gravar"
                                        OnClick="btnGravarAgenda_Click" data-toggle="modal" />
                                </div>

                                <div class="col-md-6 col-sm-4 col-xs-8 ">
                                    <asp:Button ID="Button4" runat="server" Text="Cancelar" class="btn btn-success"
                                        OnClick="btnCancelarAgenda_Click" data-toggle="modal" />
                                </div>
                            </div>
                        </div>
                    </div>




                </div>
            </div>

        </div>
        <%--   <div class="container">--%>
        <!-- Modal -->
        <div class="modal fade two" id="myModalDosagem" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Atualização da dosagem</h4>
                    </div>



                    <div class="modal-body">
                        <asp:Label ID="lblNome" runat="server"></asp:Label>
                        <fieldset class="scheduler-border">
                            <legend id="lbMedicacao" class="scheduler-border" runat="server"></legend>
                            <div class="row">
                                <div class="col-md-3 col-sm-12">
                                    <label id="lbCodigo" for="txbCodigo" runat="server">
                                        Codigo:
                                    </label>
                                    <asp:TextBox ID="txbCodigo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                                    <div class="row">

                                        <div class="col-md-4 col-sm-12">
                                            <label for="txbDoseProtocolo">
                                                Valor Protocolo:
                                            </label>
                                            <asp:TextBox ID="txbDoseProtocolo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 col-sm-12">
                                            <label for="ddlPercentagem">
                                                Porcentagem:
                                            </label>
                                            <asp:DropDownList ID="ddlPercentagem" runat="server" class="form-control">
                                                <asp:ListItem Value="0">0%</asp:ListItem>
                                                <asp:ListItem Value="10">10%</asp:ListItem>
                                                <asp:ListItem Value="20">20%</asp:ListItem>
                                                <asp:ListItem Value="30">30%</asp:ListItem>
                                                <asp:ListItem Value="40">40%</asp:ListItem>
                                                <asp:ListItem Value="50">50%</asp:ListItem>
                                                <asp:ListItem Value="60">60%</asp:ListItem>
                                                <asp:ListItem Value="70">70%</asp:ListItem>
                                                <asp:ListItem Value="80">80%</asp:ListItem>
                                                <asp:ListItem Value="90">90%</asp:ListItem>
                                                <asp:ListItem Value="100">100%</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-4 col-sm-12">
                                            <label for="txbDoseAlterada">
                                                Valor Atualizado:
                                            </label>
                                            <asp:TextBox ID="txbDoseAlterada" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>

                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                                <div class="col-md-6 col-sm-4 col-xs-8 ">
                                    <asp:Button ID="btnGravarDosagem" runat="server" Text="Gravar" class="btn btn-primary gravar"
                                        OnClick="btnGravarDosagem_Click" data-toggle="modal" />
                                </div>

                                <div class="col-md-6 col-sm-4 col-xs-8 ">
                                    <asp:Button ID="btnCancelarDosagem" runat="server" Text="Cancelar" class="btn btn-success"
                                        OnClick="btnCancelarDosagem_Click" data-toggle="modal" />
                                </div>
                            </div>
                        </div>
                    </div>




                </div>
            </div>

        </div>



        <%--     <!-- The First Modal -->
            <div class="modal fade" id="myModal1">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">First Modal</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <!-- Modal Body -->
                        <div class="modal-body">
                            This is the body of the first modal.
        <br>
                            <br>
                            <!-- Button to Open the Second Modal from within the First Modal -->
                            <button type="button" class="btn btn-secondary" onclick="showModal('myModal2')">
                                Open Second Modal
                            </button>
                        </div>
                        <!-- Modal Footer -->
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- The Second Modal -->
            <div class="modal fade" id="myModal2">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Second Modal</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <!-- Modal Body -->
                        <div class="modal-body">
                            This is the body of the second modal.
                        </div>
                        <!-- Modal Footer -->
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
         <script src='<%= ResolveUrl("~/build/js/popper.min.js") %>' type="text/javascript"></script>
        <script src='<%= ResolveUrl("~/build/js/bootstrap.min.js") %>' type="text/javascript"></script>
        
        <%-- <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js" type="text/javascript"></script>--%>

        <script src="../js/decimal.min.js" type="text/javascript"></script>

        <script type="text/javascript">
            function showModal(modalId) {
                $('#' + modalId).modal('show');
            }
            function openConfirmationModal() {
                $('#confirmationModal').modal('show');
            }
            function openConfirmationModal2() {
                $('#myModalImpressora').modal('show');
            }
            //function adjustZIndex() {
            //    var visibleModals = $('.modal:visible');
            //    visibleModals.each(function (index) {
            //        var zIndex = 1050 + (10 * index);
            //        $(this).css('z-index', zIndex);
            //        $(this).next('.modal-backdrop').css('z-index', zIndex - 1);
            //    });
            //}

            //$('#myModalDosagem').on('shown.bs.modal', function () {
            //    adjustZIndex();
            //});

            //$('#myModalMedicamento').on('shown.bs.modal', function () {
            //    adjustZIndex();
            //});

            ////function adjustZIndex() {
            ////    var zIndex = 1040 + (10 * $('.modal:visible').length);
            ////    console.log("Adjusting z-index to:", zIndex);
            ////    $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack').css('background-color', 'rgba(255, 0, 0, 0.5)'); // Add temporary red background
            ////}

            ////// Adjust the backdrop to ensure proper stacking order for the second modal
            ////$('#myModalDosagem').on('show.bs.modal', function () {
            ////    var zIndex = 1040 + (10 * $('.modal:visible').length);
            ////    console.log("Showing second modal, z-index:", zIndex);
            ////    $(this).css('z-index', zIndex);
            ////    adjustZIndex();
            ////});

            ////// Adjust the backdrop to ensure proper stacking order for the first modal
            ////$('#myModalMedicamento').on('show.bs.modal', function () {
            ////    var zIndex = 1040 + (10 * $('.modal:visible').length);
            ////    console.log("Showing first modal, z-index:", zIndex);
            ////    $(this).css('z-index', zIndex);
            ////    adjustZIndex();
            //});
            // Adjust the backdrop to ensure proper stacking order
            //$('#myModalDosagem').on('show.bs.modal', function () {
            //    var zIndex = 1040 + (10 * $('.modal:visible').length);
            //    $(this).css('z-index', zIndex);

            //     adjustZIndex();
            //});
            //function adjustZIndex() {
            //    var zIndex = 1040 + (10 * $('.modal:visible').length);
            //    $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
            //}
            function calculateValorAtualizado() {

                var valorProtocolo = new Decimal(document.getElementById('<%= txbDoseProtocolo.ClientID %>').value.replace(',', '.'));

                var percentagem = new Decimal(document.getElementById('<%= ddlPercentagem.ClientID %>').value.replace(',', '.'));
                var valorAtualizado = document.getElementById('<%= txbDoseAlterada.ClientID %>');

                if (valorProtocolo && percentagem) {
                    var result = valorProtocolo.times(percentagem).dividedBy(100).toFixed(2);

                    valorAtualizado.value = result.replace('.', ',');
                } else {
                    valorAtualizado.value = "";
                }
            }

            window.onload = function () {
                document.getElementById('<%= txbDoseProtocolo.ClientID %>').oninput = calculateValorAtualizado;
                document.getElementById('<%= ddlPercentagem.ClientID %>').onchange = calculateValorAtualizado;
            }

            //function showModal() {
            //    $('#myModalMedicamento').modal('show');
            //}

            //function hideModal() {
            //    $('#myModalMedicamento').modal('hiden');

            //}

            //function showModalMedicamento() {
            //    $('#myModalDosagem').modal('show');
            //}

            //function hideModal() {
            //    $('#myModalDosagem').modal('hiden');
            //}
        </script>

        <script type="text/javascript">

            window.addEventListener('keydown', function (e) {

                if (e.key == 'F5' || e.key == 'Enter') e.preventDefault();
                else return true;
            });

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

                    param_value = parseFloat((<%= txbAltura.ClientID %>).value);

                    if (isNaN(param_value)) { param_value = ""; doCalc = false; }
                    unit_parts = Height_unit.options[Height_unit.selectedIndex].value.split('|');
                    Height = param_value * parseFloat(unit_parts[0]) + parseFloat(unit_parts[1]);
                    param_value = parseFloat((<%= txbPeso.ClientID %>).value);
                    if (isNaN(param_value)) { param_value = ""; doCalc = false; }
                    unit_parts = Weight_unit.options[Weight_unit.selectedIndex].value.split('|');
                    Weight = param_value * parseFloat(unit_parts[0]) + parseFloat(unit_parts[1]);
                    dp = decpts.options[decpts.selectedIndex].text;
                    BSA = 0.007184 * power(Height, 0.725) * power(Weight, 0.425);

                    unit_parts = BSA_unit.options[BSA_unit.selectedIndex].value.split('|');
                    if (doCalc) (<%= txbBSA.ClientID %>).value = fixDP((BSA - parseFloat(unit_parts[1])) / parseFloat(unit_parts[0]), dp);





                }




            }

            function minMaxCheck() {
                if (printing) return;



                with (document.forms[0]) {

                    if ((<%= txbAltura.ClientID %>).value && isNaN((<%= txbAltura.ClientID %>).value)) { clrValue((<%= txbAltura.ClientID %>)); alertNaN('Height'); }
                    if ((<%= txbPeso.ClientID %>).value && isNaN((<%= txbPeso.ClientID %>).value)) { clrValue((<%= txbPeso.ClientID %>)); alertNaN('Weight'); }


                }

            }



            function clrResults() {


                with (document.forms[0]) {

                    (<%= txbBSA.ClientID %>).value = '';


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
            function mostraGeral() {

                var div = document.getElementById('divGeral');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
            function mostraViasDeAcesso() {

                var div = document.getElementById('divViasDeAcesso');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }

            function ClearInputs() {
                (<%= txbAltura.ClientID %>).value = '';
                (<%= txbPeso.ClientID %>).value = '';
                (<%= txbBSA.ClientID %>).value = '';

                $("#<%=select1.ClientID %>").val('').trigger("chosen:updated");
            }
            $(document).ready(function () {
                $(<%= txbNascimento.ClientID %>).mask("99/99/9999");
                $("#<%=select1.ClientID %>").chosen({ no_results_text: "Nada encontrado!" });

                $("#<%=txbDtInicio.ClientID%>").datepicker({
                    minDate: 0,
                    dateFormat: 'dd/mm/yy',
                    dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
                    dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                    dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                    monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                    monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                    nextText: 'Proximo',
                    prevText: 'Anterior'
                });


                $("#<%=txbDtInicio.ClientID%>").datepicker();

                $("#<%=txbDataAlterada.ClientID%>").datepicker({
                    minDate: 0,
                    dateFormat: 'dd/mm/yy',
                    dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
                    dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                    dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                    monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                    monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                    nextText: 'Proximo',
                    prevText: 'Anterior'
                });
                $("#<%=txbDataAlterada.ClientID%>").mask("99/99/9999");

                $("#<%=txbDataAlterada.ClientID%>").datepicker();

                $('#<%= txbCreatinina.ClientID %>').inputmask({ 'mask': "9{0,1},9{0,2}", greedy: false });

                $("#<%=txbDtInicio.ClientID%>").mask("99/99/9999");
                $("#<%=txbCiclos.ClientID%>").maskAsNumber({
                    min: 1,
                    max: 12
                });
                $("#<%=txbIntervalos.ClientID%>").maskAsNumber({
                    min: 1,
                    max: 30
                });


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


                            response($.map(data.d, function (item) {

                                return {

                                    label: item.nm_nome,
                                    value: item.nm_nome,


                                    prontuario: item.cd_prontuario,
                                    nr_ddd_fone: item.nr_ddd_fone,
                                    nr_fone: item.nr_fone,
                                    dt_nascimento: item.dt_data_nascimento,
                                    idade: item.nr_idade,
                                    sexo: item.in_sexo,
                                    nome_pai_mae: item.nm_mae,

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
                    $("[id$=txbDdd").val(i.item.nr_ddd_fone);
                    $("[id$=txbTelefone").val(i.item.nr_fone);

                    $("[id$=txbNomePaciente").val(i.item.nome_paciente);
                    $("[id$=txbNascimento").val(i.item.dt_nascimento);
                    $("[id$=txbIdade").val(i.item.idade);
                    $("[id$=ddlSexo").val(i.item.sexo == "M" ? "Masculino" : "Feminino");
                    $("[id$=txbPais").val(i.item.nome_pai_mae);
                },

                minLength: 1 //This is the Char length of inputTextBox  


            });


                $("#<%= txbProntuario.ClientID %>").autocomplete({

                    source: function (request, response) {
                        var param = { prefixo: $('#<%= txbProntuario.ClientID %>').val() };
                    $.ajax({
                        url: "Prescricao.aspx/GetNomeDePacientesPoRh",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {


                            response($.map(data, function (item) {

                                return {

                                    label: item.cd_prontuario,
                                    value: item.cd_prontuario,


                                    nome_paciente: item.nm_nome,
                                    nr_ddd_fone: item.nr_ddd_fone,
                                    nr_fone: item.nr_fone,
                                    dt_nascimento: item.dt_data_nascimento,
                                    idade: item.nr_idade,
                                    sexo: item.in_sexo,
                                    nome_pai_mae: item.nm_mae,

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
                    $("[id$=txbDdd").val(i.item.nr_ddd_fone);
                    $("[id$=txbTelefone").val(i.item.nr_fone);
                    $("[id$=txbNomePaciente").val(i.item.nome_paciente);
                    $("[id$=txbNascimento").val(i.item.dt_nascimento);
                    $("[id$=txbIdade").val(i.item.idade);
                    $("[id$=ddlSexo").val(i.item.sexo == "M" ? "Masculino" : "Feminino");
                    $("[id$=txbPais").val(i.item.nome_pai_mae);
                },
                minLength: 1 //This is the Char length of inputTextBox    

            });
            });

        </script>

        <script type="text/javascript">
            function MutExChkList(chk) {
                var chkList = chk.parentNode.parentNode.parentNode;
                var chks = chkList.getElementsByTagName("input");
                for (var i = 0; i < chks.length; i++) {
                    if (chks[i] != chk && chk.checked) {
                        chks[i].checked = false;
                    }
                }
            }
            document.addEventListener('DOMContentLoaded', function () {
                var checkBoxList = document.querySelectorAll('#<%= cblViasDeAcesso.ClientID %> input[type="checkbox"]');
                checkBoxList.forEach(function (chk) {
                    chk.addEventListener('click', function () {
                        MutExChkList(this);
                    });
                });
            });
        </script>

        <script src="../js/chosen.jquery.min.js" type="text/javascript"></script>
        <script src="../js/jquery.mask.js" type="text/javascript"></script>
        <script src="../js_datepicker/jquery-mask-as-number.js" type="text/javascript"></script>
</asp:Content>
