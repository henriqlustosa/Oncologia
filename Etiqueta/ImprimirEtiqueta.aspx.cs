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

public partial class Etiqueta_ImprimirEtiqueta : System.Web.UI.Page
{

    /*
     *  Antes de colocar em produção
     *  Conferir no banco de dados a atualização
     *  
     *  Tabelas
     *   - Impressoras
     *   - Computadores
     *   
     *  View
     *   - vw_impressora_computador
     * 
     */



    protected void Page_Load(object sender, EventArgs e)
    {
        string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
        //lbhostname1.Text = computer_name[0].ToString();

        string hostname = "HSPMINS18";
       
        // Buscar impresora no cadastro para impressão
        Computador pc = new Computador();
        pc = ComputadorDAO.getInfoComputador(hostname);


        lbIp.Text = pc.ip_computador;
        lbHostname.Text = hostname;
        lbNomeImpressora.Text = pc.nome_impressora;
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        int _cod_ficha_be = Convert.ToInt32(txbNumBE.Text);
        Computador pc = new Computador();
        pc = ComputadorDAO.getInfoComputador(Dns.GetHostName());
        int qtd = 4;

        string nome_impressora = pc.nome_impressora; // impressora termica
        //string nome_impressora = "Lexmark MX710";
        ImpressaoFicha.imprimirEtiqueta(_cod_ficha_be, nome_impressora, qtd);
    }
}