using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FinalidadeDoTratamentoDAO
/// </summary>
public class FinalidadeDoTratamentoDAO
{
    public FinalidadeDoTratamentoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<FinalidadeDoTratamento> ListaFinalidade()
    {
        var lista = new List<FinalidadeDoTratamento>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT * " +
                              "  FROM [hspmonco].[dbo].[Finalidade]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();


                while (dr1.Read())
                {
                    FinalidadeDoTratamento finalidade = new FinalidadeDoTratamento();
                    finalidade.cod_finalidade = dr1.GetInt32(0);
                    finalidade.desc_finalidade = dr1.GetString(1);
                    finalidade.status_finalidade = dr1.GetString(2);

                    lista.Add(finalidade);
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