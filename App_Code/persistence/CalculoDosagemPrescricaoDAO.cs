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

    public static void GravarCalculoDosagemPrescricao(List<CalculoDosagemPrescricao> calculos)
    {

        int id = 0;
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
                    " , [cod_Prescricao])" +
        " VALUES" +
               " (@dose, " +
               " @unidade_dose, " +

               " @dataCadastro," +
                    " @cod_Protocolo," +
                    " @cod_Id_Protocolo ," +
                    " @cod_Prescricao )";
                    cmm.Parameters.Add("@dose", SqlDbType.Decimal).Value = calculo.dose;
                    cmm.Parameters.Add("@unidade_dose", SqlDbType.VarChar).Value = calculo.unidade_dose;

                    cmm.Parameters.Add("@dataCadastro", SqlDbType.DateTime).Value = calculo.dataCadastro;

                    cmm.Parameters.Add("@cod_Protocolo", SqlDbType.Int).Value = calculo.cod_Protocolo;

                    cmm.Parameters.Add("@cod_Id_Protocolo", SqlDbType.Int).Value = calculo.cod_Id_Protocolo;
                    cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = calculo.cod_Prescricao;







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