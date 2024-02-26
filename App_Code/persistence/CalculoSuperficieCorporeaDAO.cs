using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

/// <summary>
/// Summary description for CalculoSuperficieCorporeaDAO
/// </summary>
public class CalculoSuperficieCorporeaDAO
{
    public CalculoSuperficieCorporeaDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int GravarCalculoSuperficieCorporea(CalculoSuperficieCorporea calculo)
    {

       
        string mensagem = null;
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cnn.Open();
                SqlTransaction mt = cnn.BeginTransaction();
                cmm.Transaction = mt;
                cmm.CommandText = "INSERT INTO [dbo].[Calculo_Superficie_Corporea] "+
           " ([altura]"+
           " , [peso] "+
           " , [BSA] "+
           " , [dataCadastro]"+
              " , [status])" +
    " VALUES" +
           " (@altura, "+
           " @peso, "+
           " @BSA, "+
           " @data_cadastro "+
                " @status )";
                cmm.Parameters.Add("@cod_Calculo", SqlDbType.Int).Value = calculo.cod_Calculo;
                cmm.Parameters.Add("@altura", SqlDbType.Int).Value = calculo.altura;
                cmm.Parameters.Add("@peso", SqlDbType.Int).Value = calculo.peso;
                cmm.Parameters.Add("@BSA", SqlDbType.Decimal).Value = calculo.BSA;
                cmm.Parameters.Add("@data_cadastro", SqlDbType.DateTime).Value = calculo.dataCadastro;
                cmm.Parameters.Add("@status", SqlDbType.Char).Value = "A";







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

        return BuscarCalculoSuperficieCorporeaPorDataCadastro(calculo.dataCadastro);
    }
    public static int BuscarCalculoSuperficieCorporeaPorDataCadastro(DateTime dataCadastro)
    {
        int cod_Paciente = 0;
    
     
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Calculo] " +

        " FROM [dbo].[Calculo_Superficie_Corporea] where FORMAT(dataCadastro , 'dd/MM/yyyy HH:mm:ss') = '" + dataCadastro + "'";
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    cod_Paciente = dr1.GetInt32(0);


                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return cod_Paciente;
        }

    }

    public static CalculoSuperficieCorporea BuscarCalculoSuperficieCorporeaPorCod_Calculo(int cod_Calculo)
    {
        CalculoSuperficieCorporea calc = new CalculoSuperficieCorporea();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Calculo] " +
     " ,[altura]" +
     " ,[peso]" +
     " ,[BSA]" +
     " ,[dataCadastro]" +
     " FROM[dbo].[Calculo_Superficie_Corporea] " +
     " WHERE cod_Calculo = " + cod_Calculo;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    calc.cod_Calculo = dr1.GetInt32(0);
                    calc.altura = dr1.GetInt32(1);
                    calc.peso = dr1.GetInt32(2);
                    calc.BSA = dr1.GetDecimal(3);
                    calc.dataCadastro = dr1.GetDateTime(4);
                   


                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return calc;
        }
    }

    public static void DeletarCalculoSuperficieCorporea(CalculoSuperficieCorporea calculoAnterior, DateTime dataCadastro)
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
                cmm.CommandText = "UPDATE [dbo].[Calculo_Superficie_Corporea] SET" +


      " [status] = @status " +

      ",[dataAtualizacao] = @data_atualizacao" +
 " WHERE cod_Calculo = @cod_Calculo and status = 'A'";






                cmm.Parameters.Add("@cod_Calculo", SqlDbType.Int).Value = calculoAnterior.cod_Calculo;
                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = dataCadastro;
                cmm.Parameters.Add("@status", SqlDbType.VarChar).Value = "D";




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