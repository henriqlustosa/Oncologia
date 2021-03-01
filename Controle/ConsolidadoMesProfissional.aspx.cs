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
using System.IO;

public partial class Controle_ConsolidadoMesProfissional : System.Web.UI.Page
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

        GridView1.DataSource = ConsolidadosDAO.GetListaBaixasPorProfissional(_mes, _ano);// 1 = grupo de paciente
        GridView1.DataBind();
       
    }

    protected void btnVisImpressao_Click(object sender, EventArgs e)
    {
        int _mes = Convert.ToInt32(txbData.Text.Substring(0, 2));
        int _ano = Convert.ToInt32(txbData.Text.Substring(3, 4));

        Response.Redirect("~/Controle/ReportConBaixasProfissionalMes.aspx?mes=" + _mes + "&ano="+ _ano);
    }
   
}
