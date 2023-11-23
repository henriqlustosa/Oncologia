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
/// Summary description for CheckoutDAO
/// </summary>
public class CheckoutDAO
{
	public CheckoutDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string GravaBaixa(int cod_ficha, int cod_status, int cod_profissional, DateTime data_baixa, string obs, string usuario_baixa)
    {
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cnn.Open();
                SqlTransaction mt = cnn.BeginTransaction();
                cmm.Transaction = mt;
                cmm.CommandText = "INSERT INTO [Oncologia_Desenv].[dbo].[baixa]" +
                                   "([cod_ficha]" +
                                   ",[cod_status]" +
                                   ",[cod_profissional]" +
                                   ",[data_baixa]" +
                                   ",[obs]" +
                                   ",[usuario_baixa])" +
                             "VALUES " +
                                   "(@cod_ficha" +
                                   ",@cod_status" +
                                   ",@cod_profissional" +
                                   ",@data_baixa" +
                                   ",@obs" +
                                   ",@usuario_baixa);" +
                                   "UPDATE [Oncologia_Desenv].[dbo].[ficha] SET status_ficha=@cod_status WHERE cod_ficha=@cod_ficha";

                cmm.Parameters.Add("@cod_ficha", SqlDbType.Int).Value = cod_ficha;
                cmm.Parameters.Add("@cod_status", SqlDbType.Int).Value = cod_status;
                cmm.Parameters.Add("@cod_profissional", SqlDbType.Int).Value = cod_profissional;
                cmm.Parameters.Add("@data_baixa", SqlDbType.DateTime).Value = data_baixa;
                cmm.Parameters.Add("@obs", SqlDbType.VarChar).Value = obs;
                cmm.Parameters.Add("@usuario_baixa", SqlDbType.VarChar).Value = usuario_baixa;

                cmm.ExecuteScalar();
                //cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
                mensagem = "Baixa com sucesso!";
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mensagem = error;
            }
        }
        return mensagem;
    }
}
