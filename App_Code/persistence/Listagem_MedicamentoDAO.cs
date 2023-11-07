using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Listagem_MedicoDAO
/// </summary>
public class Listagem_MedicamentoDAO
{
    public Listagem_MedicamentoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<Medicamento_Amostra> CarregarDropDownListMedicamento(int cod_protocolo)
    {
        var listaMedicamentos = new List<Medicamento_Amostra>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [Droga],[Via],[Nome Comercial],[Concentração],[Volume de Diluição para Infusão],[Estabilidade],[Tempo de Infusão],[EQUIPOS],med.[cod_medicamento] FROM [Oncologia_Desenv].[dbo].[Medicamentos] as med join [Oncologia_Desenv].[dbo].[Protocolo_Medicamento] as prot_med  on med.cod_medicamento = prot_med.cod_medicamento where status ='A' and prot_med.cod_protocolo =" + cod_protocolo;

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    Medicamento_Amostra itemLista = new Medicamento_Amostra();
                    itemLista.droga = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    itemLista.via = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    itemLista.nome_comercial = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    itemLista.concentracao = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    itemLista.volume_de_diluicao_para_infusao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    itemLista.estabilidade = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    itemLista.tempo_de_infusao = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    itemLista.equipos = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    itemLista.cod_medicamento = dr1.GetInt32(8);

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

    public static List<Medicamento_Amostra> listaMedicamentos()
    {
        var listaMedicamentos = new List<Medicamento_Amostra>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [Droga],[Via],[Nome Comercial],[Concentração],[Volume de Diluição para Infusão],[Estabilidade],[Tempo de Infusão],[EQUIPOS],[cod_medicamento] FROM [Oncologia_Desenv].[dbo].[Medicamentos_Amostra]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    Medicamento_Amostra itemLista  = new Medicamento_Amostra();
                    itemLista.droga = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    itemLista.via = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    itemLista.nome_comercial = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    itemLista.concentracao = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    itemLista.volume_de_diluicao_para_infusao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    itemLista.estabilidade = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    itemLista.tempo_de_infusao = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    itemLista.equipos = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    itemLista.cod_medicamento =  dr1.GetInt32(8);

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