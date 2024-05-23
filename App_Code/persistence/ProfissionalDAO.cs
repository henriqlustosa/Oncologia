using Microsoft.Exchange.WebServices.Data;
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
                    prof.status_profissional = Convert.ToInt32(dr1.GetBoolean(4));
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

    public static string GravaProfissional(string _nome, int _conselho, int _numero, int _status,string _UserId)
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
                                   ",[UserId])" +
                             "VALUES " +
                                   "(@nome_profissional" +
                                   ",@conselho" +
                                   ",@nr_conselho" +
                                   ",@status_profissional" +
                                   ",@UserId)";

                cmm.Parameters.Add("@nome_profissional", SqlDbType.VarChar).Value = _nome.ToUpper();
                cmm.Parameters.Add("@conselho", SqlDbType.Int).Value = _conselho;
                cmm.Parameters.Add("@nr_conselho", SqlDbType.Int).Value = _numero;
                cmm.Parameters.Add("@status_profissional", SqlDbType.Bit).Value = _status;
                cmm.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

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
                    prof.status_profissional = Convert.ToInt32(dr1.GetBoolean(4));
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

}