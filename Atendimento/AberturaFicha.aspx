<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="AberturaFicha.aspx.cs" Inherits="Atendimento_AberturaFicha" Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js") %>'
        type="text/javascript"></script>
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
        @-webkit-keyframes mymove 
        {
            0% {opacity:1.0; text-shadow:0 0 20px #00c6ff;}
            50% {opacity:0; text-shadow:none; }
            100% {opacity:1.0; text-shadow:0 0 20px #00c6ff; }	
        }

        @-moz-keyframes mymove 
        {
            0% {opacity:1.0; text-shadow:0 0 20px #00c6ff;}
            50% {opacity:0; text-shadow:none; }
            100% {opacity:1.0; text-shadow:0 0 20px #00c6ff; }	
        }
       
       </style>


    <script type="text/javascript">
        $(document).ready(function() {
            // Create two variable with the names of the months and days in an array
            var monthNames = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"];
            var dayNames = ["Domungo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"]

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
        }); 
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
               <h2>Boletim de Emergência<small><i>- Informações do Paciente</i></small></h2>
               <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        RH/Prontuário</label>
                    <asp:TextBox ID="txbProntuario" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Documento</label>
                    <asp:TextBox ID="txbDocumento" runat="server" class="form-control"></asp:TextBox>
                </div>
                
                
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                <label>Tipo Paciente</label>
                    <asp:RadioButtonList ID="rbTipoPaciente" RepeatDirection="Horizontal" runat="server">
                        <asp:listitem text="Munícipe" Value="M" Selected ></asp:listitem>
                        <asp:listitem text="Funcionário" Value="F"></asp:listitem>
                    </asp:RadioButtonList>
                     
                </div>
            </div>
            <div class="row">
                <div class="col-md-5 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nome</label>
                    <asp:TextBox ID="txbNomePaciente" runat="server" class="form-control"></asp:TextBox>
                </div>
                
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Nascimento</label>
                    <asp:TextBox ID="txbNascimento" runat="server" class="form-control" required ></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        Idade</label>
                    <asp:TextBox ID="txbIdade" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Sexo</label>
                    <asp:DropDownList ID="ddlSexo" runat="server" DataSourceID="SqlDataSource1" autopostback = "true"
                        DataTextField="descricao_sexo" DataValueField="cod_sexo" class="form-control">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:psConnectionString %>" 
                        SelectCommand="SELECT [cod_sexo], [descricao_sexo] FROM [sexo]">
                    </asp:SqlDataSource>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Raça/Cor</label>
                    <asp:DropDownList ID="ddlRaca" runat="server" class="form-control" autopostback = "true" 
                        DataSourceID="SqlDataSource2" DataTextField="descricao_raca" 
                        DataValueField="cod_raca">
                    </asp:DropDownList>   
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:psConnectionString %>" 
                        SelectCommand="SELECT [cod_raca], [descricao_raca] FROM [raca]">
                    </asp:SqlDataSource>
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
                    <asp:TextBox ID="txbNumero" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        Complemento</label>
                    <asp:TextBox ID="txbComplemento" runat="server" class="form-control"></asp:TextBox>
                </div>
            
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Bairro</label>
                    <asp:TextBox ID="txbBairro" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                    <label>
                        Município</label>
                    <asp:TextBox ID="txbMunicipio" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        UF</label>
                    <asp:TextBox ID="txbUF" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        CEP</label>
                    <asp:TextBox ID="txbCEP" runat="server" class="form-control"></asp:TextBox>
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
                <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                    <label>
                        Telefone</label>
                    <asp:TextBox ID="txbTelefone" runat="server" class="form-control"></asp:TextBox>
                </div>
            
                <div class="col-md-3 col-sm-12 col-xs-12 form-group">
                    <label>
                        Procedência</label>
                    <asp:TextBox ID="txbProcedencia" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                    <label>
                        Queixa</label>
                    <asp:TextBox ID="txbQueixa" runat="server" class="form-control" TextMode="MultiLine"
                        Rows="4"></asp:TextBox>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 form-group">
                    <asp:checkboxlist runat="server" id="chkFormaChegada" RepeatDirection="Horizontal" >
                        <asp:listitem text="Caso Policial"></asp:listitem>
                        <asp:listitem text="Plano de Saúde"></asp:listitem>
                        <asp:listitem text="Trauma" ></asp:listitem>
                        <asp:listitem text="Acidente de Trabalho"></asp:listitem>
                        <asp:listitem text="Veio de Ambulância"></asp:listitem>
                    </asp:checkboxlist>
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
                    <asp:DropDownList ID="ddlSetor" runat="server" class="form-control" autopostback = "true"
                        DataSourceID="SqlDataSource3" DataTextField="descricao_setor" 
                        DataValueField="cod_setor">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:psConnectionString %>" 
                        SelectCommand="SELECT [cod_setor], [descricao_setor] FROM [setor]">
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
        <div class="x_content">
            <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" OnClick="btnGravar_Click" />
        </div>
    </div>
    
</asp:Content>
