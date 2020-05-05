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
using System.Data.SqlClient;
using System.Drawing;

public partial class Controle_ConsolidadoMes : System.Web.UI.Page
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
                e.Row.BackColor = Color.FromArgb(168,227,215);
           
        }
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        int _mes = Convert.ToInt32(txbData.Text.Substring(0, 2));
        int _ano = Convert.ToInt32(txbData.Text.Substring(3, 4));

        GridView1.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 1);// 1 = grupo de paciente
        GridView1.DataBind();

        gvSetor.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 2);// 2 = grupo de setores
        gvSetor.DataBind();

        gvSAMU.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 3);// 3 = Procedência SAMU
        gvSAMU.DataBind();

        gvPoliciaMilitar.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 4);// 4 = Procedência Polícia Militar
        gvPoliciaMilitar.DataBind();

        gvAMA.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 5);
        gvAMA.DataBind();

        gvBombeiro.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 6);
        gvBombeiro.DataBind();

        gvMetro.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 7);
        gvMetro.DataBind();

        gvGCM.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 8);
        gvGCM.DataBind();

        gvAP.DataSource = ConsolidadosDAO.GetListaDados(_mes, _ano, 9);
        gvAP.DataBind();
    }
}