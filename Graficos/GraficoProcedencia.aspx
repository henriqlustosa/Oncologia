<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GraficoProcedencia.aspx.cs" Inherits="Graficos_GraficoProcedencia"
    Title="Pronto Socorro - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js") %>'
        type="text/javascript"></script>

    <script src='<%= ResolveUrl("https://cdn.jsdelivr.net/npm/chart.js@2.8.0") %>' type="text/javascript"></script>

    <style type="text/css">
        .colorir td
        {
            background-color: rgb(168,227,215);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="row">
        <label class="control-label">
            <h6>
                Informe mês e ano:</h6>
        </label>
        <div class="col-md-4 col-sm-12 col-xs-12">
            <div class="col-md-4">
                <asp:TextBox ID="txbData" runat="server" class="form-control" data-inputmask="'mask': '99/9999'"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredValidator" runat="server" ControlToValidate="txbData"
                    ForeColor="red" Display="Static" ErrorMessage="Required" /><br />
            </div>
            <div class="col-md-4">
                <input id="Button1" runat="server" type="button" onclick="gerarGrafico()" value="Gráfico"
                    class="btn btn-success" />
            </div>
            <div class="col-md-4">
                <input id="Button2" runat="server" type="button" value="Limpar" onclick="reloadPage()"
                    class="btn btn-primary" />
            </div>
            <!--
                 <div class="col-md-4">
                <button class="btn btn-default" onclick="window.print();"><i class="fa fa-print"></i> Print</button>
                </div>
             -->
        </div>
    </div>
    <div id="graficos">
        <!-- Tabela Total de Procedência Espontânea-->
        <div class="col-md-12">
            <div class="x_panel tile ">
                <div class="x_title">
                    <h2>
                        Total de Atendimentos</h2>
                    <div class="clearfix">
                    </div>
                    <table class="table table-sm table-striped table-bordered">
                        <thead style="background-color: #5D7B9D; color: #FFFFFF;">
                            <tr>
                                <th>
                                    #
                                </th>
                                <th>
                                    1
                                </th>
                                <th>
                                    2
                                </th>
                                <th>
                                    3
                                </th>
                                <th>
                                    4
                                </th>
                                <th>
                                    5
                                </th>
                                <th>
                                    6
                                </th>
                                <th>
                                    7
                                </th>
                                <th>
                                    8
                                </th>
                                <th>
                                    9
                                </th>
                                <th>
                                    10
                                </th>
                                <th>
                                    11
                                </th>
                                <th>
                                    12
                                </th>
                                <th>
                                    13
                                </th>
                                <th>
                                    14
                                </th>
                                <th>
                                    15
                                </th>
                                <th>
                                    16
                                </th>
                                <th>
                                    17
                                </th>
                                <th>
                                    18
                                </th>
                                <th>
                                    19
                                </th>
                                <th>
                                    20
                                </th>
                                <th>
                                    21
                                </th>
                                <th>
                                    22
                                </th>
                                <th>
                                    23
                                </th>
                                <th>
                                    24
                                </th>
                                <th>
                                    25
                                </th>
                                <th>
                                    26
                                </th>
                                <th>
                                    27
                                </th>
                                <th>
                                    28
                                </th>
                                <th>
                                    29
                                </th>
                                <th>
                                    30
                                </th>
                                <th>
                                    31
                                </th>
                                <th>
                                    Total
                                </th>
                            </tr>
                        </thead>
                        <tbody id="Tbody1" style="color: #000000">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- FIM Tabela Total de Atendimentos -->
        <!-- Tabela Total de Atendimentos -->
        <div class="col-md-12">
            <div class="x_panel tile ">
                <div class="x_title">
                    <h2>
                        Total de Atendimentos de Procedência Espontânea</h2>
                    <div class="clearfix">
                    </div>
                    <table class="table table-sm table-striped table-bordered">
                        <thead style="background-color: #5D7B9D; color: #FFFFFF;">
                            <tr>
                                <th>
                                    #
                                </th>
                                <th>
                                    1
                                </th>
                                <th>
                                    2
                                </th>
                                <th>
                                    3
                                </th>
                                <th>
                                    4
                                </th>
                                <th>
                                    5
                                </th>
                                <th>
                                    6
                                </th>
                                <th>
                                    7
                                </th>
                                <th>
                                    8
                                </th>
                                <th>
                                    9
                                </th>
                                <th>
                                    10
                                </th>
                                <th>
                                    11
                                </th>
                                <th>
                                    12
                                </th>
                                <th>
                                    13
                                </th>
                                <th>
                                    14
                                </th>
                                <th>
                                    15
                                </th>
                                <th>
                                    16
                                </th>
                                <th>
                                    17
                                </th>
                                <th>
                                    18
                                </th>
                                <th>
                                    19
                                </th>
                                <th>
                                    20
                                </th>
                                <th>
                                    21
                                </th>
                                <th>
                                    22
                                </th>
                                <th>
                                    23
                                </th>
                                <th>
                                    24
                                </th>
                                <th>
                                    25
                                </th>
                                <th>
                                    26
                                </th>
                                <th>
                                    27
                                </th>
                                <th>
                                    28
                                </th>
                                <th>
                                    29
                                </th>
                                <th>
                                    30
                                </th>
                                <th>
                                    31
                                </th>
                                <th>
                                    Total
                                </th>
                            </tr>
                        </thead>
                        <tbody id="Tbody2" style="color: #000000">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- FIM Tabela Total de Atendimentos -->
        <!-- Tabela Resgate-->
        <div class="col-md-12">
            <div class="x_panel tile ">
                <div class="x_title">
                    <h2>
                        Total de Atendimentos de Procedência Resgate</h2>
                    <div class="clearfix">
                    </div>
                    <table class="table table-sm table-striped table-bordered">
                        <thead style="background-color: #5D7B9D; color: #FFFFFF;">
                            <tr>
                                <th>
                                    #
                                </th>
                                <th>
                                    1
                                </th>
                                <th>
                                    2
                                </th>
                                <th>
                                    3
                                </th>
                                <th>
                                    4
                                </th>
                                <th>
                                    5
                                </th>
                                <th>
                                    6
                                </th>
                                <th>
                                    7
                                </th>
                                <th>
                                    8
                                </th>
                                <th>
                                    9
                                </th>
                                <th>
                                    10
                                </th>
                                <th>
                                    11
                                </th>
                                <th>
                                    12
                                </th>
                                <th>
                                    13
                                </th>
                                <th>
                                    14
                                </th>
                                <th>
                                    15
                                </th>
                                <th>
                                    16
                                </th>
                                <th>
                                    17
                                </th>
                                <th>
                                    18
                                </th>
                                <th>
                                    19
                                </th>
                                <th>
                                    20
                                </th>
                                <th>
                                    21
                                </th>
                                <th>
                                    22
                                </th>
                                <th>
                                    23
                                </th>
                                <th>
                                    24
                                </th>
                                <th>
                                    25
                                </th>
                                <th>
                                    26
                                </th>
                                <th>
                                    27
                                </th>
                                <th>
                                    28
                                </th>
                                <th>
                                    29
                                </th>
                                <th>
                                    30
                                </th>
                                <th>
                                    31
                                </th>
                                <th>
                                    Total
                                </th>
                            </tr>
                        </thead>
                        <tbody id="tdata" style="color: #000000">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- FIM Tabela Resgate -->
        <!-- Tabela Porcentagem -->
        <div class="col-md-12">
            <div class="x_panel tile ">
                <div class="x_title">
                    <h2>
                        Quantitativo por Procedência</h2>
                    <div class="clearfix">
                        <table class="table">
                            <thead class="thead-dark">
                                <tr>
                                    <th>
                                        Descricao
                                    </th>
                                    <th>
                                        Quantidade
                                    </th>
                                    <th>
                                        Porcentagem
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="Tbody3">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!--FIM Tabela Porcentagem -->
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12">
                <!-- Gráfico Pizza -->
                <div class="x_content">
                    <canvas id="myChartPie" style="height: 56px; width: 150px"></canvas>
                </div>
                <!-- FIM Gráfico Pizza -->
            </div>
            <div class="col-md-6 col-sm-12 col-xs-12">
                <!-- Gráfico Pizza -->
                <div class="x_content">
                    <canvas id="myChartBar" style="height: 56px; width: 150px"></canvas>
                </div>
                <!-- FIM Gráfico Pizza -->
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#graficos").hide();
        });

        function gerarGrafico() {
            var dia = document.getElementById('<%=txbData.ClientID %>');
            $("#graficos").show();
            dadosMesResgate(dia.value);
            dadosMesEspontaneo(dia.value);
            dadosMesTotal(dia.value);
            dadosMesProcedencia(dia.value);
            updateChartPie(dia.value);
            updateChartBar(dia.value);
        }

        var ctx = document.getElementById('myChartBar').getContext('2d');
        var myChartBar = new Chart(ctx, {
            type: 'bar',
            data: []
        });

        function updateChartBar(data) {
            $("#myChartPie2").show();
            myChartBar.data = JSON.parse(GetDataBar(JSON.stringify(data)));
            myChartBar.update();
        };


        function GetDataBar(data) {
            var d = data;

            var result = null;
            $.ajax({
                async: false
                , url: '<%= ResolveUrl("~/Relatorios/WebService.asmx/QuantidadeBeProcedenciaGrafico") %>'
                , data: '{mesAno : ' + d + '}'
                , type: 'POST'
                , contentType: 'application/json; charset=utf-8'
                , dataType: 'json'
                , success: function(data) {
                    result = data.d;
                }
                , error: function(xhr, er) {
                    $("#lbMsg").html('<p> Erro ' + xhr.staus + ' - ' + xhr.statusText + ' - <br />Tipo de erro:  ' + er + '</p>');
                }
            });
            return result;
        }


        var ctx = document.getElementById('myChartPie').getContext('2d');
        var myChartPie = new Chart(ctx, {
            type: 'pie',
            data: []
        });

        function updateChartPie(data) {
            $("#myChartPie").show();
            myChartPie.data = JSON.parse(GetDataPie(JSON.stringify(data)));
            myChartPie.update();
        };

        function GetDataPie(data) {
            var d = data;

            var result = null;
            $.ajax({
                async: false
                , url: '<%= ResolveUrl("~/Relatorios/WebService.asmx/PercentBeProcedenciaGrafico") %>'
                , data: '{mesAno : ' + d + '}'
                , options: {
                    tooltips: {
                        callbacks: {
                            label: function(tooltipItem, data) {
                                return Number(tooltipItem.yLabel).toFixed(2);
                            }
                        }
                    }
                    , legend: {
                        display: true
                    }
                    , scales: {
                        yAxes: {
                            ticks: {
                                beginAtZero: true, stepSize: 3.5
                            }
                        }
                    }
                }
                , type: 'POST'
                , contentType: 'application/json; charset=utf-8'
                , dataType: 'json'
                , success: function(data) {
                    result = data.d;
                }
                , error: function(xhr, er) {
                    $("#lbMsg").html('<p> Erro ' + xhr.staus + ' - ' + xhr.statusText + ' - <br />Tipo de erro:  ' + er + '</p>');
                }
            });
            return result;
        }


        function dadosMesResgate(data) {
            var d = JSON.stringify(data);
            $.ajax({
                async: false
                                , url: '<%= ResolveUrl("~/Relatorios/WebService.asmx/TotalAtendimentosResgate") %>'
                                , data: '{mesAno : ' + d + '}'
                                , type: 'POST'
                                , contentType: 'application/json; charset=utf-8'
                                , dataType: 'json'
                                , success: function(data) {
                                    var data = JSON.parse(data.d);
                                    data.forEach(function(dt) {
                                        $("#tdata").append("<tr>" +
                                        "<td>" + dt.procedencia + "</td>" +
                                        "<td>" + dt.dia1 + "</td>" +
                                        "<td>" + dt.dia2 + "</td>" +
                                        "<td>" + dt.dia3 + "</td>" +
                                        "<td>" + dt.dia4 + "</td>" +
                                        "<td>" + dt.dia5 + "</td>" +
                                        "<td>" + dt.dia6 + "</td>" +
                                        "<td>" + dt.dia7 + "</td>" +
                                        "<td>" + dt.dia8 + "</td>" +
                                        "<td>" + dt.dia9 + "</td>" +
                                        "<td>" + dt.dia10 + "</td>" +
                                        "<td>" + dt.dia11 + "</td>" +
                                        "<td>" + dt.dia12 + "</td>" +
                                        "<td>" + dt.dia13 + "</td>" +
                                        "<td>" + dt.dia14 + "</td>" +
                                        "<td>" + dt.dia15 + "</td>" +
                                        "<td>" + dt.dia16 + "</td>" +
                                        "<td>" + dt.dia17 + "</td>" +
                                        "<td>" + dt.dia18 + "</td>" +
                                        "<td>" + dt.dia19 + "</td>" +
                                        "<td>" + dt.dia20 + "</td>" +
                                        "<td>" + dt.dia21 + "</td>" +
                                        "<td>" + dt.dia22 + "</td>" +
                                        "<td>" + dt.dia23 + "</td>" +
                                        "<td>" + dt.dia24 + "</td>" +
                                        "<td>" + dt.dia25 + "</td>" +
                                        "<td>" + dt.dia26 + "</td>" +
                                        "<td>" + dt.dia27 + "</td>" +
                                        "<td>" + dt.dia28 + "</td>" +
                                        "<td>" + dt.dia29 + "</td>" +
                                        "<td>" + dt.dia30 + "</td>" +
                                        "<td>" + dt.dia31 + "</td>" +
                                        "<td>" + dt.total + "</td>"
                                        + "</tr>"
                                        );
                                    });
                                }
                                , error: function(xhr, er) {
                                    $("#lbMsg").html('<p> Erro ' + xhr.staus + ' - ' + xhr.statusText + ' - <br />Tipo de erro:  ' + er + '</p>');
                                }
            });

            colore_tabela();
        }

        function dadosMesEspontaneo(data) {
            var d = JSON.stringify(data);
            $.ajax({
                async: false
                                , url: '<%= ResolveUrl("~/Relatorios/WebService.asmx/TotalAtendimentosEspontaneo") %>'
                                , data: '{mesAno : ' + d + '}'
                                , type: 'POST'
                                , contentType: 'application/json; charset=utf-8'
                                , dataType: 'json'
                                , success: function(data) {
                                    var data = JSON.parse(data.d);
                                    data.forEach(function(dt) {
                                        $("#Tbody2").append("<tr>" +
                                        "<td>" + dt.procedencia + "</td>" +
                                        "<td>" + dt.dia1 + "</td>" +
                                        "<td>" + dt.dia2 + "</td>" +
                                        "<td>" + dt.dia3 + "</td>" +
                                        "<td>" + dt.dia4 + "</td>" +
                                        "<td>" + dt.dia5 + "</td>" +
                                        "<td>" + dt.dia6 + "</td>" +
                                        "<td>" + dt.dia7 + "</td>" +
                                        "<td>" + dt.dia8 + "</td>" +
                                        "<td>" + dt.dia9 + "</td>" +
                                        "<td>" + dt.dia10 + "</td>" +
                                        "<td>" + dt.dia11 + "</td>" +
                                        "<td>" + dt.dia12 + "</td>" +
                                        "<td>" + dt.dia13 + "</td>" +
                                        "<td>" + dt.dia14 + "</td>" +
                                        "<td>" + dt.dia15 + "</td>" +
                                        "<td>" + dt.dia16 + "</td>" +
                                        "<td>" + dt.dia17 + "</td>" +
                                        "<td>" + dt.dia18 + "</td>" +
                                        "<td>" + dt.dia19 + "</td>" +
                                        "<td>" + dt.dia20 + "</td>" +
                                        "<td>" + dt.dia21 + "</td>" +
                                        "<td>" + dt.dia22 + "</td>" +
                                        "<td>" + dt.dia23 + "</td>" +
                                        "<td>" + dt.dia24 + "</td>" +
                                        "<td>" + dt.dia25 + "</td>" +
                                        "<td>" + dt.dia26 + "</td>" +
                                        "<td>" + dt.dia27 + "</td>" +
                                        "<td>" + dt.dia28 + "</td>" +
                                        "<td>" + dt.dia29 + "</td>" +
                                        "<td>" + dt.dia30 + "</td>" +
                                        "<td>" + dt.dia31 + "</td>" +
                                        "<td>" + dt.total + "</td>"
                                        + "</tr>"
                                        );
                                    });

                                }
                                , error: function(xhr, er) {
                                    $("#lbMsg").html('<p> Erro ' + xhr.staus + ' - ' + xhr.statusText + ' - <br />Tipo de erro:  ' + er + '</p>');
                                }
            });

            colore_tabela();
        }

        function dadosMesTotal(data) {
            var d = JSON.stringify(data);
            $.ajax({
                async: false
                                , url: '<%= ResolveUrl("~/Relatorios/WebService.asmx/TotalAtendimentos") %>'
                                , data: '{mesAno : ' + d + '}'
                                , type: 'POST'
                                , contentType: 'application/json; charset=utf-8'
                                , dataType: 'json'
                                , success: function(data) {
                                    var data = JSON.parse(data.d);
                                    data.forEach(function(dt) {
                                        $("#Tbody1").append("<tr>" +
                                        "<td>" + dt.procedencia + "</td>" +
                                        "<td>" + dt.dia1 + "</td>" +
                                        "<td>" + dt.dia2 + "</td>" +
                                        "<td>" + dt.dia3 + "</td>" +
                                        "<td>" + dt.dia4 + "</td>" +
                                        "<td>" + dt.dia5 + "</td>" +
                                        "<td>" + dt.dia6 + "</td>" +
                                        "<td>" + dt.dia7 + "</td>" +
                                        "<td>" + dt.dia8 + "</td>" +
                                        "<td>" + dt.dia9 + "</td>" +
                                        "<td>" + dt.dia10 + "</td>" +
                                        "<td>" + dt.dia11 + "</td>" +
                                        "<td>" + dt.dia12 + "</td>" +
                                        "<td>" + dt.dia13 + "</td>" +
                                        "<td>" + dt.dia14 + "</td>" +
                                        "<td>" + dt.dia15 + "</td>" +
                                        "<td>" + dt.dia16 + "</td>" +
                                        "<td>" + dt.dia17 + "</td>" +
                                        "<td>" + dt.dia18 + "</td>" +
                                        "<td>" + dt.dia19 + "</td>" +
                                        "<td>" + dt.dia20 + "</td>" +
                                        "<td>" + dt.dia21 + "</td>" +
                                        "<td>" + dt.dia22 + "</td>" +
                                        "<td>" + dt.dia23 + "</td>" +
                                        "<td>" + dt.dia24 + "</td>" +
                                        "<td>" + dt.dia25 + "</td>" +
                                        "<td>" + dt.dia26 + "</td>" +
                                        "<td>" + dt.dia27 + "</td>" +
                                        "<td>" + dt.dia28 + "</td>" +
                                        "<td>" + dt.dia29 + "</td>" +
                                        "<td>" + dt.dia30 + "</td>" +
                                        "<td>" + dt.dia31 + "</td>" +
                                        "<td>" + dt.total + "</td>"
                                        + "</tr>"
                                        );


                                    });

                                }
                                , error: function(xhr, er) {
                                    $("#lbMsg").html('<p> Erro ' + xhr.staus + ' - ' + xhr.statusText + ' - <br />Tipo de erro:  ' + er + '</p>');
                                }
            });
            colore_tabela();
        }


        function dadosMesProcedencia(data) {
            var d = JSON.stringify(data);
            $.ajax({
                async: false
                                , url: '<%= ResolveUrl("~/Relatorios/WebService.asmx/QuantidadeBeProcedencia") %>'
                                , data: '{mesAno : ' + d + '}'
                                , type: 'POST'
                                , contentType: 'application/json; charset=utf-8'
                                , dataType: 'json'
                                , success: function(data) {
                                    var data = JSON.parse(data.d);
                                    data.forEach(function(dt) {
                                        $("#Tbody3").append("<tr>" +
                                        "<td>" + dt.descricao + "</td>" +
                                        "<td class='valor-calculado'>" + dt.quantidade + "</td>" +
                                        "<td>" + dt.porcentagem + "</td>"
                                        + "</tr>"
                                        );

                                        var valorCalculado = 0;

                                        $(".valor-calculado").each(function() {
                                            valorCalculado += parseInt($(this).text());
                                        });
                                        $("#qtdtotal").text(valorCalculado);
                                    });

                                }
                                , error: function(xhr, er) {
                                    $("#lbMsg").html('<p> Erro ' + xhr.staus + ' - ' + xhr.statusText + ' - <br />Tipo de erro:  ' + er + '</p>');
                                }
            });
        }

        function colore_tabela() {
            $('#Tbody1').find('tr').each(function(indice) {

                switch ($(this).children().eq(0).text()) {
                    case 'Total':
                        $(this).prop('class', 'colorir');
                        break;
                };
            });

            $('#Tbody2').find('tr').each(function(indice) {

                switch ($(this).children().eq(0).text()) {
                    case 'Total':
                        $(this).prop('class', 'colorir');
                        break;
                };
            });

            $('#tdata').find('tr').each(function(indice) {

                switch ($(this).children().eq(0).text()) {
                    case 'Total':
                        $(this).prop('class', 'colorir');
                        break;
                };
            });
        }

        function reloadPage() {
            window.location.reload()
        }
        
    </script>

</asp:Content>
