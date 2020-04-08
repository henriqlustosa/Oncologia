using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

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

    public static string GravaProfissional(string _nome, int _conselho, int _numero, int _status)
    {
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cnn.Open();
                SqlTransaction mt = cnn.BeginTransaction();
                cmm.Transaction = mt;
                cmm.CommandText = "INSERT INTO [hspmPs].[dbo].[Profissional]" +
                                   "([nome_profissional]" +
                                   ",[conselho]" +
                                   ",[nr_conselho]" +
                                   ",[status_profissional])" +
                             "VALUES " +
                                   "(@nome_profissional" +
                                   ",@conselho" +
                                   ",@nr_conselho" +
                                   ",@status_profissional)";

                cmm.Parameters.Add("@nome_profissional", SqlDbType.VarChar).Value = _nome.ToUpper();
                cmm.Parameters.Add("@conselho", SqlDbType.Int).Value = _conselho;
                cmm.Parameters.Add("@nr_conselho", SqlDbType.Int).Value = _numero;
                cmm.Parameters.Add("@status_profissional", SqlDbType.Bit).Value = _status;

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

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT [cod_profissional] " +
                              ",[nome_profissional]" +
                              ",[conselho]" +
                              ",[nr_conselho]" +
                              ",[status_profissional] " +
                              " FROM [hspmPs].[dbo].[Profissional]";
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
