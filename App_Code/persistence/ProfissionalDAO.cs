using Microsoft.Exchange.WebServices.Data;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Serilog;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProfissionalDAO
/// </summary>
public class ProfissionalDAO
{
    public ProfissionalDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static Profissional GetProfissionalByUserId(string userId)
    {

        Profissional prof = new Profissional();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT [cod_profissional] " +
                              ",[nome_profissional]" +
                              ",[conselho]" +
                              ",[nr_conselho]" +
                              ",[status_profissional] " +
                               ",[UserId] " +
                              " FROM [dbo].[Profissional] WHERE [UserId]= '" + userId + "'";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                if (dr1.Read())
                {
                   
                    prof.cod_profissional = dr1.GetInt32(0);
                    prof.nome_profissional = dr1.GetString(1);
                    //prof.conselho = dr1.GetInt32(2);
                    prof.sigla_conselho = ConselhoDAO.getConselho(dr1.GetInt32(2)).sigla_conselho;
                    prof.nr_conselho = dr1.GetInt32(3);
                    prof.status_profissional = dr1.GetString(4);
                    prof.UserId = Convert.ToString(dr1.GetGuid(5));
                    
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return prof;
    }

    public static Profissional BuscarCodProfissionalPorUserID(string userId)
    {

        Profissional prof = new Profissional();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT [cod_profissional] " +
                              ",[nome_profissional]" +
                              ",[conselho]" +
                              ",[nr_conselho]" +
                              ",[status_profissional] " +
                               ",[UserId] " +
                              " FROM [dbo].[Profissional] WHERE [UserId]= '" + userId + "'";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                if (dr1.Read())
                {

                    prof.cod_profissional = dr1.GetInt32(0);
                    prof.nome_profissional = dr1.GetString(1);
                    //prof.conselho = dr1.GetInt32(2);
                    prof.sigla_conselho = ConselhoDAO.getConselho(dr1.GetInt32(2)).sigla_conselho;
                    prof.nr_conselho = dr1.GetInt32(3);
                    prof.status_profissional = dr1.GetString(4);
                    prof.UserId = Convert.ToString(dr1.GetGuid(5));

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return prof;

    }

    public static string GravaProfissional(string _nome, int _conselho, int _numero, string _status,string _UserId, DateTime data_cadastro, string usuario)
    {
        string mensagem = "";
      
        Guid userId = Guid.Empty;
        try
        {
              userId = Guid.Parse(_UserId);
            
        }
        catch (ArgumentException ex)
        {
            // Handle the case where the GUID string is invalid
            Log.Information(ex.Message);
        }
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cnn.Open();
                SqlTransaction mt = cnn.BeginTransaction();
                cmm.Transaction = mt;
                cmm.CommandText = "INSERT INTO [dbo].[Profissional]" +
                                   "([nome_profissional]" +
                                   ",[conselho]" +
                                   ",[nr_conselho]" +
                                   ",[status_profissional]" +
                                   ",[UserId]" +
                                    ",[data_cadastro]" +
                                    ",[nome_usuario])" +
                             "VALUES " +
                                   "(@nome_profissional" +
                                   ",@conselho" +
                                   ",@nr_conselho" +
                                   ",@status_profissional" +
                                   ",@UserId" +
                ",@data_cadastro"+
                ",@usuario)";
                cmm.Parameters.Add("@nome_profissional", SqlDbType.VarChar).Value = _nome.ToUpper();
                cmm.Parameters.Add("@conselho", SqlDbType.Int).Value = _conselho;
                cmm.Parameters.Add("@nr_conselho", SqlDbType.Int).Value = _numero;
                cmm.Parameters.Add("@status_profissional", SqlDbType.Char).Value = _status;
                cmm.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                cmm.Parameters.Add("@data_cadastro", SqlDbType.DateTime).Value = data_cadastro;
                cmm.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

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

    public static List<Profissional> ListaProfissionais()
    {
        var lista = new List<Profissional>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT [cod_profissional] " +
                              ",[nome_profissional]" +
                              ",[conselho]" +
                              ",[nr_conselho]" +
                              ",[status_profissional] " +
                               ",[UserId] " +
                              " FROM [dbo].[Profissional]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    Profissional prof = new Profissional();
                    prof.cod_profissional = dr1.GetInt32(0);
                    prof.nome_profissional = dr1.GetString(1);
                    //prof.conselho = dr1.GetInt32(2);
                    prof.sigla_conselho = ConselhoDAO.getConselho(dr1.GetInt32(2)).sigla_conselho;
                    prof.nr_conselho = dr1.GetInt32(3);
                    prof.status_profissional = dr1.GetString(4);
                    prof.UserId = Convert.ToString(dr1.GetGuid(5));
                    lista.Add(prof);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;

    }

    public static void DeletarProfisional(int cod_profissional)
    {

        DateTime data_atualizacao = DateTime.Now;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {

                cmm.CommandText = "UPDATE [dbo].[Profissional]" +
                 " SET status_profissional= @status_profissional, data_atualizacao = @data_atualizacao" +
                 " WHERE  cod_profissional = " + cod_profissional;
                cmm.Parameters.Add(new SqlParameter("@status_profissional", "2"));
                cmm.Parameters.Add(new SqlParameter("@data_atualizacao", data_atualizacao));

                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();


            }
            catch (Exception ex)
            {
                string error = ex.Message;

                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                {
                    string error1 = ex1.Message;

                }
            }
        }
    }

    public static Profissional GetProfissionalByCodProfissional(int cod_profissional)
    {
        Profissional prof = new Profissional();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT [cod_profissional] " +
                              ",[nome_profissional]" +
                              ",[conselho]" +
                              ",[nr_conselho]" +
                              ",[status_profissional] " +
                               ",[UserId] " +
                              " FROM [dbo].[Profissional] WHERE [cod_profissional]= " + cod_profissional ;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                if (dr1.Read())
                {

                    prof.cod_profissional = dr1.GetInt32(0);
                    prof.nome_profissional = dr1.GetString(1);
                    //prof.conselho = dr1.GetInt32(2);
                    prof.sigla_conselho = ConselhoDAO.getConselho(dr1.GetInt32(2)).sigla_conselho;
                    prof.nr_conselho = dr1.GetInt32(3);
                    prof.status_profissional = dr1.GetString(4);
                    prof.UserId = Convert.ToString(dr1.GetGuid(5));

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return prof;
    }

    public static void AtualizarProfissional(int cod_profissional ,string nome_profissional, int conselho, int nr_conselho, string status_profissional, string userId, DateTime data_cadastro_atualizado, string usuario)
    {
        Guid _userId;
        try
        {
            _userId = new Guid(userId);
        }
        catch (FormatException)
        {
            string message ="Invalid User ID format.";
            return;
        }
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
                cmm.CommandText = "UPDATE [dbo].[Profissional] SET" +
                                   " [nome_profissional] = @nome_profissional" +
                                   ",[conselho] = @conselho" +
                                   ",[nr_conselho] = @nr_conselho" +
                                   ",[status_profissional] = @status_profissional" +
                                   ",[UserId] = @UserId" +
                                    ",[data_atualizacao]  = @data_atualizacao" +
                                     ",[nome_usuario_atualizacao]  = @usuario" +
                             " WHERE  " +
                                   " cod_profissional = " + cod_profissional;
                                 

                cmm.Parameters.Add("@nome_profissional", SqlDbType.VarChar).Value = nome_profissional.ToUpper();
                cmm.Parameters.Add("@conselho", SqlDbType.Int).Value = conselho;
                cmm.Parameters.Add("@nr_conselho", SqlDbType.Int).Value = nr_conselho;
                cmm.Parameters.Add("@status_profissional", SqlDbType.Char).Value = status_profissional;
                cmm.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = _userId;
                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = data_cadastro_atualizado;
                cmm.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;

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
}