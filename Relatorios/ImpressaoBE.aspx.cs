using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.SqlServer.ReportingServices2005.Execution;
using System.Collections.Generic;
using System.Text;
using Microsoft.Reporting.WebForms;

public partial class Relatorios_ImpressaoBE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        //using (var ds = CriarDataSet())
        using (var relatorio = new Microsoft.Reporting.WebForms.LocalReport())
        {
            relatorio.ReportPath = "Relatorios/Ficha.rdlc";
            //relatorio.ReportPath = "Relatorios/Report.rdlc";
            //relatorio.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("hspmPsDataSet", (DataTable)ds.Item));

            FichaDAO sr = new FichaDAO();
            List<Ficha> sc = new List<Ficha>();
            //Ficha sc = new Ficha();

            sc = sr.GetFicha(1);// ficha teste nº 1
            
            IEnumerable<Ficha> ie;
            ie = sc.AsQueryable();
            ReportDataSource datasource = new ReportDataSource("Ficha", ie);
            relatorio.DataSources.Add(datasource);

            Exportar(relatorio);
            Imprimir(relatorio);
        }
    }

    private void Exportar(Microsoft.Reporting.WebForms.LocalReport relatorio)
    {
        Microsoft.Reporting.WebForms.Warning[] warnings;
        LimparStreams();
        relatorio.Render("image", CriarDeviceInfo(relatorio), CreateStreamCallback, out warnings); 
    
    }

    private List<System.IO.Stream> _streams = new List<System.IO.Stream>();
    
    public System.IO.Stream CreateStreamCallback(string name, string extension, Encoding encoding, string mimeType, bool willSeek)
    {
        var stream = new System.IO.MemoryStream();
        _streams.Add(stream);
        return stream;
    }

    private void LimparStreams()
    {
        foreach (var stream in _streams)
        {
            stream.Dispose();
        }
        _streams.Clear();
    }

    private string CriarDeviceInfo(Microsoft.Reporting.WebForms.LocalReport relatorio)
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


    private void Imprimir(Microsoft.Reporting.WebForms.LocalReport relatorio)
    {
        using (var pd = new System.Drawing.Printing.PrintDocument())
        {
            //configurar impressora
            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
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

    private int _streamAtual;
    private void Pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
