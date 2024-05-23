using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_conselho], [sigla_conselho], [descricao_conselho] FROM [dbo].[conselho]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
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