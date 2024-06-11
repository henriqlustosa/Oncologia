using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CalculoDosagemPrescricaoDAO
/// </summary>
public class CalculoDosagemPrescricaoDAO
{
    public CalculoDosagemPrescricaoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static CalculoDosagemPrescricao ApresentarDadosCalculoDosagem(int idCalculoDosagem)
    {
        CalculoDosagemPrescricao calc = new CalculoDosagemPrescricao();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_CalculoDosagem] " +
     " ,[dose] " +
     " ,[unidade_dose]" +
     " ,[dose_alterada]" +
     " ,[porcentagemDiminuirDose]" +
     " FROM [dbo].[Calculo_Dosagem_Prescricao] " +
     " WHERE cod_CalculoDosagem = " + idCalculoDosagem;
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
    public static void DeletarCalculoDosagemPrescricaoTodos(int cod_prescricao, DateTime data_cadastro)
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
                cmm.CommandText = "UPDATE [dbo].[Calculo_Dosagem_Prescricao] SET" +


      " [status] = @status " +

      ",[data_atualizacao] = @data_atualizacao" +
 " WHERE cod_Prescricao = @cod_Prescricao and status = 'A'";






                cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = cod_prescricao;
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
    public static void AtualizarCalculoDosagemPrescricao(int cod_CalculoDosagem, DateTime data_cadastro, string usuario, int porcentagemDiminuirDose, Decimal dose_alterada)
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
                cmm.CommandText = "UPDATE [dbo].[Calculo_Dosagem_Prescricao] SET" +


      " [dose_alterada] = @dose_alterada " +
       " ,[nome_Usuario_Atualizacao] = @nome_Usuario_Atualizacao " +
        ",[porcentagemDiminuirDose] = @porcentagemDiminuirDose" +
      ",[data_atualizacao] = @data_atualizacao" +
 " WHERE cod_CalculoDosagem = @cod_CalculoDosagem and status = 'A'";






                cmm.Parameters.Add("@cod_CalculoDosagem", SqlDbType.Int).Value = cod_CalculoDosagem;
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
    public static void GravarCalculoDosagemPrescricao(List<CalculoDosagemPrescricao> calculos)
    {

        
        string mensagem = null;

        foreach(CalculoDosagemPrescricao calculo in calculos) {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand cmm = new SqlCommand();
                    cmm.Connection = cnn;
                    cnn.Open();
                    SqlTransaction mt = cnn.BeginTransaction();
                    cmm.Transaction = mt;
                    cmm.CommandText = "INSERT INTO [dbo].[Calculo_Dosagem_Prescricao] " +
               " ([dose]" +
               " , [unidade_dose] " +
        " , [dataCadastro] " +
         " , [cod_Protocolo] " +
               " , [cod_Id_Protocolo]" +
                    " , [cod_Prescricao]" +
                           " , [status]" +
                            " , [porcentagemDiminuirDose]" +
                    " , [dose_alterada]" +
                           " , [nome_Usuario] )" +
        " VALUES" +
               " (@dose, " +
               " @unidade_dose, " +

               " @dataCadastro," +
                    " @cod_Protocolo," +
                    " @cod_Id_Protocolo ," +
                    " @cod_Prescricao ," +
                    " @status ," +
                     " @porcentagemDiminuirDose ," +
                    " @dose_alterada ," +
                    " @nome_Usuario )"; 
                    cmm.Parameters.Add("@dose", SqlDbType.Decimal).Value = calculo.dose;
                    cmm.Parameters.Add("@unidade_dose", SqlDbType.VarChar).Value = calculo.unidade_dose;

                    cmm.Parameters.Add("@dataCadastro", SqlDbType.DateTime).Value = calculo.dataCadastro;

                    cmm.Parameters.Add("@cod_Protocolo", SqlDbType.Int).Value = calculo.cod_Protocolo;

                    cmm.Parameters.Add("@cod_Id_Protocolo", SqlDbType.Int).Value = calculo.cod_Id_Protocolo;
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

    public static void DeletarCalculoDosagemPrescricaoIndividual(int cod_CalculoDosagem, DateTime dataCadastro)
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
                cmm.CommandText = "UPDATE [dbo].[Calculo_Dosagem_Prescricao] SET" +


      " [status] = @status " +

      ",[data_atualizacao] = @data_atualizacao" +
 " WHERE cod_CalculoDosagem = @cod_CalculoDosagem and status = 'A'";






                cmm.Parameters.Add("@cod_CalculoDosagem", SqlDbType.Int).Value = cod_CalculoDosagem;
                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = dataCadastro;
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