﻿using Microsoft.Reporting.WebForms;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web;


/// <summary>
/// Summary description for ImpressaoPrescricao
/// </summary>
public class ImpressaoPrescricao
{
    public ImpressaoPrescricao()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string nome_impressora { get; set; }
    public static void imprimirFicha(int _cod_relatorio_prescricao, string _nome_impressora)
    {
        nome_impressora = _nome_impressora;
        // Imprimir o BE
        if (_cod_relatorio_prescricao > 0)
        {
            using (var relatorio = new LocalReport())
            {
                relatorio.ReportPath = "Report/Report.rdlc";

                RelatorioPrescricaoloDAO relatorioPrescricaoDAO = new RelatorioPrescricaoloDAO();

                List<RelatorioPrescricao> listaRelatorioPrescricao = new List<RelatorioPrescricao>();

                RelatorioPrescricao relatorioPrescricao = new RelatorioPrescricao();




       
                List<RelatorioProtocoloDosagem> protocolos = new List<RelatorioProtocoloDosagem>();

                List<RelatorioPreQuimio> preQuimios = new List<RelatorioPreQuimio>();

                List<CID_Prescricao> cids = new List<CID_Prescricao>();
                List<Agenda> agendas = new List<Agenda>();





                //Ficha sc = new Ficha();
                relatorioPrescricao = relatorioPrescricaoDAO.GetPrescricao(_cod_relatorio_prescricao);
                listaRelatorioPrescricao.Add(relatorioPrescricao);


                protocolos = RelatorioProtocoloDosagemDAO.BuscarProtocolosPorCodPrescricao(relatorioPrescricao.cod_Prescricao);

                preQuimios = RelatorioPreQuimioDAO.BuscarPrequimiosPorCodPrescricao(relatorioPrescricao.cod_prequimio);

                cids = CID_10_DAO.BuscarCIDsPorCodPrescricao(relatorioPrescricao.cod_Prescricao);

                agendas = AgendaDAO.BuscarAgendasPorCodPrescricao(relatorioPrescricao.cod_Prescricao);






                IEnumerable<RelatorioPrescricao> ie;
                IEnumerable<RelatorioProtocoloDosagem> ie2;
                IEnumerable<RelatorioPreQuimio> ie3;
                IEnumerable<CID_Prescricao> ie4;
               

                ie = listaRelatorioPrescricao;
                ie2 = protocolos;
                ie3 = preQuimios;
                ie4 = cids;
                

                ReportDataSource datasource = new ReportDataSource("DataSet1", ie);
                ReportDataSource datasource2 = new ReportDataSource("DataSet2", ie2);
                ReportDataSource datasource3 = new ReportDataSource("DataSet3", ie3);
                ReportDataSource datasource4 = new ReportDataSource("DataSet4", ie4);



                relatorio.DataSources.Add(datasource);
                relatorio.DataSources.Add(datasource2);
                relatorio.DataSources.Add(datasource3);
                relatorio.DataSources.Add(datasource4);
               
                foreach (Agenda agenda in agendas)
                {
                    List<Agenda> relatorioAgenda = new List<Agenda>();
                    relatorioAgenda.Add(agenda);
                    IEnumerable<Agenda> ie5;
                    ie5 = relatorioAgenda;
                    ReportDataSource datasource5 = new ReportDataSource("DataSet5", ie5);
                   
                    relatorio.DataSources.Add(datasource5);
                   
                    Exportar(relatorio);
                    Imprimir(relatorio);
                    relatorio.DataSources.Remove(datasource5);
                }
             
            }
        }
    }
        private static void Exportar(Microsoft.Reporting.WebForms.LocalReport relatorio)
        {
            Microsoft.Reporting.WebForms.Warning[] warnings;
            LimparStreams();
            relatorio.Render("image", CriarDeviceInfo(relatorio), CreateStreamCallback, out warnings);
        }
         private static List<System.IO.Stream> _streams = new List<System.IO.Stream>();

    public static System.IO.Stream CreateStreamCallback(string name, string extension, Encoding encoding, string mimeType, bool willSeek)
    {
        var stream = new System.IO.MemoryStream();
        _streams.Add(stream);
        return stream;
    }

    private static void LimparStreams()
    {
        foreach (var stream in _streams)
        {
            stream.Dispose();
        }
        _streams.Clear();
    }

    private static string CriarDeviceInfo(Microsoft.Reporting.WebForms.LocalReport relatorio)
    {
        var pageSettings = relatorio.GetDefaultPageSettings();
        return string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
                @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>{0}in</PageWidth>
                <PageHeight>{1}in</PageHeight>
                <MarginTop>{2}in</MarginTop>
                <MarginLeft>{3}in</MarginLeft>
                <MarginRight>{4}in</MarginRight>
                <MarginBottom>{5}in</MarginBottom>
            </DeviceInfo>",
            pageSettings.PaperSize.Width / 100m, pageSettings.PaperSize.Height / 100m, pageSettings.Margins.Top / 100m, pageSettings.Margins.Left / 100m, pageSettings.Margins.Right / 100m, pageSettings.Margins.Bottom / 100m);
    }


    private static void Imprimir(Microsoft.Reporting.WebForms.LocalReport relatorio)
    {
        using (var pd = new System.Drawing.Printing.PrintDocument())
        {
            //configurar impressora
            //pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrinterName = nome_impressora;

            var pageSettings = new System.Drawing.Printing.PageSettings();
            var pageSettingsRelatorio = relatorio.GetDefaultPageSettings();
            pageSettings.PaperSize = pageSettingsRelatorio.PaperSize;
            pageSettings.Margins = pageSettingsRelatorio.Margins;
            pd.DefaultPageSettings = pageSettings;

            pd.PrintPage += Pd_PrintPage;
            _streamAtual = 0;

            pd.Print();
        }
    }

    private static int _streamAtual;
    private static void Pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        var stream = _streams[_streamAtual];
        stream.Seek(0, System.IO.SeekOrigin.Begin);

        using (var metadata = new System.Drawing.Imaging.Metafile(stream))
        {
            e.Graphics.DrawImage(metadata, e.PageBounds);
        }

        _streamAtual++;
        e.HasMorePages = _streamAtual < _streams.Count;
    }

}

