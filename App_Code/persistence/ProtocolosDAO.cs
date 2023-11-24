using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProtocolosDAO
/// </summary>
public class ProtocolosDAO
{
    public ProtocolosDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GravarProtocolo(Protocolos result)
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
                cmm.CommandText = "INSERT INTO[dbo].[Protocolos]" +
           "([cod_DescricaoProtocolo]" +
           ", [cod_Medicacao] " +
           ", [cod_PreQuimio] " +
           ", [cod_ViaDeAdministracao] " +
           ", [nome_Usuario] " +
           ", [dose] " +
           ", [unidadeDOse] " +
           ", [diluicao] " +
           ", [tempoDeInfusao] " +
           ", [unidadeTempoDeInfusao] " +
           ", [dataCadastro] " +
           ", [status])" +
     "VALUES" +
           "( @cod_DescricaoProtocolo," +
           " @cod_Medicacao," +
           " @cod_PreQuimio," +
           " @cod_ViaDeAdministracao," +
           " @nome_Usuario," +
           " @dose," +
           " @unidadeDose," +
           " @diluicao," +
           " @tempoDeInfusao," +
           " @unidadeTempoDeInfusao," +
           " @dataCadastro," +
           " @status)";

                cmm.Parameters.Add("@cod_DescricaoProtocolo", SqlDbType.Int).Value = result.cod_DescricaoProtocolo;
                cmm.Parameters.Add("@cod_Medicacao", SqlDbType.Int).Value = result.cod_Medicacao;
                cmm.Parameters.Add("@cod_PreQuimio", SqlDbType.Int).Value = result.cod_PreQuimio;
                cmm.Parameters.Add("@cod_ViaDeAdministracao", SqlDbType.Int).Value = result.cod_ViaDeAdministracao;
                cmm.Parameters.Add("@nome_Usuario", SqlDbType.VarChar).Value = result.nome_Usuario;
                cmm.Parameters.Add("@dose", SqlDbType.Int).Value = result.dose;
                cmm.Parameters.Add("@unidadeDose", SqlDbType.VarChar).Value = result.unidadeDose;
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
}