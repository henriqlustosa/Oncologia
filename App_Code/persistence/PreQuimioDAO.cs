using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PreQuimioDAO
/// </summary>
public class PreQuimioDAO
{
    public PreQuimioDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static List<PreQuimio> listaPreQuimio()
    {
        var lista = new List<PreQuimio>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT [cod_pre_quimio],[descricao],[status],[codigo] FROM [Oncologia_Desenv].[dbo].[Pre_Quimio]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();


                while (dr1.Read())
                {
                    PreQuimio preQuimio = new PreQuimio();
                    preQuimio.cod_pre_quimio = dr1.GetInt32(0);
                    preQuimio.descricao = dr1.GetString(1);
                    preQuimio.status = dr1.GetString(2);
                    preQuimio.codigo = dr1.GetString(3);

                    lista.Add(preQuimio);
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