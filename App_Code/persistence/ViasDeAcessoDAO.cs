using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViasDeAcessoDAO
/// </summary>
public class ViasDeAcessoDAO
{
    public ViasDeAcessoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void GravaViasDeAcessoPorPrescricao(List<ViasDeAcesso> listaDeViasDeAcesso, int cod_Prescricao, DateTime dataCadastro)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            string status = "A";

            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {

                foreach (ViasDeAcesso viasDeAcesso in listaDeViasDeAcesso)
                {
                    cmm.CommandText = "Insert into [dbo].[ViasDeAcesso_Prescricao] ([cod_Vias_de_Acesso], [cod_Prescricao],data_cadastro,status)"
                    + " values ('"
                                + viasDeAcesso.cod_vias_de_acesso + "',"
                                + cod_Prescricao + ",'"
                                + dataCadastro + "','"
                                + status
                                + "');";
                    cmm.ExecuteNonQuery();


                }

                mt.Commit();
                mt.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                mt.Rollback();
            }
        }
    }

    public static List<ViasDeAcesso> ListaViasDeAcesso()
    {
        var lista = new List<ViasDeAcesso>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT * " +
                              "  FROM [hspmoncohomologacao].[dbo].[Vias_De_Acesso]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();


                while (dr1.Read())
                {
                    ViasDeAcesso viasDeAcesso = new ViasDeAcesso();
                    viasDeAcesso.cod_vias_de_acesso = dr1.GetInt32(0);
                    viasDeAcesso.descr_vias_de_acesso = dr1.GetString(1);
                    viasDeAcesso.status_vias_de_acesso = dr1.GetString(2);

                    lista.Add(viasDeAcesso);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;

    }



  




    public static List<ViasDeAcesso_Prescricao> BuscarViasDeAcessoPorCodPrescricao(int cod_Prescricao)
    {
        List<ViasDeAcesso_Prescricao> listaViasDeAcesso = new List<ViasDeAcesso_Prescricao>();


        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Vias_de_Acesso], [cod_vias_de_acesso],[data_cadastro],[status] FROM [hspmoncohomologacao].[dbo].[ViasDeAcesso_Prescricao] AS VP INNER JOIN [hspmoncohomologacao].[dbo].[Vias_De_Acesso] AS V.cod_Vias_De_Acesso ON VP.cod_Vias_De_Acesso   where status = 'A' and cod_Prescricao =" + cod_Prescricao;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    ViasDeAcesso_Prescricao ViasDeAcesso_Prescricao = new ViasDeAcesso_Prescricao();
                    ViasDeAcesso_Prescricao.cod_vias_de_acesso= dr1.GetInt32(0);
                    ViasDeAcesso_Prescricao.cod_vias_de_acesso = dr1.GetInt32(1);
                    ViasDeAcesso_Prescricao.descr_vias_de_acesso = dr1.GetString(2);


                    listaViasDeAcesso.Add(ViasDeAcesso_Prescricao);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return listaViasDeAcesso;
        }
    }

    public static void DeletarViasDeAcessoPorPrescricao(int cod_Prescricao, DateTime data_cadastro)
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
                cmm.CommandText = "UPDATE [dbo].[ViasDeAcesso_Prescricao] SET" +


      " [status] = @status " +

      ",[data_atualizacao] = @data_atualizacao" +
 " WHERE cod_Prescricao = @cod_Prescricao and status = 'A'";






                cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = cod_Prescricao;
                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = data_cadastro;
                cmm.Parameters.Add("@status", SqlDbType.VarChar).Value = "I";




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