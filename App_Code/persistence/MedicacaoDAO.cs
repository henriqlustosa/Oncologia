using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MedicacaoDAO
/// </summary>
public class MedicacaoDAO
{
    public MedicacaoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public static List<Medicacao> listaMedicamentos()
    {
        var listaMedicamentos = new List<Medicacao>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT  [Id],[descricao]  FROM [hspmoncohomologacao].[dbo].[Medicacao] order by [descricao] ";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    Medicacao itemLista = new Medicacao();

                    itemLista.cod_Medicacao = dr1.GetInt32(0);
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