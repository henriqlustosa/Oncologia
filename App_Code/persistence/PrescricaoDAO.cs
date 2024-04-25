using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;
using Newtonsoft.Json.Linq;
using Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

/// <summary>
/// Summary description for PrescricaoDAO
/// </summary>
public class PrescricaoDAO
{
    public PrescricaoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int BuscarPrequimioPorCod_Protocolo(int cod_Protocolos)
    {
        int cod_Prescricao = 0;

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "Select top 1 cod_PreQuimio FROM [hspmonco].[dbo].[Protocolos] where cod_DescricaoProtocolo = " + cod_Protocolos;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    cod_Prescricao = dr1.GetInt32(0);


                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return cod_Prescricao;
        }
    }

    public static int BuscarPrescricaoPorDataCadastro(DateTime dataCadastro)
    {
        int cod_Prescricao = 0;

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Prescricao] " +

        " FROM [dbo].[Prescricao] where FORMAT(data_cadastro , 'dd/MM/yyyy HH:mm:ss') ='" + dataCadastro + "'";
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    cod_Prescricao = dr1.GetInt32(0);


                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return cod_Prescricao;
        }


    }

    public static Prescricao BuscarPrescricaoPorCodPrescricao(int cod_prescricao)
    {
        Prescricao prescricao = new Prescricao();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Prescricao]" +
      ",[cod_Paciente]" +
      ",[cod_Finalidade]" +
      ",[cod_Vias_De_Acesso]" +
      ",[cod_Protocolos]" +
      ",[cod_Calculo]" +
      ",[ciclos_provaveis]" +
      ",[intervalo_dias]" +
      ",[data_inicio]" +
      ",[observacao]" +
      ",[data_cadastro]" +
      ",[status]" +
      ",[data_atualizacao]" +
      ",[nome_Usuario]" +
      ",[cod_Prequimio] " +
      ",[creatinina] " +
      ",[nome_Usuario_Atualizacao] " +
  " FROM[dbo].[Prescricao] where status = 'A' and cod_Prescricao = " + cod_prescricao;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {

                    prescricao.cod_Prescricao = dr1.GetInt32(0);
                    prescricao.cod_Paciente = dr1.GetInt32(1);
                    prescricao.cod_Finalidade = dr1.GetInt32(2);
                    prescricao.cod_Vias_De_Acesso = dr1.GetInt32(3);
                    prescricao.cod_Protocolos = dr1.GetInt32(4);
                    prescricao.cod_Calculo = dr1.GetInt32(5);

                    prescricao.ciclos_provaveis = dr1.GetInt32(6);
                    prescricao.intervalo_dias = dr1.GetInt32(7);
                    prescricao.data_inicio = dr1.GetDateTime(8);
                    prescricao.observacao = dr1.GetString(9);
                    prescricao.data_cadastro = dr1.GetDateTime(10);
                    prescricao.status = dr1.GetString(11);
                    prescricao.data_atualizacao = dr1.IsDBNull(12) ? prescricao.data_atualizacao : dr1.GetDateTime(12);
                    prescricao.nome_Usuario = dr1.GetString(13);
                    prescricao.cod_Prequimio = dr1.GetInt32(14);
                    prescricao.creatinina = dr1.GetDecimal(15);
                    prescricao.nome_Usuario_Atualizacao = dr1.IsDBNull(16) ? "" : dr1.GetString(16);



                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return prescricao;
        }


    }









    public static int GravarPrescricao(Prescricao prescricao)
    {



        string mensagem = null;
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cnn.Open();
                SqlTransaction mt = cnn.BeginTransaction();
                cmm.Transaction = mt;
                cmm.CommandText = "INSERT INTO [dbo].[Prescricao] " +
          " ( [cod_Paciente]" +
          " , [cod_Finalidade] " +
          " , [cod_Vias_De_Acesso] " +
          " , [cod_Protocolos] " +
          " , [cod_Calculo] " +
          " , [ciclos_provaveis] " +
          " , [intervalo_dias] " +
          " , [data_inicio] " +

          ", [observacao] " +
          ", [data_cadastro] " +
          ", [status] " +
          ", [nome_Usuario]" +

           ", [cod_Prequimio]" +
              ", [creatinina])" +

    " VALUES" +
          " ( @cod_Paciente " +
          " , @cod_Finalidade " +
          " , @cod_Vias_De_Acesso " +
          " , @cod_Protocolos " +
          " , @cod_Calculo " +
          " , @ciclos_provaveis " +
          " , @intervalo_dias " +
          " , @data_inicio " +

          " , @observacao " +
          " , @data_cadastro " +
          " , @status" +
           " , @nome_Usuario" +
                " , @cod_Prequimio" +
                " , @creatinina)";

                //cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = prescricao.cod_Prescricao;
                cmm.Parameters.Add("@cod_Paciente", SqlDbType.Int).Value = prescricao.cod_Paciente;
                cmm.Parameters.Add("@cod_Finalidade", SqlDbType.Int).Value = prescricao.cod_Finalidade;
                cmm.Parameters.Add("@cod_Vias_De_Acesso", SqlDbType.Int).Value = prescricao.cod_Vias_De_Acesso;
                cmm.Parameters.Add("@cod_Protocolos", SqlDbType.Int).Value = prescricao.cod_Protocolos;
                cmm.Parameters.Add("@cod_Calculo", SqlDbType.Int).Value = prescricao.cod_Calculo;

                cmm.Parameters.Add("@ciclos_provaveis", SqlDbType.Int).Value = prescricao.ciclos_provaveis;
                cmm.Parameters.Add("@intervalo_dias", SqlDbType.Int).Value = prescricao.intervalo_dias;
                cmm.Parameters.Add("@data_inicio", SqlDbType.DateTime).Value = prescricao.data_inicio;



                cmm.Parameters.Add("@observacao", SqlDbType.VarChar).Value = prescricao.observacao;
                cmm.Parameters.Add("@data_cadastro", SqlDbType.DateTime).Value = prescricao.data_cadastro;

                cmm.Parameters.Add("@status", SqlDbType.Char).Value = "A";
                cmm.Parameters.Add("@nome_Usuario", SqlDbType.VarChar).Value = prescricao.nome_Usuario;

                cmm.Parameters.Add("@cod_Prequimio", SqlDbType.Int).Value = prescricao.cod_Prequimio;
                cmm.Parameters.Add("@creatinina", SqlDbType.Decimal).Value = prescricao.creatinina;







                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
                mensagem = "Cadastro com sucesso!";
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mensagem = error;
            }
        }

        return BuscarPrescricaoPorDataCadastro(prescricao.data_cadastro);
    }

    public static void AtualizarPrescricao(Prescricao prescricao)
    {
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cnn.Open();
                SqlTransaction mt = cnn.BeginTransaction();
                cmm.Transaction = mt;
                cmm.CommandText = "UPDATE [dbo].[Prescricao] " +
   "SET[cod_Paciente] = @cod_Paciente" +
      ",[cod_Finalidade] = @cod_Finalidade" +
      ",[cod_Vias_De_Acesso] = @cod_Vias_De_Acesso " +
      ",[cod_Protocolos] = @cod_Protocolos" +
      ",[cod_Calculo] = @cod_Calculo " +
      ",[ciclos_provaveis] = @ciclos_provaveis " +
      ",[intervalo_dias] = @intervalo_dias " +
      ",[data_inicio] = @data_inicio " +
      ",[observacao] = @observacao " +


      ",[data_atualizacao] = @data_atualizacao " +

      ",[cod_Prequimio] = @cod_Prequimio " +
      ",[creatinina] = @creatinina " +
      ",[nome_Usuario_Atualizacao] = @nome_Usuario_Atualizacao " +
" WHERE cod_Prescricao = @cod_Prescricao and status = 'A'";






                cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = prescricao.cod_Prescricao;
                cmm.Parameters.Add("@cod_Paciente", SqlDbType.Int).Value = prescricao.cod_Paciente;
                cmm.Parameters.Add("@cod_Finalidade", SqlDbType.Int).Value = prescricao.cod_Finalidade;
                cmm.Parameters.Add("@cod_Vias_De_Acesso", SqlDbType.Int).Value = prescricao.cod_Vias_De_Acesso;
                cmm.Parameters.Add("@cod_Protocolos", SqlDbType.Int).Value = prescricao.cod_Protocolos;
                cmm.Parameters.Add("@cod_Calculo", SqlDbType.Int).Value = prescricao.cod_Calculo;

                cmm.Parameters.Add("@ciclos_provaveis", SqlDbType.Int).Value = prescricao.ciclos_provaveis;
                cmm.Parameters.Add("@intervalo_dias", SqlDbType.Int).Value = prescricao.intervalo_dias;
                cmm.Parameters.Add("@data_inicio", SqlDbType.DateTime).Value = prescricao.data_inicio;



                cmm.Parameters.Add("@observacao", SqlDbType.VarChar).Value = prescricao.observacao;


                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = prescricao.data_atualizacao;

                cmm.Parameters.Add("@cod_Prequimio", SqlDbType.Int).Value = prescricao.cod_Prequimio;
                cmm.Parameters.Add("@creatinina", SqlDbType.Decimal).Value = prescricao.creatinina;
                cmm.Parameters.Add("@nome_Usuario_Atualizacao", SqlDbType.VarChar).Value = prescricao.nome_Usuario_Atualizacao;


                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
                mensagem = "Cadastro com sucesso!";
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mensagem = error;
            }
        }


    }

    public static void DeletarPrescricao(int cod_Prescricao, DateTime dataAtualizacao)
    {

        string msg = "";
        string usuario = System.Web.HttpContext.Current.User.Identity.Name.ToUpper();
        string _status = "D";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;

            try
            {





                // Atualiza tabela de pedido de MedicacaoPreQuimioDetalhe
                cmm.CommandText = "UPDATE [dbo].[Prescricao]" +
                        " SET [status] = @status " +
                        " , [data_atualizacao] = @data_atualizacao " +
                          " , [nome_Usuario_Atualizacao] = @nome_Usuario_Atualizacao " +
                        " WHERE  cod_Prescricao = @Id";
                cmm.Parameters.Add(new SqlParameter("@Id", cod_Prescricao));
                cmm.Parameters.Add(new SqlParameter("@status", _status));
                cmm.Parameters.Add(new SqlParameter("@data_atualizacao", dataAtualizacao));
                cmm.Parameters.Add(new SqlParameter("@nome_Usuario_Atualizacao", usuario));
                cmm.ExecuteNonQuery();

                mt.Commit();
                mt.Dispose();
                cnn.Close();

                //LogDAO.gravaLog("DELETE: CÓDIGO PEDIDO " + _id, "CAMPO STATUS", usuario);
                msg = "Cadastro realizado com sucesso!";

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                msg = error;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { string error1 = ex1.Message; }
            }
        }
    }

    public static Prescricao HandlePrescricaoEdicao(int cod_prescricao, int cod_Paciente, int cod_Finalidade, int cod_Vias_De_Acesso, int cod_Protocolos, int cod_Calculo, int ciclos_provaveis, int intervalo_dias, DateTime data_inicio, decimal creatinina, string observacao, DateTime data_atualizacao, string nome_Usuario_Atualizacao)
    {
        Prescricao prescricao = new Prescricao
        {
            cod_Prescricao = cod_prescricao,
            cod_Paciente = cod_Paciente,
            cod_Finalidade = cod_Finalidade,
            cod_Vias_De_Acesso = cod_Vias_De_Acesso,
            cod_Protocolos = cod_Protocolos,
            cod_Calculo = cod_Calculo,
            ciclos_provaveis = ciclos_provaveis,
            intervalo_dias = intervalo_dias,
            data_inicio = data_inicio,
            creatinina = creatinina,
            observacao = observacao,
            data_atualizacao = data_atualizacao,
            nome_Usuario_Atualizacao = nome_Usuario_Atualizacao

        };
        prescricao.cod_Prequimio = BuscarPrequimioPorCod_Protocolo(cod_Protocolos);
        AtualizarPrescricao(prescricao);
        return prescricao;  
       
    }
    public static Prescricao HandlePrescricaoGravacao( int cod_Paciente, int cod_Finalidade, int cod_Vias_De_Acesso, int cod_Protocolos, int cod_Calculo, int ciclos_provaveis, int intervalo_dias, DateTime data_inicio, decimal creatinina, string observacao, DateTime data_cadastro, string nome_Usuario)
    {
        Prescricao prescricao = new Prescricao
        {
            
            cod_Paciente = cod_Paciente,
            cod_Finalidade = cod_Finalidade,
            cod_Vias_De_Acesso = cod_Vias_De_Acesso,
            cod_Protocolos = cod_Protocolos,
            cod_Calculo = cod_Calculo,
            ciclos_provaveis = ciclos_provaveis,
            intervalo_dias = intervalo_dias,
            data_inicio = data_inicio,
            creatinina = creatinina,
            observacao = observacao,
            data_cadastro = data_cadastro,
            nome_Usuario = nome_Usuario

        };
        prescricao.cod_Prequimio = BuscarPrequimioPorCod_Protocolo(cod_Protocolos);
        prescricao.cod_Prescricao = GravarPrescricao(prescricao);
        return prescricao;

    }
}