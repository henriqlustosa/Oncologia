﻿using System;
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
/// Summary description for ImpressoraDAO
/// </summary>
public class ImpressoraDAO
{
	public ImpressoraDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static List<Impressora> ListaImpressora()
    {
        var lista = new List<Impressora>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT * " +
                              " FROM [dbo].[Impressora]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    Impressora imp = new Impressora();
                    imp.cod_impressora = dr1.GetInt32(0);
                   
                    imp.nome_impressora = dr1.GetString(1);
                
                    imp.ip_computador = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    imp.nome_computador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    lista.Add(imp);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;

    }

    public static Impressora buscarNomeDaImpressoraPorIP(string ip_computador)
    {
        Impressora imp = new Impressora();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT * " +
                              " FROM [dbo].[Impressora] where ip_computador ='" + ip_computador +"'";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                if (dr1.Read())
                {
                  
                    imp.cod_impressora = dr1.GetInt32(0);

                    imp.nome_impressora = dr1.GetString(1);
                 
                    imp.ip_computador = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    imp.nome_computador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                   
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return imp;

    }

    public static string GravaImpressora(string nome_impressora, string tipo, string descricao_impressora, string ip_impressora)
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
                cmm.CommandText = "INSERT INTO [dbo].[Impressora]" +
                                   "([tipo]" +
                                   ",[nome_impressora]" +
                                   ",[descricao_impressora]" +
                                   ",[ip])" +
                             "VALUES " +
                                   "(@tipo" +
                                   ",@nome_impressora" +
                                   ",@descricao_impressora" +
                                   ",@ip)";

                cmm.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo.ToUpper();
                cmm.Parameters.Add("@nome_impressora", SqlDbType.VarChar).Value = nome_impressora.ToUpper();
                cmm.Parameters.Add("@descricao_impressora", SqlDbType.VarChar).Value = descricao_impressora.ToUpper();
                cmm.Parameters.Add("@ip", SqlDbType.VarChar).Value = ip_impressora;

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
}
