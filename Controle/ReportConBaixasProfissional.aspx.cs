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

public partial class Report_ReportConBaixasProfissional : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int mes = Convert.ToInt32(Request.QueryString["mes"]);
            int ano = Convert.ToInt32(Request.QueryString["ano"]);
            Session["ReportsPos"] = null;

            ConfigureCrystalReports(mes,ano);
        }

        if (!(Session["ReportsPos"] == null))
        {
            crvRelatorioProf.ReportSource = (ReportDocument)Session["ReportsPos"];
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
        rprt.Load(Server.MapPath("~/Controle/ReportConBaixasProfissional.rpt"));

        SqlConnection con = new SqlConnection(@"Data Source=10.48.16.28;database=hspmPs; Persist Security Info=True;user id=hspmApp;password=SoundG@rden=1");
      
        string sqlString = "SELECT [nome_profissional] " +
                          ",[BE_MONTH] " +
                          ",[BE_YEAR] " +
                          ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]" +
                          ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] " +
                      " FROM [hspmPs].[dbo].[vw_baixa_por_profissional_mes_consolidado]" +
                      " WHERE BE_MONTH =" + mes + " AND BE_YEAR =" + ano;

        SqlCommand cmd = new SqlCommand(sqlString, con);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);



        DataTable dt = new DataTable();
        //DataSet ds = new DataSet();
        //sda.Fill(ds, "vw_baixa_por_profissional_mes");
        sda.Fill(dt);

        rprt.SetDataSource(dt);

        crvRelatorioProf.ReportSource = rprt;
        Session["ReportsPos"] = rprt;
    }
}
