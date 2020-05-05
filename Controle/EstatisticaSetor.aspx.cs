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
using System.Drawing;

public partial class Controle_EstatisticaSetor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvAplicaCor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // quando montar as linhas do tipo DADOS
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string project = DataBinder.Eval(e.Row.DataItem, "#").ToString();

            // cores para aprovação
            if (project == "TOTAL")
                e.Row.BackColor = Color.FromArgb(168, 227, 215);

        }
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        int _mes = Convert.ToInt32(txbData.Text.Substring(0, 2));
        int _ano = Convert.ToInt32(txbData.Text.Substring(3, 4));

        gvCM.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "Clínica Médica");
        gvCM.DataBind();

        gvCG.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "Cirurgia Geral");
        gvCG.DataBind();

        gvNeuro.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "Neurocirurgia");
        gvNeuro.DataBind();
        
        gvTrauma.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "Traumatologia");
        gvTrauma.DataBind();
        
        gvBuco.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "Buco Maxilo");
        gvBuco.DataBind();
        
        gvPediatria.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "Pediatria");
        gvPediatria.DataBind();

        gvObstetricia.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "Obstetrícia");
        gvObstetricia.DataBind();
        
        gvCOVID.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "COVID");
        gvCOVID.DataBind();
    }


}
