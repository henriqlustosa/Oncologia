﻿using System;
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

        int id = 0;
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
           " , [dataCadastro])"+
    " VALUES"+
           " (@altura, "+
           " @peso, "+
           " @BSA, "+
           " @data_cadastro )";
                cmm.Parameters.Add("@cod_Calculo", SqlDbType.Int).Value = calculo.cod_Calculo;
                cmm.Parameters.Add("@altura", SqlDbType.Int).Value = calculo.altura;
                cmm.Parameters.Add("@peso", SqlDbType.Int).Value = calculo.peso;
                cmm.Parameters.Add("@BSA", SqlDbType.Decimal).Value = calculo.BSA;
                cmm.Parameters.Add("@data_cadastro", SqlDbType.DateTime).Value = calculo.dataCadastro;







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
    
        string mensagem = "";
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
}