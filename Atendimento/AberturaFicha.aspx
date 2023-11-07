<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="AberturaFicha.aspx.cs" Inherits="Atendimento_AberturaFicha"
    Title="Oncologia - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

  
   
    <meta http-equiv="refresh" content="1000" />


    <!--
     <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>
        -->
    <!-- iCheck 

    <script src='<%= ResolveUrl("~/vendors/iCheck/icheck.min.js") %>' type="text/javascript"></script>
        -->

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>
    

<script src="./JavaScript.js" type="text/javascript"></script>
    <script src="../vendors/jquery/dist/jquery-ui.js" type="text/javascript"></script>
    <link href="../vendors/jquery/dist/jquery-ui.css" rel="stylesheet" />

    <script src="../vendors/iCheck/icheck.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <link href="../vendors/iCheck/skins/line/blue.css" rel="stylesheet" />
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
  
    
  

    <script type="text/javascript">

        $(document).ready(function() {
            $.noConflict();

            $("#<%= txbNomePaciente.ClientID %>").autocomplete({

                source: function(request, response) {
                    var param = { prefixo: $('#<%= txbNomePaciente.ClientID %>').val() };
                    $.ajax({
                        url: "AberturaFicha.aspx/GetNomeDePacientes",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function(data) { return data; },
                        success: function(data) {
                            //console.log(JSON.stringify(data));
                            console.log("passando");
                            response($.map(data.d, function(item) {

                                return {

                                    label: item.nome_paciente,
                                    value: item.nome_paciente,

                                    dt_rh_be: item.dt_rh_be,
                                    prontuario: item.prontuario,
                                    documento: item.documento,
                                    cns: item.cns,
                                    tipo_paciente: item.tipo_paciente,
                                    nome_paciente: item.nome_paciente,
                                    dt_nascimento: item.dt_nascimento,
                                    idade: item.idade,
                                    sexo: item.sexo,
                                    raca: item.raca,
                                    endereco_rua: item.endereco_rua,
                                    numero_casa: item.numero_casa,
                                    complemento: item.complemento,
                                    bairro: item.bairro,
                                    municipio: item.municipio,
                                    uf: item.uf,
                                    cep: item.cep,
                                    nome_pai_mae: item.nome_pai_mae,
                                    responsavel: item.responsavel,
                                    telefone: item.telefone,
                                    telefone1: item.telefone1,
                                    telefone2: item.telefone2,
                                    email: item.email,
                                    procedencia: item.procedencia,
                                    informacao_complementar: item.informacao_complementar,
                                    queixa: item.queixa,
                                    setor: item.setor,
                                    usuario: item.usuario,
                                    info_resgate: item.info_resgate,
                                    rf: item.rf
                                }
                            }))
                        },
                        error: function(XMLHttpRequest, textStatus, errorThrown) {
                            var err = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(err.Message)
                        }
                    });
                },


                select: function(e, i) {


                    $("input[id=rbTipoPaciente][value=" + i.item.tipo_paciente + "]").attr('checked', 'checked');

                    //  $("input[id=rbTipoPaciente][value=" + i.item.tipo_paciente + "]").prop('checked', true);

                    $("[id$=ddlSetor").val(i.item.setor);
                    $("[id$=ddlProcedencia").val(i.item.procedencia);
                    $("[id$=ddlRaca").val(i.item.raca);
                    $("[id$=ddlSexo").val(i.item.sexo);
                    $("[id$=txbProntuario").val(i.item.prontuario);
                    $("[id$=txbDocumento").val(i.item.documento);
                    $("[id$=txbNomePaciente").val(i.item.nome_paciente);
                    $("[id$=txbNascimento").val(dateFormat(eval(i.item.dt_nascimento.replace('/', 'new ').replace('/', ''))));
                    $("[id$=txbIdade").val(calculateAge(eval(i.item.dt_nascimento.replace('/', 'new ').replace('/', ''))));
                    $("[id$=txbEndereco").val(i.item.endereco_rua);
                    $("[id$=txbNumero").val(i.item.numero_casa);
                    $("[id$=txbComplemento").val(i.item.complemento);
                    $("[id$=txbBairro").val(i.item.bairro);
                    $("[id$=txbMunicipio").val(i.item.municipio);
                    $("[id$=txbUF").val(i.item.uf);
                    $("[id$=txbPais").val(i.item.nome_pai_mae);
                    $("[id$=txbResponsavel").val(i.item.responsavel);
                    $("[id$=txbTelefone").val(i.item.telefone);
                    $("[id$=txbTelefone1").val(i.item.telefone1);
                    $("[id$=txbTelefone2").val(i.item.telefone2);
                    $("[id$=txbEmail").val(i.item.email);
                    $("[id$=txbQueixa").val(i.item.queixa);
                    $("[id$=txbInfoResgate").val(i.item.info_resgate);
                    $("[id$=txbRF").val(i.item.rf);
                    $("[id$=txbCEP").val(i.item.cep);
                },
                minLength: 1 //This is the Char length of inputTextBox    

            });


            function dateFormat(d) {
                return (d.getDate() + "").padStart(2, "0")
                + "/" + ((d.getMonth() + 1) + "").padStart(2, "0")
                + "/" + d.getFullYear();
            }


            //Quando o campo cep perde o foco.
            $("#<%=txbCEP.ClientID%>").blur(function() {
                //Nova variável "cep" somente com dígitos.
                var cep = $(this).val().replace(/\D/g, '');

                //Verifica se campo cep possui valor informado.
                if (cep != "") {

                    //Expressão regular para validar o CEP.
                    var validacep = /^[0-9]{8}$/;

                    //Valida o formato do CEP.
                    if (validacep.test(cep)) {

                        //Preenche os campos com "..." enquanto consulta webservice.
                        $("#<%=txbEndereco.ClientID%>").val("...");
                        $("#<%=txbBairro.ClientID%>").val("...");
                        $("#<%=txbMunicipio.ClientID%>").val("...");
                        $("#<%=txbUF.ClientID%>").val("...");

                        //Consulta o webservice viacep.com.br/
                        $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function(dados) {

                            if (!("erro" in dados)) {
                                //Atualiza os campos com os valores da consulta.
                                $("#<%=txbEndereco.ClientID%>").val(dados.logradouro);
                                $("#<%=txbBairro.ClientID%>").val(dados.bairro);
                                $("#<%=txbMunicipio.ClientID%>").val(dados.localidade);
                                $("#<%=txbUF.ClientID%>").val(dados.uf);
                            } //end if.
                            else {
                                //CEP pesquisado não foi encontrado.
                                alert("CEP não encontrado.");
                            }
                        });
                    } //end if.
                    else {
                        //cep é inválido.
                        alert("Formato de CEP inválido.");
                    }
                } //end if.
                else {
                    //cep sem valor, limpa formulário
                }
            });
            $("input").attr("autocomplete", "off");


            $('input').each(function() {
                var self = $(this),
               label = self.next(),
               label_text = label.text();

                label.remove();

                self.iCheck({
                    checkboxClass: 'icheckbox_line-blue',
                    radioClass: 'iradio_line-blue',
                    insert: '<div class="icheck_line-icon"></div>' + label_text
                });
            });


            
            $('.numeric').keyup(function() {
                $(this).val(this.value.replace(/\D/g, ''));
            });


            $('.nasc').blur(function() {
                var data = $('.nasc').val();
                if (data == "") {
                    $('.age').val("");
                } else {
                    var dateParts = data.split("/");
                    var dateObject = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
                    $('.age').val(calculateAge(dateObject));
                }
            });

        });
        $("#txbNascimento").mask("99/99/9999");
        
        function calculateAge(dobString) {
            var dob = new Date(dobString);
            var currentDate = new Date();
            var currentYear = currentDate.getFullYear();
            var birthdayThisYear = new Date(currentYear, dob.getMonth(), dob.getDate());
            var age = currentYear - dob.getFullYear();
            if (birthdayThisYear > currentDate) {
                age--;
            }
            return age;
        }

        function calcular(data) {
            var data = document.form.nascimento.value;
            alert(data);
            var partes = data.split("/");
            var junta = partes[2] + "-" + partes[1] + "-" + partes[0];
            document.form.idade.value = (calculateAge(junta));
        }

        var isDate_ = function(input) {
            var status = false;
            if (!input || input.length <= 0) {
                status = false;
            } else {
                var result = new Date(input);
                if (result == 'Invalid Date') {
                    status = false;
                } else {
                    status = true;
                }
            }
            return status;
        }
     
        $(document).ready(function() {

           
                $("input[id*='txbNascimento']").mask('99/99/9999');
            
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
  
            <div class="container">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            Atendimento<small><i>- Informações do Paciente</i></small></h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                RH</label>
                            <asp:TextBox ID="txbProntuario" runat="server" class="form-control numeric"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                RF</label>
                            <asp:TextBox ID="txbRF" runat="server" class="form-control numeric"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Outro Documento</label>
                            <asp:TextBox ID="txbDocumento" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Cartão SUS</label>
                            <asp:TextBox ID="txbCNS" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Tipo Paciente</label>
                            <asp:RadioButtonList ID="rbTipoPaciente"  RepeatDirection="Horizontal" runat="server" AutoPostBack="True" >
                                <asp:ListItem  Value="M" Selected="True" >Munícipe</asp:ListItem>
                                <asp:ListItem Value="F">Funcionário</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5 col-sm-12 col-xs-12 form-group">
                            <label>
                                Nome</label>
                            <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control" required></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Nascimento</label>
                            <asp:TextBox ID="txbNascimento" runat="server" class="form-control nasc" ></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                            <label>
                                Idade</label>
                            <asp:TextBox ID="txbIdade" runat="server" class="form-control age"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Sexo</label>
                            <asp:DropDownList ID="ddlSexo" runat="server" AutoPostBack="true" class="form-control">
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Feminino</asp:ListItem>
                                <asp:ListItem>Não Informado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Raça/Cor</label>
                            <asp:DropDownList ID="ddlRaca" runat="server" class="form-control" AutoPostBack="true">
                                <asp:ListItem>Branca</asp:ListItem>
                                <asp:ListItem>Preta</asp:ListItem>
                                <asp:ListItem>Parda</asp:ListItem>
                                <asp:ListItem>Amarela</asp:ListItem>
                                <asp:ListItem>Indígena</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                       <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                            <label>
                                CEP</label>
                            <asp:TextBox ID="txbCEP" MaxLength="10" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                            <label>
                                Endereço</label>
                            <asp:TextBox ID="txbEndereco" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                            <label>
                                Número</label>
                            <asp:TextBox ID="txbNumero" MaxLength="10" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                            <label>
                                Complemento</label>
                            <asp:TextBox ID="txbComplemento" runat="server" MaxLength="50" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Bairro</label>
                            <asp:TextBox ID="txbBairro" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Município</label>
                            <asp:TextBox ID="txbMunicipio" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                            <label>
                                UF</label>
                            <asp:TextBox ID="txbUF" MaxLength="2" runat="server" class="form-control"></asp:TextBox>
                        </div>
                     
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                            <label>
                                Nome do Pai/Mãe</label>
                            <asp:TextBox ID="txbPais" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                            <label>
                                Responsável</label>
                            <asp:TextBox ID="txbResponsavel" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                            <label>
                                Procedência</label>
                            <asp:DropDownList ID="ddlProcedencia" runat="server" class="form-control">
                                <asp:ListItem Text="ESPONTÂNEA"></asp:ListItem>
                                <asp:ListItem Text="BOMBEIRO"></asp:ListItem>
                                <asp:ListItem Text="POLÍCIA MILITAR"></asp:ListItem>
                                <asp:ListItem Text="GCM"></asp:ListItem>
                                <asp:ListItem Text="METRÔ"></asp:ListItem>
                                <asp:ListItem Text="AMA - SÉ"></asp:ListItem>
                                <asp:ListItem Text="SAMU"></asp:ListItem>
                                <asp:ListItem Text="AMBULÂNCIA PARTICULAR"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Telefone 1</label>
                            <asp:TextBox ID="txbTelefone" MaxLength="20" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Telefone 2</label>
                            <asp:TextBox ID="txbTelefone1" MaxLength="20" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <label>
                                Telefone 3</label>
                            <asp:TextBox ID="txbTelefone2" MaxLength="20" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-12 col-xs-12 form-group">
                            <label>
                                E-mail</label>
                            <asp:TextBox ID="txbEmail" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                            <label>
                                Queixa</label>
                            <asp:TextBox ID="txbQueixa" runat="server" class="form-control" TextMode="MultiLine"
                                Rows="3" required></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                            <asp:CheckBoxList runat="server" ID="chkFormaChegada" RepeatDirection="Horizontal"
                                Height="100px" Width="100%">
                                <asp:ListItem Text="Caso Policial"></asp:ListItem>
                                <asp:ListItem Text="Plano de Saúde"></asp:ListItem>
                                <asp:ListItem Text="Trauma"></asp:ListItem>
                                <asp:ListItem Text="Acidente de Trabalho"></asp:ListItem>
                                <asp:ListItem Text="Veio de Ambulância"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                            <label>
                                Informações do resgate</label>
                            <asp:TextBox ID="txbInfoResgate" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            Encaminhamento
                            <asp:Label ID="Label1" runat="server" Text="" Style="color: Black"></asp:Label></h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txbSetor" class="col-sm-1 col-form-label">
                            Setor:</label>
                        <div>
                            <asp:DropDownList ID="ddlSetor" runat="server" class="form-control" >
                                            <asp:ListItem>BucoMaxilo</asp:ListItem>
                                            <asp:ListItem>Cirurgia Geral</asp:ListItem>
                                            <asp:ListItem>Clínica Médica</asp:ListItem>
                                            <asp:ListItem>COVID</asp:ListItem>
                                            <asp:ListItem>Neurocirurgia</asp:ListItem>
                                            <asp:ListItem>Pediatria</asp:ListItem>
                                            <asp:ListItem>Traumatologia</asp:ListItem>
                                            <asp:ListItem>Obstetrícia</asp:ListItem>
                            </asp:DropDownList>
                           
                        </div>
                    </div>
                </div>
                <div class="x_content">
                </div>
            </div>
            <div class="container">
                <!-- Trigger the modal with a button -->
                <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">
                    Imprimir</button>
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
                            <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Ficha</legend>
                             <div class="row">
                                <div class="col-md-6 form-group">
                                    Impressoras:
                                    <asp:DropDownList ID="ddlImpressora" class="form-control" runat="server" >
                                           <asp:ListItem>PS - Guichê</asp:ListItem>
                                           <asp:ListItem>PSI - Guichê</asp:ListItem>
                                          
                                            <asp:ListItem>PS - CO 3 Andar</asp:ListItem>
                                            <%-- asp:ListItem>Centro Respiratório</asp:ListItem>--%>
                                            <asp:ListItem>Centro Obstétrico</asp:ListItem>
                                            <asp:ListItem>PS - Secretaria</asp:ListItem>
                                            <asp:ListItem>Lexmark MX710</asp:ListItem>
                                            <asp:ListItem>UTI_NEO_NATAL</asp:ListItem>
                                         
                                          
                                            
                                            <%--<asp:ListItem>Informatica</asp:ListItem>--%>
                                           
                                    </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3 form-group">
                                        Cópias:
                                        <asp:DropDownList ID="ddlVias" class="form-control " runat="server">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                   
                                    <div class="col-md-3 form-group">
                                     Etiquetas:
                                                <asp:DropDownList ID="ddlQtdEtiquetas" class="form-control" runat="server">
                                                    <asp:ListItem Selected>0</asp:ListItem>
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                </asp:DropDownList>
                                        </div>
                                    
                                </div>
                            </fieldset>
                                
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-md-4 col-sm-4 col-xs-8 ">
                                            <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary gravar"
                                                OnClick="btnGravar_Click" data-toggle="modal" data-target="#modalAguarde" />
                                        </div>
                                        
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="modalAguarde" tabindex="-1" role="dialog" aria-hidden="true"
                data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">
                                Aguarde a Impressão da Ficha</h5>
                        </div>
                        <div class="modal-body" align="center">
                            <h3>
                                <asp:Label ID="lbUserImprimir" runat="server" Text=""></asp:Label></h3>
                            <h2>
                                Aguarde a Impressão da Ficha</h2>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/imprimante-07.gif" alt="gif image"
                                Width="100px" Height="100px" />
                        </div>
                    </div>
                </div>
            </div>

    <script type="text/javascript">
        window.addEventListener('keydown', function(e) {
            var code = e.which || e.keyCode;
            if (code == 116 || code == 13) e.preventDefault();
            else return true;
        });
        
    </script>

</asp:Content>
