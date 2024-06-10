using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CalculoDosagemPrescricaoPreQuimioDAO
/// </summary>
public class CalculoDosagemPrescricaoPreQuimioDAO
{
    public CalculoDosagemPrescricaoPreQuimioDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static CalculoDosagemPrescricaoPreQuimio ApresentarDadosCalculoDosagemPreQuimio(int idCalculoDosagemPreQuimio)
    {
        CalculoDosagemPrescricaoPreQuimio calc = new CalculoDosagemPrescricaoPreQuimio();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_CalculoDosagemPreQuimio] " +
     " ,[dose] " +
     " ,[unidade_dose]" +
     " ,[dose_alterada]" +
     " ,[porcentagemDiminuirDose]" +
     " FROM [dbo].[Calculo_Dosagem_Prescricao_Prequimio] " +
     " WHERE cod_CalculoDosagemPreQuimio = " + idCalculoDosagemPreQuimio;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    calc.cod_CalculoDosagem = dr1.GetInt32(0);
                    calc.dose = dr1.GetDecimal(1);
                    calc.unidade_dose = dr1.GetString(2);
                    calc.dose_alterada = dr1.GetDecimal(3);
                    calc.porcentagemDiminuirDose = dr1.GetInt32(4);
                 



                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return calc;
        }
    }

    public static void AtualizarCalculoDosagemPrescricaoPreQuimio(int cod_CalculoDosagemPreQuimio, DateTime data_cadastro, string usuario, int porcentagemDiminuirDose, Decimal dose_alterada)
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
                cmm.CommandText = "UPDATE [dbo].[Calculo_Dosagem_Prescricao_Prequimio] SET" +

    " [dose_alterada] = @dose_alterada " +
       " ,[nome_Usuario_Atualizacao] = @nome_Usuario_Atualizacao " +
        ",[porcentagemDiminuirDose] = @porcentagemDiminuirDose" +
      ",[data_atualizacao] = @data_atualizacao" +
 " WHERE cod_CalculoDosagemPreQuimio = @cod_CalculoDosagemPreQuimio and status = 'A'";



                cmm.Parameters.Add("@cod_CalculoDosagemPreQuimio", SqlDbType.Int).Value = cod_CalculoDosagemPreQuimio;
                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = data_cadastro;
                cmm.Parameters.Add("@nome_Usuario_Atualizacao", SqlDbType.VarChar).Value = usuario;
                cmm.Parameters.Add("@porcentagemDiminuirDose", SqlDbType.Int).Value = porcentagemDiminuirDose;
                cmm.Parameters.Add("@dose_alterada", SqlDbType.Decimal).Value = dose_alterada;





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

    public static void DeletarCalculoDosagemPrescricaoPreQuimio(int cod_Prescricao, DateTime data_cadastro)
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
                cmm.CommandText = "UPDATE [dbo].[Calculo_Dosagem_Prescricao_PreQuimio] SET" +


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

   

    

    public static void GravarCalculoDosagemPrescricaoPreQuimio(List<CalculoDosagemPrescricaoPreQuimio> calculos)
    {


        string mensagem = null;

        foreach (CalculoDosagemPrescricaoPreQuimio calculo in calculos)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand cmm = new SqlCommand();
                    cmm.Connection = cnn;
                    cnn.Open();
                    SqlTransaction mt = cnn.BeginTransaction();
                    cmm.Transaction = mt;
                    cmm.CommandText = "INSERT INTO [dbo].[Calculo_Dosagem_Prescricao_Prequimio] " +
               " ([dose]" +
               " , [unidade_dose] " +
        " , [dataCadastro] " +
         " , [cod_Prequimio] " +
               " , [cod_Id_Prequimio]" +
                    " , [cod_Prescricao]" +
                           " , [status]" +
                            " , [porcentagemDiminuirDose]" +
                    " , [dose_alterada]" +
                           " , [nome_Usuario] )" +
        " VALUES" +
               " (@dose, " +
               " @unidade_dose, " +

               " @dataCadastro," +
                    " @cod_Prequimio," +
                    " @cod_Id_Prequimio ," +
                    " @cod_Prescricao ," +
                    " @status ," +
                     " @porcentagemDiminuirDose ," +
                    " @dose_alterada ," +
                    " @nome_Usuario )";
                    cmm.Parameters.Add("@dose", SqlDbType.Decimal).Value = calculo.dose;
                    cmm.Parameters.Add("@unidade_dose", SqlDbType.VarChar).Value = calculo.unidade_dose;

                    cmm.Parameters.Add("@dataCadastro", SqlDbType.DateTime).Value = calculo.dataCadastro;

                    cmm.Parameters.Add("@cod_Prequimio", SqlDbType.Int).Value = calculo.cod_Prequimio;

                    cmm.Parameters.Add("@cod_Id_Prequimio", SqlDbType.Int).Value = calculo.cod_Id_Prequimio;
                    cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = calculo.cod_Prescricao;
                    cmm.Parameters.Add("@status", SqlDbType.VarChar).Value = "A";
                    cmm.Parameters.Add("@porcentagemDiminuirDose", SqlDbType.Int).Value = 100;
                    cmm.Parameters.Add("@dose_alterada", SqlDbType.Decimal).Value = calculo.dose;
                    cmm.Parameters.Add("@nome_Usuario", SqlDbType.VarChar).Value = calculo.nome_Usuario;





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
}