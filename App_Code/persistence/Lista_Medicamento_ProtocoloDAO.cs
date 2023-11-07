using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Lista_Medicamento_ProtocoloDAO
/// </summary>
public class Lista_Medicamento_ProtocoloDAO
{
    public Lista_Medicamento_ProtocoloDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<Medicamento_Protocolo> listaMedicamentos()
    {
        var listaMedicamentos = new List<Medicamento_Protocolo>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_medicamento_protocolo],[medicacoes],[status] FROM [Oncologia_Desenv].[dbo].[Medicamento_Protocolo]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                   Medicamento_Protocolo itemLista = new Medicamento_Protocolo();
                    itemLista.cod_medicamento_protocolo = dr1.GetInt32(0);
                    itemLista.medicacoes = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                   

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
    public static List<Medicamento_Protocolo> listaMedicamentosPorId(int id)
    {
        var listaMedicamentos = new List<Medicamento_Protocolo>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_protocolo],[cod_medicamento],[data_cadastro],[status],[dose],[unidade_dose],[cod_via_de_administracao],[diluicao],[tempo_de_infusao],[unidade_tempo_infusao],[cod_pre_quimio] FROM [Oncologia_Desenv].[dbo].[Link_Protocolo_Medicamento] where [cod_medicamento]= 5";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    Medicamento_Protocolo itemLista = new Medicamento_Protocolo();
                    itemLista.cod_medicamento_protocolo = dr1.GetInt32(0);
                    itemLista.medicacoes = dr1.IsDBNull(1) ? "" : dr1.GetString(1);


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