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
using System.Net;

public partial class Atendimento_EtiquetasAvulso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string hostname =  Dns.GetHostName();

        //string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });

        //lbhostname1.Text = computer_name[0].ToString(); 
        
        //string hostname = "HSPMINS17";


        //// Buscar impresora no cadastro para impressão
        //Computador pc = new Computador();
        //pc = ComputadorDAO.getInfoComputador(hostname);

        //lbIp.Text = pc.ip_computador;
        //lbHostname.Text = pc.nome_computador;

        //lbNomeImpressora.Text = pc.nome_impressora;
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        int _cod_ficha_be = Convert.ToInt32(txbNumBE.Text);
        int qtdEtiquetas = Convert.ToInt32(ddlQtdEtiquetas.SelectedValue);
        //Computador pc = new Computador();
        //pc = ComputadorDAO.getInfoComputador(Dns.GetHostName());
        string nome_impressora_etiqueta = ddlImpressoraEtiqueta.SelectedValue;
        
        if (nome_impressora_etiqueta == "TSC_GUICHE_PS")
        {
            nome_impressora_etiqueta = "TSC_GUICHE_PS"; // impressora termica
            //nome_impressora_etiqueta = "TSC"; // impressora para teste na informática cac999
            ImpressaoFicha.imprimirEtiqueta(_cod_ficha_be, nome_impressora_etiqueta, qtdEtiquetas);
        } 
        else if (nome_impressora_etiqueta == "TSC_CO")
        {
            nome_impressora_etiqueta = "TSC_CO"; // impressora termica
            //nome_impressora_etiqueta = "TSC"; // impressora para teste na informática cac999
            ImpressaoFicha.imprimirEtiqueta(_cod_ficha_be, nome_impressora_etiqueta, qtdEtiquetas);
        }
      
        
        else if (nome_impressora_etiqueta == "TSC_GRIPARIO")
        {
            nome_impressora_etiqueta = "TSC_GRIPARIO"; // impressora termica
            ImpressaoFicha.imprimirEtiqueta(_cod_ficha_be, nome_impressora_etiqueta, qtdEtiquetas);
        }

       // string nome_impressora = pc.nome_impressora; // impressora termica
        //string nome_impressora = "Lexmark MX710";
        //if (nome_impressora_etiqueta != "")
        //{
           // ImpressaoFicha.imprimirEtiqueta(_cod_ficha_be, nome_impressora_etiqueta, qtdEtiquetas);
        //}
    }
}
