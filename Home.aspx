<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" Title="Oncologia - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="refresh" content="1000"></meta>

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <style type="text/css">
        @font-face
        {
            font-family: 'BebasNeueRegular';
             src: url('../build/relogio/BebasNeue-Regular.ttf');
           /* src: url('../build/relogio/BebasNeue-webfont.eot');
            src: url('../build/relogio/BebasNeue-webfont.eot?#iefix') format('embedded-opentype'), url('../build/relogio/BebasNeue-webfont.woff') format('woff'), url('../build/relogio/BebasNeue-webfont.ttf') format('truetype'), url('BebasNeue-webfont.svg#BebasNeueRegular') format('svg');*/
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
        .centralizar
        {
            margin: 0 auto;
            width: 20%; /* Altere para o valor da largura desejada. */
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function() {

            $("input").attr("autocomplete", "off");
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
    <div style="text-align: center;">
        <img alt="HSPM" src="imagens/HSPM_LOGO.jpg" />
    
    </div>
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
    <div class="centralizar">
        <div class="col-md-3 col-xs-12 widget widget_tally_box">
            <div class="x_panel fixed_height_390">
                <div style="text-align: center;">
                    <h2>
                        Bem Vindo</h2>
                    <div class="profile_pic" style="position: relative; top: 50%; left: 50%; margin-left: -50px;">
                        <img src="imagens/user.png" alt="..." class="img-circle profile_img" style="border-radius: 50%;"
                            alt="Avatar" title="Avatar" />
                    </div>
                </div>
                <div class="x_content" style="text-align: center;">
                    <h3 class="name">
                        <asp:LoginName ID="LoginName1" runat="server" /> </h3>
                    
                        <div class="divider"></div>
                        <p>
                            Comece utilizar o sistema escolhendo uma das opções no menu lateral</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
