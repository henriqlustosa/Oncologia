<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="AberturaFicha.aspx.cs" Inherits="Atendimento_AberturaFicha"
    Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <!-- Bootstrap -->

    <script src='<%= ResolveUrl("~/vendors/bootstrap/dist/js/bootstrap431.js") %>' type="text/javascript"></script>

    <!-- iCheck -->

    <script src='<%= ResolveUrl("~/vendors/iCheck/icheck.min.js") %>' type="text/javascript"></script>

    <!-- iCheck -->
    <link href="../vendors/iCheck/skins/line/blue.css" rel="stylesheet" />
    <style type="text/css">
        @font-face
        {
            font-family: 'BebasNeueRegular';
            src: url('../build/relogio/BebasNeue-webfont.eot');
            src: url('../build/relogio/BebasNeue-webfont.eot?#iefix') format('embedded-opentype'), url('../build/relogio/BebasNeue-webfont.woff') format('woff'), url('../build/relogio/BebasNeue-webfont.ttf') format('truetype'), url('BebasNeue-webfont.svg#BebasNeueRegular') format('svg');
            font-weight: normal;
            font-style: normal;
        }
        .clock
        {
            width: 100%;
            margin: 0 auto;
            padding: 10px;
            color: #2A3F54;
        }
        #Date
        {
            font-family: 'BebasNeueRegular' , Arial, Helvetica, sans-serif;
            font-size: 30px;
            text-align: center;
            text-shadow: 0 0 1px #2A3F54;
        }
        .relogio
        {
            width: 500px;
            margin: 0 auto;
            padding: 0px;
            list-style: none;
            text-align: center;
        }
        .relogio li
        {
            display: inline;
            font-size: 30px;
            text-align: center;
            font-family: 'BebasNeueRegular' , Arial, Helvetica, sans-serif;
            text-shadow: 0 0 1px #2A3F54;
        }
        #point
        {
            position: relative;
            -moz-animation: mymove 1s ease infinite;
            -webkit-animation: mymove 1s ease infinite;
            padding-left: 10px;
            padding-right: 10px;
        }
        @-webkit-keyframes@-webkit-keyframes@-webkit-keyframes@-webkit-keyframesmymove{0%{opacity:1.0;text-shadow:0020px#00c6ff;}50%{opacity:0;text-shadow:none;}100%{opacity:1.0;text-shadow:0020px#00c6ff;}@-moz-keyframesmymove{0%{opacity:1.0;text-shadow:0020px#00c6ff;}50%{opacity:0;text-shadow:none;}100%{opacity:1.0;text-shadow:0020px#00c6ff;}</style>

    <script type="text/javascript">
        $(document).ready(function() {
        $.noConflict();
      
            // Create two variable with the names of the months and days in an array
            var monthNames = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"];
            var dayNames = ["Domingo", "Segunda-feira", "Terça-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "Sábado"]

            // Create a newDate() object
            var newDate = new Date();
            // Extract the current date from Date object
            newDate.setDate(newDate.getDate());
            // Output the day, date, month and year    
            $('#Date').html(dayNames[newDate.getDay()] + " " + newDate.getDate() + ' ' + monthNames[newDate.getMonth()] + ' ' + newDate.getFullYear());

            setInterval(function() {
                // Create a newDate() object and extract the seconds of the current time on the visitor's
                var seconds = new Date().getSeconds();
                // Add a leading zero to seconds value
                $("#sec").html((seconds < 10 ? "0" : "") + seconds);
            }, 1000);

            setInterval(function() {
                // Create a newDate() object and extract the minutes of the current time on the visitor's
                var minutes = new Date().getMinutes();
                // Add a leading zero to the minutes value
                $("#min").html((minutes < 10 ? "0" : "") + minutes);
            }, 1000);

            setInterval(function() {
                // Create a newDate() object and extract the hours of the current time on the visitor's
                var hours = new Date().getHours();
                // Add a leading zero to the hours value
                $("#hours").html((hours < 10 ? "0" : "") + hours);
            }, 1000);

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

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
 
    <div class="clock">
        <div id="Date">
        </div>
        <ul class="relogio">
            <li id="hours"></li>
            <li id="point">:</li>
            <li id="min"></li>
            <li id="point">:</li>
            <li id="sec"></li>
        </ul>
    </div>
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Boletim de Emergência<small><i>- Informações do Paciente</i></small></h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        RH/Prontuário</label>
                    <asp:TextBox ID="txbProntuario" runat="server" class="form-control numeric"></asp:TextBox>
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
                    <asp:RadioButtonList ID="rbTipoPaciente" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem Text="Munícipe" Value="M" Selected></asp:ListItem>
                        <asp:ListItem Text="Funcionário" Value="F"></asp:ListItem>
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
                    <asp:TextBox ID="txbNascimento" runat="server" class="form-control nasc" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
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
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        CEP</label>
                    <asp:TextBox ID="txbCEP" MaxLength="10" runat="server" class="form-control"></asp:TextBox>
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
                        <asp:ListItem Text="Espontânea"></asp:ListItem>
                        <asp:ListItem Text="Bombeiro"></asp:ListItem>
                        <asp:ListItem Text="Polícia Militar"></asp:ListItem>
                        <asp:ListItem Text="GCM"></asp:ListItem>
                        <asp:ListItem Text="Metrô"></asp:ListItem>
                        <asp:ListItem Text="AMA - Sé"></asp:ListItem>
                        <asp:ListItem Text="SAMU"></asp:ListItem>
                        <asp:ListItem Text="Ambulância Particular"></asp:ListItem>
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
                    <asp:DropDownList ID="ddlSetor" runat="server" class="form-control" AutoPostBack="true"
                        DataSourceID="SqlDataSource3" DataTextField="descricao_setor" DataValueField="descricao_setor">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:psConnectionString %>"
                        SelectCommand="SELECT [cod_setor], [descricao_setor] FROM [setor] WHERE ([ativo_setor] = 1) ORDER BY descricao_setor asc">
                    </asp:SqlDataSource>
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
                                <div>
                                    Impressoras:
                                    <asp:DropDownList ID="ddlImpressora" class="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary gravar"
                                        OnClick="btnGravar_Click" data-toggle="modal" data-target="#modalAguarde" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    </div>
    
   <div class="modal fade" id="modalAguarde" tabindex="-1" role="dialog" aria-hidden="true" data-keyboard="false" data-backdrop="static">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Aguarde a Impressão da Ficha</h5>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        <div class="modal-body" align="center">
           <h3><asp:Label ID="lbUserImprimir" runat="server" Text=""></asp:Label></h3>
          <h2>Aguarde a Impressão da Ficha</h2>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/imprimante-07.gif" alt="gif image" Width="100px" Height="100px" />
        </div>
      </div>
    </div>
  </div>
</asp:Content>
