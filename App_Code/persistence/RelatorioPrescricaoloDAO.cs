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
            cmm.CommandText = "SELECT  [cod_Prescricao],[desc_finalidade],[desc_vias_de_acesso],[nome_paciente],[altura],[peso],[BSA],[intervalo_dias],[data_inicio],[observacao],[data_cadastro],[desc_protocolo],[nome_Usuario],[cod_Paciente],[ddd_telefone],[telefone],[sexo],[data_nascimento],[ciclos_provaveis],[desc_prequimio], [cod_prequimio],[cod_protocolo],[nome_profissional],[nr_conselho] FROM [hspmonco].[dbo].[Vw_RelatorioPrescricao]";

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
                 
                    itemLista.observacao = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    itemLista.data_cadastro = dr1.GetDateTime(10);
                    itemLista.desc_protocolo = dr1.IsDBNull(11) ? "" : dr1.GetString(11);

                    itemLista.nome_Usuario = dr1.IsDBNull(12) ? "" : dr1.GetString(12);
                    itemLista.cod_Paciente = dr1.GetInt32(13);
                    itemLista.ddd_telefone = dr1.GetInt32(14);
                    itemLista.telefone = dr1.GetInt32(15);
                    itemLista.sexo = dr1.IsDBNull(16) ? "" : dr1.GetString(16);
                    itemLista.data_nascimento = dr1.GetDateTime(17);
                    itemLista.ciclos_provaveis = dr1.GetInt32(18);
                    itemLista.desc_prequimio = dr1.IsDBNull(19) ? "" : dr1.GetString(19);
                    itemLista.cod_prequimio = dr1.GetInt32(20);
                    itemLista.cod_protocolo = dr1.GetInt32(21);

                    itemLista.nome_profissional = dr1.GetString(22);
                    itemLista.nr_conselho = dr1.GetInt32(23);

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
      " ,[creatinina]" +
      " ,[nome_profissional]" +
        " ,[nr_conselho]" +
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
             
                    relatorio.observacao = dr1.GetString(9);
                    relatorio.data_cadastro = dr1.GetDateTime(10);
                    relatorio.desc_protocolo = dr1.GetString(11);

                    relatorio.nome_Usuario = dr1.GetString(12);
                    relatorio.cod_Paciente = dr1.GetInt32(13);
                    relatorio.ddd_telefone = dr1.GetInt32(14);
                    relatorio.telefone = dr1.GetInt32(15);
                    relatorio.sexo = dr1.GetString(16);
                    relatorio.data_nascimento = dr1.GetDateTime(17);
                    relatorio.ciclos_provaveis = dr1.GetInt32(18);
                    relatorio.desc_prequimio = dr1.GetString(19);
                    relatorio.cod_prequimio = dr1.GetInt32(20);
                    relatorio.cod_protocolo = dr1.GetInt32(21);
                    relatorio.creatinina = dr1.GetDecimal(22);

                    relatorio.nome_profissional = dr1.GetString(23);
                    relatorio.nr_conselho = dr1.GetInt32(24);


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

    public static object listaTodosProtocolosByCod_Profissional(int cod_profissional)
    {
        List<RelatorioPrescricao> relatorioPrescricao = new List<RelatorioPrescricao>();




        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT  [cod_Prescricao],[desc_finalidade],[desc_vias_de_acesso],[nome_paciente],[altura],[peso],[BSA],[intervalo_dias],[data_inicio],[observacao],[data_cadastro],[desc_protocolo],[nome_Usuario],[cod_Paciente],[ddd_telefone],[telefone],[sexo],[data_nascimento],[ciclos_provaveis],[desc_prequimio], [cod_prequimio],[cod_protocolo],[nome_profissional],[nr_conselho] FROM [hspmonco].[dbo].[Vw_RelatorioPrescricao] where cod_profissional = " + cod_profissional ;

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

                    itemLista.observacao = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    itemLista.data_cadastro = dr1.GetDateTime(10);
                    itemLista.desc_protocolo = dr1.IsDBNull(11) ? "" : dr1.GetString(11);

                    itemLista.nome_Usuario = dr1.IsDBNull(12) ? "" : dr1.GetString(12);
                    itemLista.cod_Paciente = dr1.GetInt32(13);
                    itemLista.ddd_telefone = dr1.GetInt32(14);
                    itemLista.telefone = dr1.GetInt32(15);
                    itemLista.sexo = dr1.IsDBNull(16) ? "" : dr1.GetString(16);
                    itemLista.data_nascimento = dr1.GetDateTime(17);
                    itemLista.ciclos_provaveis = dr1.GetInt32(18);
                    itemLista.desc_prequimio = dr1.IsDBNull(19) ? "" : dr1.GetString(19);
                    itemLista.cod_prequimio = dr1.GetInt32(20);
                    itemLista.cod_protocolo = dr1.GetInt32(21);
                    itemLista.nome_profissional = dr1.GetString(22);
                    itemLista.nr_conselho = dr1.GetInt32(23);

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
}