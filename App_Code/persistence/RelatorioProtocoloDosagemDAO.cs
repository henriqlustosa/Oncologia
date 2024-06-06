using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioProtocoloDosagemDAO
/// </summary>
public class RelatorioProtocoloDosagemDAO
{
    public RelatorioProtocoloDosagemDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<RelatorioProtocoloDosagem> MostrarMedicamentosParaEdicao(int cod_Prescricao)
    {
        return BuscarProtocolosPorCodPrescricao(cod_Prescricao);
    }

    internal static List<RelatorioProtocoloDosagem> BuscarProtocolosPorCodPrescricao(int cod_prescricao)
    {
        List<RelatorioProtocoloDosagem> protocolos = new List<RelatorioProtocoloDosagem>();

     
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [Id] " +
 " ,[desc_descricao_protocolo] " +
"  ,[desc_medicacao] " +
 " ,[desc_pre_quimio] " +
 " ,[desc_via_de_administracao] " +
 " ,[nome_Usuario] " +
  " ,[dose] " +
 " ,[unidadeDose] " +
 " ,[diluicao] " +
 " ,[tempoDeInfusao] " +
 ",[unidadeTempoDeInfusao] " +
 " ,[dataCadastro] " +
"  ,[cod_DescricaoProtocolo] " +
"  ,[cod_CalculoDosagem] " +
"  ,[cod_Prescricao] " +
"  ,[dosagem] " +
"  ,[unidade_dosagem] " +
"  ,[dose_alterada] " +
" FROM[dbo].[Vw_RelatorioProtocoloDosagem] where cod_Prescricao = " + cod_prescricao;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    RelatorioProtocoloDosagem protocolo = new RelatorioProtocoloDosagem();
                    protocolo.Id = dr1.GetInt32(0);
                    protocolo.desc_descricao_protocolo = dr1.GetString(1);
                    protocolo.desc_medicacao = dr1.GetString(2);
                    protocolo.desc_pre_quimio = dr1.GetString(3);
                    protocolo.desc_via_de_administracao = dr1.GetString(4);

                    protocolo.nome_Usuario = dr1.GetString(5);
                    protocolo.dose = dr1.GetDecimal(6);


                    protocolo.unidadeDose = dr1.GetString(7);
                    protocolo.diluicao = dr1.GetString(8);
                    protocolo.tempoDeInfusao = dr1.GetString(9);
                    protocolo.unidadeTempoDeInfusao = dr1.GetString(10);
                    protocolo.dataCadastro = dr1.GetDateTime(11);
                    protocolo.cod_DescricaoProtocolo = dr1.GetInt32(12);
                    protocolo.cod_CalculoDosagem = dr1.GetInt32(13);
                    protocolo.cod_Prescricao = dr1.GetInt32(14);
                    protocolo.dosagem = dr1.GetDecimal(15);
                    protocolo.unidade_dosagem = dr1.GetString(16);
                    protocolo.dose_alterada = dr1.GetDecimal(17);
                    protocolos.Add(protocolo);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return protocolos;
        }
    }
}