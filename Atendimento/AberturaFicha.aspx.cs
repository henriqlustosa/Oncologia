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
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;

using Microsoft.SqlServer.ReportingServices2005.Execution;
using System.Text;

public partial class Atendimento_AberturaFicha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    private void CarregarImpressoras()
    {
       
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        string mensagem = "";
        int _pront = 0;
        if (txbProntuario.Text != "")
        {
            _pront = Convert.ToInt32(txbProntuario.Text);
        }

        Ficha be = new Ficha();
        be.prontuario = _pront;
        be.documento = txbDocumento.Text;
        be.tipo_paciente = rbTipoPaciente.SelectedValue;
        be.nome_paciente = txbNomePaciente.Text;

        if (txbNascimento.Text == "")
        {
            DateTime seData = new DateTime(1800,1,1);
            be.dt_nascimento = seData;
        }
        else
        {
            be.dt_nascimento = Convert.ToDateTime(txbNascimento.Text);
        }
        
        be.idade = txbIdade.Text;
        be.sexo = ddlSexo.SelectedValue;
        be.raca = ddlRaca.SelectedValue;
        be.endereco_rua = txbEndereco.Text;
        be.numero_casa = txbNumero.Text;
        be.complemento = txbComplemento.Text;
        be.bairro = txbBairro.Text;
        be.municipio = txbMunicipio.Text;
        be.uf = txbUF.Text;
        be.cep = txbCEP.Text;
        be.nome_pai_mae = txbPais.Text;
        be.responsavel = txbResponsavel.Text;
        be.telefone = txbTelefone.Text;
        be.procedencia = txbProcedencia.Text;
        be.queixa = txbQueixa.Text;

        be.setor = ddlSetor.SelectedValue;
        be.usuario = System.Web.HttpContext.Current.User.Identity.Name;

        int _cod_ficha_be = FichaDAO.GravaFicha(be.dt_rh_be
                                                ,be.prontuario
                                                , be.documento
                                                , be.tipo_paciente
                                                , be.nome_paciente
                                                , be.dt_nascimento
                                                , be.idade
                                                , be.sexo
                                                , be.raca
                                                , be.endereco_rua
                                                , be.numero_casa
                                                , be.complemento
                                                , be.bairro
                                                , be.municipio
                                                , be.uf
                                                , be.cep
                                                , be.nome_pai_mae
                                                , be.responsavel
                                                , be.telefone
                                                , be.procedencia
                                                , be.queixa
                                                ,be.setor
                                                , be.usuario
                                               );

        mensagem = "Ficha: " + Convert.ToString(_cod_ficha_be);
        
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);

        ClearInputs(Page.Controls);// limpa os textbox

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

    void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            ClearInputs(ctrl.Controls);
        }
    }

    // metodos para imprimir o BE
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
            //pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrinterName = "Lexmark MX710";
            

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
