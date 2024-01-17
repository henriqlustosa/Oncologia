using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
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
                RelatorioPrescricaoloDAO sr = new RelatorioPrescricaoloDAO();
               List<RelatorioPrescricao> sc = new List<RelatorioPrescricao>();
                //Ficha sc = new Ficha();
                sc = sr.GetPrescricao(_cod_relatorio_prescricao);


                IEnumerable<RelatorioPrescricao> ie;
                ie = sc.AsEnumerable();


                ReportDataSource datasource = new ReportDataSource("DataSet1", ie);
                relatorio.DataSources.Add(datasource);

                Exportar(relatorio);
                Imprimir(relatorio);
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

