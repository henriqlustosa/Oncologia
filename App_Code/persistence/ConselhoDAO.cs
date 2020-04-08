using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ConselhoDAO
/// </summary>
public class ConselhoDAO
{
	public ConselhoDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static Conselho getConselho(int _cod_conselho)
    {
        Conselho conselho = new Conselho();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_conselho], [sigla_conselho], [descricao_conselho] FROM [hspmPs].[dbo].[conselho]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if(dr1.Read())
                {
                    conselho.cod_conselho = dr1.GetInt32(0);
                    conselho.sigla_conselho = dr1.GetString(1);
                    conselho.desricao_conselho = dr1.GetString(2);
                }
                cnn.Close();
              
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return conselho;
    }
}
