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
using System.IO;
using System.Data.SqlClient;

public partial class Controle_ListaAtendimentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCarregarDados_Click(object sender, EventArgs e)
    {
        int _dia = Convert.ToInt32(txbData.Text.Substring(0, 2));
        int _mes = Convert.ToInt32(txbData.Text.Substring(3, 2));
        int _ano = Convert.ToInt32(txbData.Text.Substring(6, 4));
       


        gvAtendimentos.DataSource = CarregaDadosTotais(_dia, _mes, _ano);
        gvAtendimentos.DataBind();
        ExportGridToExcel();
    }



    public DataTable CarregaDadosTotais(int dia, int mes, int ano)
    {
        DataTable dt = new DataTable();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            try
            {
                cnn.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "SELECT * FROM [hspmPs].[dbo].[vw_listagem_atendimento] "+
                        "WHERE DAY(dt_hr_be) = " + dia + " AND MONTH(dt_hr_be) = " + mes + " AND YEAR(dt_hr_be) = " + ano;

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = command;
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return dt;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Atendimentos" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        
        gvAtendimentos.GridLines = GridLines.Both;
        gvAtendimentos.HeaderStyle.Font.Bold = true;
        gvAtendimentos.RenderControl(htmltextwrtter);
        
        Response.Write(strwritter.ToString());
        Response.End();
    }
}
