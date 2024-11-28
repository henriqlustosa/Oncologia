using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Reporting.WebForms;

public class ImpressaoPrescricao
{
    public ImpressaoPrescricao()
    {
        // TODO: Add constructor logic here
    }

    public static string nome_impressora { get; set; }
    private static int _streamAtual;
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
                RelatorioPrescricao relatorioPrescricao = relatorioPrescricaoDAO.GetPrescricao(_cod_relatorio_prescricao);
                listaRelatorioPrescricao.Add(relatorioPrescricao);

                List<RelatorioProtocoloDosagem> protocolos = RelatorioProtocoloDosagemDAO.BuscarProtocolosPorCodPrescricao(relatorioPrescricao.cod_Prescricao);
                List<RelatorioPreQuimioDosagem> preQuimios = RelatorioPreQumioDosagemDAO.BuscarPrequimiosPorCodPrescricao(relatorioPrescricao.cod_Prescricao);
                List<CID_Prescricao> cids = CID_10_DAO.BuscarCIDsPorCodPrescricao(relatorioPrescricao.cod_Prescricao);
                List<ViasDeAcesso_Prescricao> listaViasDeAcesso = ViasDeAcessoDAO.BuscarViasDeAcessoPorCodPrescricao(relatorioPrescricao.cod_Prescricao);
                List<Agenda> agendas = AgendaDAO.BuscarAgendasPorCodPrescricao(relatorioPrescricao.cod_Prescricao);

                IEnumerable<RelatorioPrescricao> RelatorioPrescricao = listaRelatorioPrescricao;
                IEnumerable<RelatorioProtocoloDosagem> RelatorioProtocoloDosagem = protocolos;
                IEnumerable<RelatorioPreQuimioDosagem> RelatorioPreQuimioDosagem = preQuimios;
                IEnumerable<CID_Prescricao> RelatorioCID_Prescricao = cids;
                IEnumerable<ViasDeAcesso_Prescricao> RelatorioViasDeAcesso_Prescricao = listaViasDeAcesso;

                relatorio.DataSources.Add(new ReportDataSource("DataSet1", RelatorioPrescricao));
                relatorio.DataSources.Add(new ReportDataSource("DataSet2", RelatorioProtocoloDosagem));
                relatorio.DataSources.Add(new ReportDataSource("DataSet3", RelatorioPreQuimioDosagem));
                relatorio.DataSources.Add(new ReportDataSource("DataSet4", RelatorioCID_Prescricao));
                relatorio.DataSources.Add(new ReportDataSource("DataSet5", RelatorioViasDeAcesso_Prescricao));

                foreach (var agenda in agendas)
                {
                    List<Agenda> relatorioAgenda = new List<Agenda> { agenda };
                    relatorio.DataSources.Add(new ReportDataSource("DataSet6", relatorioAgenda));

                    Exportar(relatorio);
                    Imprimir(relatorio);
                    relatorio.DataSources.RemoveAt(relatorio.DataSources.Count - 1);
                }
            }
        }
    }

    private static void Exportar(LocalReport relatorio)
    {
        Warning[] warnings;
        LimparStreams();
        relatorio.Render("image", CriarDeviceInfo(relatorio), CreateStreamCallback, out warnings);
    }

    private static List<Stream> _streams = new List<Stream>();

    public static Stream CreateStreamCallback(string name, string extension, Encoding encoding, string mimeType, bool willSeek)
    {
        var stream = new MemoryStream();
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

    private static string CriarDeviceInfo(LocalReport relatorio)
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

    private static void Imprimir(LocalReport relatorio)
    {
        try
        {
            using (var pd = new PrintDocument())
            {
                if (!PrinterSettings.InstalledPrinters.Cast<string>().Any(printer => printer.Equals(nome_impressora, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new InvalidPrinterException(pd.PrinterSettings);
                }

                pd.PrinterSettings.PrinterName = nome_impressora;

                var pageSettings = new PageSettings();
                var pageSettingsRelatorio = relatorio.GetDefaultPageSettings();
                pageSettings.PaperSize = pageSettingsRelatorio.PaperSize;
                pageSettings.Margins = pageSettingsRelatorio.Margins;
                pd.DefaultPageSettings = pageSettings;

                pd.PrintPage += Pd_PrintPage;
                _streamAtual = 0;

                pd.Print();
            }
        }
        catch (Win32Exception ex)
        {
            // Log detailed error information
            Console.WriteLine("A Win32 error occurred:"+ ex.Message);
            Console.WriteLine("Error Code:" + ex.NativeErrorCode);
            Console.WriteLine("Stack Trace: "+ ex.StackTrace);
            Console.WriteLine("A Win32 error occurred:" + ex.Message);
            MessageBox.Show("A Win32 error occurred: "+ex.Message+"\nError Code: "+ex.NativeErrorCode, "Win32 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (InvalidPrinterException ex)
        {
            Console.WriteLine("Printer error:" + ex.Message);
            MessageBox.Show("Printer error:" + ex.Message, "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:" +ex.Message);
            MessageBox.Show("An error occurred:"+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static void Pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        try
        {
            var stream = _streams[_streamAtual];
            stream.Seek(0, SeekOrigin.Begin);

            using (var metadata = new Metafile(stream))
            {
                e.Graphics.DrawImage(metadata, e.PageBounds);
            }

            _streamAtual++;
            e.HasMorePages = _streamAtual < _streams.Count;

            Console.WriteLine("Printed page " +_streamAtual);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during PrintPage event:" + ex.Message);
            throw;
        }
    }
}


