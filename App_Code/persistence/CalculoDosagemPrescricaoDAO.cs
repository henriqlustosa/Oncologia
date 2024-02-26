using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

    public static void DeletarCalculoDosagemPrescricao(int cod_Prescricao, DateTime data_cadastro)
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
                           " , [status])" +
        " VALUES" +
               " (@dose, " +
               " @unidade_dose, " +

               " @dataCadastro," +
                    " @cod_Protocolo," +
                    " @cod_Id_Protocolo ," +
                    " @cod_Prescricao ,"+
                    " @status )";
                    cmm.Parameters.Add("@dose", SqlDbType.Decimal).Value = calculo.dose;
                    cmm.Parameters.Add("@unidade_dose", SqlDbType.VarChar).Value = calculo.unidade_dose;

                    cmm.Parameters.Add("@dataCadastro", SqlDbType.DateTime).Value = calculo.dataCadastro;

                    cmm.Parameters.Add("@cod_Protocolo", SqlDbType.Int).Value = calculo.cod_Protocolo;

                    cmm.Parameters.Add("@cod_Id_Protocolo", SqlDbType.Int).Value = calculo.cod_Id_Protocolo;
                    cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = calculo.cod_Prescricao;
                    cmm.Parameters.Add("@status", SqlDbType.VarChar).Value = "A";







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