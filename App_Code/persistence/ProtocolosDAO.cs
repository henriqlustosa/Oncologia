using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;

using System.Security.Cryptography;

/// <summary>
/// Summary description for ProtocolosDAO
/// </summary>
public class ProtocolosDAO
{
    private static Protocolos protocolo;

    public ProtocolosDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string AtualizarProtocolo(Protocolos result)
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
                cmm.CommandText = "UPDATE [dbo].[Protocolos]" +
             " SET[cod_DescricaoProtocolo] = @cod_DescricaoProtocolo" +
      " ,[cod_Medicacao] = @cod_Medicacao " +
      ",[cod_PreQuimio] = @cod_PreQuimio " +
      " ,[cod_ViaDeAdministracao] = @cod_ViaDeAdministracao " +
      " ,[nome_Usuario] = @nome_Usuario " +
      " ,[dataCadastro] =@dataCadastro " +
      " ,[status] = @status " +
      " ,[dose] = @dose " +
      " ,[unidadeDose] = @unidadeDose" +
      " ,[diluicao] = @diluicao " +
      " ,[tempoDeInfusao] = @tempoDeInfusao " +
      " ,[unidadeTempoDeInfusao] = @unidadeTempoDeInfusao " +


            " WHERE Id = @Id ";








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

    public static Protocolos BuscarProtocoloPorId(int Id)
    {
        Protocolos protocolo = new Protocolos();
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [Id] " +
     ",[cod_DescricaoProtocolo]" +
     " ,[cod_Medicacao] " +
     " ,[cod_PreQuimio] " +
     " ,[cod_ViaDeAdministracao] " +
     " ,[nome_Usuario] " +
     " ,[dataCadastro] " +
     " ,[status] " +
     " ,[dose] " +
     " ,[unidadeDose] " +
     " ,[diluicao] " +
     " ,[tempoDeInfusao] " +
     " ,[unidadeTempoDeInfusao] " +
               " FROM [dbo].[Protocolos] where Id = " + Id;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    protocolo.Id = dr1.GetInt32(0);
                    protocolo.cod_DescricaoProtocolo = dr1.GetInt32(1);
                    protocolo.cod_Medicacao = dr1.GetInt32(2);
                    protocolo.cod_PreQuimio = dr1.GetInt32(3);
                    protocolo.cod_ViaDeAdministracao = dr1.GetInt32(4);

                    protocolo.nome_Usuario = dr1.GetString(5);
                    protocolo.dataCadastro = dr1.GetDateTime(6);
                    protocolo.status = dr1.GetString(7);
                    protocolo.dose = dr1.GetDecimal(8);
                    protocolo.unidadeDose = dr1.GetString(9);
                    protocolo.diluicao = dr1.GetString(10);
                    protocolo.tempoDeInfusao = dr1.GetString(11);
                    protocolo.unidadeTempoDeInfusao = dr1.GetString(12);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return protocolo;
        }
    }

    public static void deletarProtocolo(int _id)
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
                cmm.CommandText = "UPDATE [dbo].[Protocolos]" +
                        " SET status = @status " +
                        " WHERE  Id = @Id";
                cmm.Parameters.Add(new SqlParameter("@Id", _id));
                cmm.Parameters.Add(new SqlParameter("@status", _status));
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
                { }
            }
        }
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
                cmm.Parameters.Add("@dose", SqlDbType.Decimal).Value = result.dose;
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

    internal static Protocolos BuscarProtocoloPorCodPrescricao(int Id)
    {
        
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [Id] " +
     ",[cod_DescricaoProtocolo]" +
     " ,[cod_Medicacao] " +
     " ,[cod_PreQuimio] " +
     " ,[cod_ViaDeAdministracao] " +
     " ,[nome_Usuario] " +
     " ,[dataCadastro] " +
     " ,[status] " +
     " ,[dose] " +
     " ,[unidadeDose] " +
     " ,[diluicao] " +
     " ,[tempoDeInfusao] " +
     " ,[unidadeTempoDeInfusao] " +
               " FROM [dbo].[Protocolos] where Id = " + Id;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                  
                    protocolo.Id = dr1.GetInt32(0);
                    protocolo.cod_DescricaoProtocolo = dr1.GetInt32(1);
                    protocolo.cod_Medicacao = dr1.GetInt32(2);
                    protocolo.cod_PreQuimio = dr1.GetInt32(3);
                    protocolo.cod_ViaDeAdministracao = dr1.GetInt32(4);

                    protocolo.nome_Usuario = dr1.GetString(5);
                    protocolo.dataCadastro = dr1.GetDateTime(6);
                    protocolo.status = dr1.GetString(7);
                    protocolo.dose = dr1.GetDecimal(8);
                    protocolo.unidadeDose = dr1.GetString(9);
                    protocolo.diluicao = dr1.GetString(10);
                    protocolo.tempoDeInfusao = dr1.GetString(11);
                    protocolo.unidadeTempoDeInfusao = dr1.GetString(12);

                   
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return protocolo;
        }
    }

    public static List<Protocolos> BuscarProtocolosPorCodPrescricao(int cod_protocolo)
    {
        List<Protocolos> protocolos = new List<Protocolos>();
        
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [Id] " +
     ",[cod_DescricaoProtocolo]" +
     " ,[cod_Medicacao] " +
     " ,[cod_PreQuimio] " +
     " ,[cod_ViaDeAdministracao] " +
     " ,[nome_Usuario] " +
     " ,[dataCadastro] " +
     " ,[status] " +
     " ,[dose] " +
     " ,[unidadeDose] " +
     " ,[diluicao] " +
     " ,[tempoDeInfusao] " +
     " ,[unidadeTempoDeInfusao] " +
               " FROM [dbo].[Protocolos] where cod_DescricaoProtocolo = " + cod_protocolo;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    Protocolos protocolo = new Protocolos();
                    protocolo.Id = dr1.GetInt32(0);
                    protocolo.cod_DescricaoProtocolo = dr1.GetInt32(1);
                    protocolo.cod_Medicacao = dr1.GetInt32(2);
                    protocolo.cod_PreQuimio = dr1.GetInt32(3);
                    protocolo.cod_ViaDeAdministracao = dr1.GetInt32(4);

                    protocolo.nome_Usuario = dr1.GetString(5);
                    protocolo.dataCadastro = dr1.GetDateTime(6);
                    protocolo.status = dr1.GetString(7);
                    protocolo.dose = dr1.GetDecimal(8);
                    protocolo.unidadeDose = dr1.GetString(9);
                    protocolo.diluicao = dr1.GetString(10);
                    protocolo.tempoDeInfusao = dr1.GetString(11);
                    protocolo.unidadeTempoDeInfusao = dr1.GetString(12);
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