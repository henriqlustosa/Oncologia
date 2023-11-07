using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViaDeAdministracaoDAO
/// </summary>
public class ViaDeAdministracaoDAO
{
    public ViaDeAdministracaoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<ViaDeAdministracao> listaViaDeAdministracao()
    {
        var listaMedicamentos = new List<ViaDeAdministracao>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT  [cod_via_de_administracao],[descricao],[status] FROM [Oncologia_Desenv].[dbo].[Vias_De_Administracao]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    ViaDeAdministracao itemLista = new ViaDeAdministracao();
                    itemLista.cod_via_de_administracao = dr1.GetInt32(0);
                    itemLista.descricao = dr1.IsDBNull(1) ? "" : dr1.GetString(1);


                    listaMedicamentos.Add(itemLista);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return listaMedicamentos;
    }
}