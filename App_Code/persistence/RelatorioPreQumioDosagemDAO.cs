using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioPreQumioDosagemDAO
/// </summary>
public class RelatorioPreQumioDosagemDAO
{
    public RelatorioPreQumioDosagemDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static List<RelatorioPreQuimioDosagem> BuscarPrequimiosPorCodPrescricao(int cod_prescricao)
    {
        List<RelatorioPreQuimioDosagem> preQuimios = new List<RelatorioPreQuimioDosagem>();

        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            //Colocar um inner join com 

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [Id]" +
      ",[desc_pre_quimio] " +
      ",[desc_medicacao] " +
     ",[desc_quimio] " +
     " ,[desc_via_de_administracao] " +
     " ,[nome_Usuario] " +
     " ,[dose] " +
      ",[unidade_dose] " +
      ",[diluicao] " +
      ",[tempoDeInfusao] " +
      ",[unidadeTempoDeInfusao] " +
      ",[dataCadastro] " +
      ",[status] " +
      ",[cod_PreQuimio]" +
       ",[cod_CalculoDosagemPreQuimio]" +
        ",[dose_alterada]" +


  "FROM [dbo].[Vw_RelatorioPreQuimioDosagem]  where cod_prescricao = " + cod_prescricao;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    RelatorioPreQuimioDosagem preQuimio = new RelatorioPreQuimioDosagem();
                    preQuimio.Id = dr1.GetInt32(0);
                    preQuimio.desc_pre_quimio = dr1.GetString(1);
                    preQuimio.desc_medicacao = dr1.GetString(2);
                    preQuimio.desc_quimio = dr1.GetString(3);
                    preQuimio.desc_via_de_administracao = dr1.GetString(4);

                    preQuimio.nome_Usuario = dr1.GetString(5);
                    preQuimio.quantidade = dr1.GetDecimal(6);
                    preQuimio.unidadeQuantidade = dr1.GetString(7);
                    preQuimio.diluicao = dr1.GetString(8);
                    preQuimio.tempoDeInfusao = dr1.GetInt32(9);
                    preQuimio.unidadeTempoDeInfusao = dr1.GetString(10);
                    preQuimio.dataCadastro = dr1.GetDateTime(11);
                    preQuimio.status = dr1.GetString(12);
                    preQuimio.cod_Prequimio = dr1.GetInt32(13);
                    preQuimio.cod_CalculoDosagemPreQuimio= dr1.GetInt32(14);

                    preQuimio.dose_alterada = dr1.GetDecimal(15);
                    preQuimios.Add(preQuimio);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return preQuimios;
        }
    }

    public static List<RelatorioPreQuimioDosagem> MostrarMedicamentosParaEdicao(int cod_Prescricao)
    {
        return BuscarPrequimiosPorCodPrescricao(cod_Prescricao);
    }
}