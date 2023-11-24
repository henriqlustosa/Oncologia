using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViasDeAcessoDAO
/// </summary>
public class ViasDeAcessoDAO
{
    public ViasDeAcessoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<ViasDeAcesso> ListaViasDeAcesso()
    {
        var lista = new List<ViasDeAcesso>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT * " +
                              "  FROM [hspmonco].[dbo].[Vias_De_Acesso]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

         
                while (dr1.Read())
                {
                    ViasDeAcesso viasDeAcesso = new ViasDeAcesso();
                    viasDeAcesso.cod_vias_de_acesso = dr1.GetInt32(0);
                    viasDeAcesso.descr_vias_de_acesso = dr1.GetString(1);
                    viasDeAcesso.status_vias_de_acesso = dr1.GetString(2);
                  
                    lista.Add(viasDeAcesso);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;

    }
}