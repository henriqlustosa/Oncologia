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
                    cmm.Parameters.Add("@porcentagemDiminuirDose", SqlDbType.Int).Value = 0;
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