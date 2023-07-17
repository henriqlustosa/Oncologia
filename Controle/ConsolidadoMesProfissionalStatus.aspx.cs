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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

public partial class Controle_ConsolidadoMesProfissionalStatus : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Session["ReportsPos"] = null;

        }

        if (!(Session["ReportsPos"] == null))
        {
            crvRelatorio.ReportSource = (ReportDocument)Session["ReportsPos"];

        }
    }

    protected void btnGerar_Click(object sender, EventArgs e)
    {
        int _mes = Convert.ToInt32(txbData.Text.Substring(0, 2));
        int _ano = Convert.ToInt32(txbData.Text.Substring(3, 4));

        ConfigureCrystalReports(_mes, _ano);
    }

    protected void ConfigureCrystalReports(int mes, int ano)
    {
        rprt.Load(Server.MapPath("~/Controle/CrystalReport.rpt"));

        SqlConnection con = new SqlConnection(@"Data Source=10.48.16.28;database=Oncologia_Desenv; Persist Security Info=True;user id=hspmApp;password=SoundG@rden=1");
        string sqlString = "SELECT nome_profissional, descricao_status, qtd " +
                             " FROM vw_baixa_por_profissional_mes " +
                             " WHERE mes = " + mes +
                             "AND ano = " + ano +
                             " ORDER BY nome_profissional";

        SqlCommand cmd = new SqlCommand(sqlString, con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);



        DataTable dt = new DataTable();
        sda.Fill(dt);

        rprt.SetDataSource(dt);

        crvRelatorio.ReportSource = rprt;
        Session["ReportsPos"] = rprt;
    }
}
