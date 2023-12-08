using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

/// <summary>
/// Summary description for MedicacaoPreQuimioDetalhelDAO
/// </summary>
public class MedicacaoPreQuimioDetalhelDAO
{
    public MedicacaoPreQuimioDetalhelDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string GravarPreQuimio(MedicacaoPreQuimioDetalhe result)
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
                cmm.CommandText = "INSERT INTO[dbo].[MedicacaoPreQuimioDetalhe]" +
           "([cod_PreQuimio]" +
           ", [cod_Medicacao] " +
           ", [cod_Quimio] " +
           ", [cod_ViaDeAdministracao] " +
           ", [nome_Usuario] " +
           ", [quantidade] " +
           ", [unidadeQuantidade] " +
           ", [diluicao] " +
           ", [tempoDeInfusao] " +
           ", [unidadeTempoDeInfusao] " +
           ", [dataCadastro] " +
           ", [status])" +
     "VALUES" +
           "( @cod_PreQuimio," +
           " @cod_Medicacao," +
           " @cod_Quimio," +
           " @cod_ViaDeAdministracao," +
           " @nome_Usuario," +
           " @quantidade," +
           " @unidadeQuantidade," +
           " @diluicao," +
           " @tempoDeInfusao," +
           " @unidadeTempoDeInfusao," +
           " @dataCadastro," +
           " @status)";

                cmm.Parameters.Add("@cod_PreQuimio", SqlDbType.Int).Value = result.cod_PreQuimio;
                cmm.Parameters.Add("@cod_Medicacao", SqlDbType.Int).Value = result.cod_Medicacao;
                cmm.Parameters.Add("@cod_Quimio", SqlDbType.Int).Value = result.cod_Quimio;
                cmm.Parameters.Add("@cod_ViaDeAdministracao", SqlDbType.Int).Value = result.cod_ViaDeAdministracao;
                cmm.Parameters.Add("@nome_Usuario", SqlDbType.VarChar).Value = result.nome_Usuario;
                cmm.Parameters.Add("@quantidade", SqlDbType.Int).Value = result.quantidade;
                cmm.Parameters.Add("@unidadeQuantidade", SqlDbType.VarChar).Value = result.unidadeQuantidade;
                cmm.Parameters.Add("@diluicao", SqlDbType.VarChar).Value = result.diluicao;
                cmm.Parameters.Add("@tempoDeInfusao", SqlDbType.VarChar).Value = result.tempoDeInfusao;
                cmm.Parameters.Add("@unidadeTempoDeInfusao", SqlDbType.VarChar).Value = result.unidadeTempoDeInfusao;
                cmm.Parameters.Add("@dataCadastro", SqlDbType.DateTime).Value = result.dataCadastro;
                cmm.Parameters.Add("@status", SqlDbType.Char).Value = result.status;



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

        return mensagem;
    }

    public static MedicacaoPreQuimioDetalhe BuscarPreQuimioPorId(int Id)
    {
        MedicacaoPreQuimioDetalhe preQuimio = new MedicacaoPreQuimioDetalhe();
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [Id]" +
      ",[cod_PreQuimio]" +
      ",[cod_Medicacao]" +
      ",[cod_Quimio] " +
      ",[cod_ViaDeAdministracao]" +
      ",[nome_Usuario]" +
      ",[quantidade] " +
      ",[unidadeQuantidade] " +
      ",[diluicao] " +
      ",[tempoDeInfusao] " +
      ",[unidadeTempoDeInfusao] " +
      ",[dataCadastro] " +
      ",[status] " +
               " FROM[dbo].[MedicacaoPreQuimioDetalhe] where Id = " + Id;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    preQuimio.Id = dr1.GetInt32(0);
                    preQuimio.cod_PreQuimio = dr1.GetInt32(1);
                    preQuimio.cod_Medicacao = dr1.GetInt32(2);
                    preQuimio.cod_Quimio = dr1.GetInt32(3);
                    preQuimio.cod_ViaDeAdministracao = dr1.GetInt32(4);

                    preQuimio.nome_Usuario = dr1.GetString(5);
                    preQuimio.quantidade = dr1.GetInt32(6);
                    preQuimio.unidadeQuantidade = dr1.GetString(7);
                    preQuimio.diluicao = dr1.GetString(8);
                    preQuimio.tempoDeInfusao = dr1.GetInt32(9);
                    preQuimio.unidadeTempoDeInfusao = dr1.GetString(10);
                    preQuimio.dataCadastro = dr1.GetDateTime(11);
                    preQuimio.status = dr1.GetString(12);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return preQuimio;
        }

    }

    public static string AtualizarPreQuimio(MedicacaoPreQuimioDetalhe result)
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
                cmm.CommandText = "UPDATE [dbo].[MedicacaoPreQuimioDetalhe]" +
            " SET[cod_PreQuimio] = @cod_PreQuimio" +
            ",[cod_Medicacao] = @cod_Medicacao" +
            " ,[cod_Quimio] = @cod_Quimio" +
            ",[cod_ViaDeAdministracao] = @cod_ViaDeAdministracao " +
            ",[nome_Usuario] = @nome_Usuario " +
            " ,[quantidade] = @quantidade" +
            ",[unidadeQuantidade] = @unidadeQuantidade " +
            ",[diluicao] = @diluicao " +
            " ,[tempoDeInfusao] =@tempoDeInfusao " +
            " ,[unidadeTempoDeInfusao] =@unidadeTempoDeInfusao " +
            " ,[dataCadastro] = @dataCadastro" +
            " ,[status] = @status " +


            " WHERE Id = @Id ";






         

                cmm.Parameters.Add("@cod_PreQuimio", SqlDbType.Int).Value = result.cod_PreQuimio;
                cmm.Parameters.Add("@cod_Medicacao", SqlDbType.Int).Value = result.cod_Medicacao;
                cmm.Parameters.Add("@cod_Quimio", SqlDbType.Int).Value = result.cod_Quimio;
                cmm.Parameters.Add("@cod_ViaDeAdministracao", SqlDbType.Int).Value = result.cod_ViaDeAdministracao;
                cmm.Parameters.Add("@nome_Usuario", SqlDbType.VarChar).Value = result.nome_Usuario;
                cmm.Parameters.Add("@quantidade", SqlDbType.Int).Value = result.quantidade;
                cmm.Parameters.Add("@unidadeQuantidade", SqlDbType.VarChar).Value = result.unidadeQuantidade;
                cmm.Parameters.Add("@diluicao", SqlDbType.VarChar).Value = result.diluicao;
                cmm.Parameters.Add("@tempoDeInfusao", SqlDbType.VarChar).Value = result.tempoDeInfusao;
                cmm.Parameters.Add("@unidadeTempoDeInfusao", SqlDbType.VarChar).Value = result.unidadeTempoDeInfusao;
                cmm.Parameters.Add("@dataCadastro", SqlDbType.DateTime).Value = result.dataCadastro;
                cmm.Parameters.Add("@status", SqlDbType.Char).Value = result.status;
                cmm.Parameters.Add("@Id", SqlDbType.Int).Value = result.Id;



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

        return mensagem;
    }
}