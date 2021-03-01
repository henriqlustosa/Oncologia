using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using Microsoft.SqlServer.ReportingServices2005.Execution;
using System.Text;
using System.Drawing.Printing;

/// <summary>
/// Summary description for impressaoFicha
/// </summary>
public class ImpressaoFicha
{
    public ImpressaoFicha()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string nome_impressora { get; set; }
    public static string impressora_etiqueta { get; set; }

    public static void imprimirEtiqueta(int _cod_ficha_be, string _nome_impressora, int qtdEtiquetas)
    {
        impressora_etiqueta = _nome_impressora;

        // Imprimir o BE
        if (_cod_ficha_be > 0)
        {
            using (var etiqueta = new Microsoft.Reporting.WebForms.LocalReport())
            {
                etiqueta.ReportPath = "Etiqueta/etiqueta.rdlc";
                FichaDAO sr = new FichaDAO();
                List<Ficha> sc = new List<Ficha>();
                //Ficha sc = new Ficha();
                sc = sr.GetFicha(_cod_ficha_be);

                IEnumerable<Ficha> ie;
                ie = sc.AsQueryable();


                ReportDataSource datasource = new ReportDataSource("Ficha", ie);
                etiqueta.DataSources.Add(datasource);

                ExportarEtiq(etiqueta);
                for (int x = 0; x < qtdEtiquetas; x++)
                {
                    ImprimirEtiq(etiqueta);
                }
            }
        }
    }

    // metodos para imprimir o BE
    private static void ExportarEtiq(Microsoft.Reporting.WebForms.LocalReport etiqueta)
    {
        Microsoft.Reporting.WebForms.Warning[] warnings;
        LimparStreams();
        etiqueta.Render("image", CriarDeviceInfoEtique(etiqueta), CreateStreamCallback, out warnings);
    }

    private static void ImprimirEtiq(Microsoft.Reporting.WebForms.LocalReport etiqueta)
    {

        using (var pd = new System.Drawing.Printing.PrintDocument())
        {
            //configurar impressora
            //pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrinterName = impressora_etiqueta;

            var pageSettings = new System.Drawing.Printing.PageSettings();
            Margins margins = new Margins(0,0,0,0);
            
            var pageSettingsEtiqueta = etiqueta.GetDefaultPageSettings();
                                   
            pageSettings.PaperSize = pageSettingsEtiqueta.PaperSize;
            pageSettings.Margins = pageSettingsEtiqueta.Margins;

            pd.DefaultPageSettings.Margins = margins;
            //pd.DefaultPageSettings = pageSettings;

            pd.PrintPage += Pd_PrintPage;
            _streamAtual = 0;

            pd.Print();
        }
    }

    private static string CriarDeviceInfoEtique(Microsoft.Reporting.WebForms.LocalReport relatorio)
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
            pageSettings.PaperSize.Width / 58m, pageSettings.PaperSize.Height / 160m, pageSettings.Margins.Top / 100m, pageSettings.Margins.Left / 100m, pageSettings.Margins.Right / 100m, pageSettings.Margins.Bottom / 100m);
    }




    public static void imprimirFicha(int _cod_ficha_be, string _nome_impressora)
    {
        nome_impressora = _nome_impressora;
        // Imprimir o BE
        if (_cod_ficha_be > 0)
        {
            using (var relatorio = new Microsoft.Reporting.WebForms.LocalReport())
            {
                relatorio.ReportPath = "Relatorios/Ficha.rdlc";
                FichaDAO sr = new FichaDAO();
                List<Ficha> sc = new List<Ficha>();
                //Ficha sc = new Ficha();
                sc = sr.GetFicha(_cod_ficha_be);
                
                IEnumerable<Ficha> ie;
                ie = sc.AsQueryable();


                ReportDataSource datasource = new ReportDataSource("Ficha", ie);
                relatorio.DataSources.Add(datasource);

                Exportar(relatorio);
                Imprimir(relatorio);
            }
        }
        
    }


    // metodos para imprimir o BE
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
