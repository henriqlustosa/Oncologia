using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioPrescricaoloDAO
/// </summary>
public class RelatorioPrescricaoloDAO
{
    public RelatorioPrescricaoloDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<RelatorioPrescricao> relatorioLista = new List<RelatorioPrescricao>();
    public static List<RelatorioPrescricao> listaTodosProtocolos()
    {
        List<RelatorioPrescricao> relatorioPrescricao = new List<RelatorioPrescricao>();

       


        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT  [cod_Prescricao],[desc_finalidade],[desc_vias_de_acesso],[nome_paciente],[altura],[peso],[BSA],[intervalo_dias],[data_inicio],[data_termino],[observacao],[data_cadastro],[desc_protocolo],[nome_Usuario],[cod_Paciente],[ddd_telefone],[telefone],[sexo],[data_nascimento],[ciclos_provaveis],[desc_prequimio], [cod_prequimio],[cod_protocolo] FROM [hspmonco].[dbo].[Vw_RelatorioPrescricao]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    RelatorioPrescricao itemLista = new RelatorioPrescricao();
                    itemLista.cod_Prescricao = dr1.GetInt32(0);
                    itemLista.desc_finalidade = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    itemLista.desc_vias_de_acesso = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    itemLista.nome_paciente = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    itemLista.altura = dr1.GetInt32(4);
                    itemLista.peso = dr1.GetInt32(5);

                    itemLista.BSA = dr1.GetDecimal(6);
                    itemLista.intervalo_dias = dr1.GetInt32(7);
                    itemLista.data_inicio = dr1.GetDateTime(8);
                    itemLista.data_termino = dr1.GetDateTime(9);
                    itemLista.observacao = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    itemLista.data_cadastro = dr1.GetDateTime(11);
                    itemLista.desc_protocolo = dr1.IsDBNull(12) ? "" : dr1.GetString(12);

                    itemLista.nome_Usuario = dr1.IsDBNull(13) ? "" : dr1.GetString(13);
                    itemLista.cod_Paciente = dr1.GetInt32(14);
                    itemLista.ddd_telefone = dr1.GetInt32(15);
                    itemLista.telefone = dr1.GetInt32(16);
                    itemLista.sexo = dr1.IsDBNull(17) ? "" : dr1.GetString(17);
                    itemLista.data_nascimento = dr1.GetDateTime(18);
                    itemLista.ciclos_provaveis = dr1.GetInt32(19);
                    itemLista.desc_prequimio = dr1.IsDBNull(20) ? "" : dr1.GetString(20);
                    itemLista.cod_prequimio = dr1.GetInt32(21);
                    itemLista.cod_protocolo = dr1.GetInt32(22);

                    relatorioPrescricao.Add(itemLista);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return relatorioPrescricao;




    }

    internal RelatorioPrescricao GetPrescricao(int cod_relatorio_prescricao)
    {
        RelatorioPrescricao relatorio = new RelatorioPrescricao();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [cod_Prescricao] " +
     " ,[desc_finalidade] " +
     " ,[desc_vias_de_acesso] " +
     " ,[nome_paciente]" +
     " ,[altura]" +
     " ,[peso]" +
     " ,[BSA]" +
     " ,[intervalo_dias]" +
     " ,[data_inicio]" +
     " ,[data_termino]" +
     " ,[observacao]" +
     " ,[data_cadastro]" +
     " ,[desc_protocolo]" +
     " ,[nome_Usuario]" +
     " ,[cod_Paciente]" +
     " ,[ddd_telefone]" +
     " ,[telefone]" +
     " ,[sexo]" +
     " ,[data_nascimento]" +
     " ,[ciclos_provaveis]" +
     " ,[desc_prequimio]" +
      " ,[cod_prequimio]" +
     " ,[cod_protocolo]" +
     "       FROM[dbo].[Vw_RelatorioPrescricao] WHERE cod_Prescricao = " + cod_relatorio_prescricao;
            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                if (dr1.Read())
                {

                 
                    relatorio.cod_Prescricao = dr1.GetInt32(0);
                    relatorio.desc_finalidade = dr1.GetString(1);
                    relatorio.desc_vias_de_acesso = dr1.GetString(2);
                    relatorio.nome_paciente = dr1.GetString(3);

                    relatorio.altura = dr1.GetInt32(4);
                   
                    relatorio.peso = dr1.GetInt32(5);
                    relatorio.BSA = dr1.GetDecimal(6);
                    relatorio.intervalo_dias = dr1.GetInt32(7);
                    relatorio.data_inicio = dr1.GetDateTime(8);
                    relatorio.data_termino = dr1.GetDateTime(9);
                    relatorio.observacao = dr1.GetString(10);
                    relatorio.data_cadastro = dr1.GetDateTime(11);
                    relatorio.desc_protocolo = dr1.GetString(12);

                    relatorio.nome_Usuario = dr1.GetString(13);
                    relatorio.cod_Paciente = dr1.GetInt32(14);
                    relatorio.ddd_telefone = dr1.GetInt32(15);
                    relatorio.telefone = dr1.GetInt32(16);
                    relatorio.sexo = dr1.GetString(17);
                    relatorio.data_nascimento = dr1.GetDateTime(18);
                    relatorio.ciclos_provaveis = dr1.GetInt32(19);
                    relatorio.desc_prequimio = dr1.GetString(20);
                    relatorio.cod_prequimio = dr1.GetInt32(21);
                    relatorio.cod_protocolo = dr1.GetInt32(22);


                    //relatorioLista.Add(relatorio);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return relatorio;

    }
}