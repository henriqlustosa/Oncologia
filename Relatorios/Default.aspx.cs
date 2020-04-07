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
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class Relatorios_Default : System.Web.UI.Page
{

    FichaDAO sr = new FichaDAO();
    List<Ficha> sc = new List<Ficha>();
   // Ficha sc = new Ficha();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Relatorios/Ficha.rdlc");
            
            sc = sr.GetFicha(1); // ficha teste nº 1
            IEnumerable<Ficha> ie;
            ie = sc.AsQueryable();
            ReportDataSource datasource = new ReportDataSource("Ficha", ie);
            
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }
    }
    
}