<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="relogio.aspx.cs" Inherits="Atendimento_relogio" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            padding: 30px;
            color: #fff;
            background: #2A3F54;
        }
        #Date
        {
            font-family: 'BebasNeueRegular' , Arial, Helvetica, sans-serif;
            font-size: 30px;
            text-align: center;
            text-shadow: 0 0 5px #00c6ff ;
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
            text-shadow: 0 0 5px #00c6ff;
        }
        #point
        {
            position: relative;
            -moz-animation: mymove 1s ease infinite;
            -webkit-animation: mymove 1s ease infinite;
            padding-left: 10px;
            padding-right: 10px;
        }
        @-webkit-keyframes@-webkit-keyframesmymove{0%{opacity:1.0;text-shadow:0020px#00c6ff;}50%{opacity:0;text-shadow:none;}100%{opacity:1.0;text-shadow:0020px#00c6ff;}@-moz-keyframesmymove{0%{opacity:1.0;text-shadow:0020px#00c6ff;}50%{opacity:0;text-shadow:none;}100%{opacity:1.0;text-shadow:0020px#00c6ff;}</style>

    <script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js") %>'
        type="text/javascript"></script>

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
        }); 
    </script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="container">
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
    </div>
</asp:Content>
