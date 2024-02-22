using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PreQuimioDAO
/// </summary>
public class PreQuimioDAO
{
    private static object nome;

    public PreQuimioDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void deletarPreQuimio(int _id)
    {
        string msg = "";
        string usuario = System.Web.HttpContext.Current.User.Identity.Name.ToUpper();
        string _status = "D";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;

            try
            {





                // Atualiza tabela de pedido de MedicacaoPreQuimioDetalhe
                cmm.CommandText = "UPDATE [dbo].[MedicacaoPreQuimioDetalhe]" +
                        " SET status = @status " +
                        " WHERE  Id = @Id";
                cmm.Parameters.Add(new SqlParameter("@Id", _id));
                cmm.Parameters.Add(new SqlParameter("@status", _status));
                cmm.ExecuteNonQuery();

                mt.Commit();
                mt.Dispose();
                cnn.Close();

                //LogDAO.gravaLog("DELETE: CÓDIGO PEDIDO " + _id, "CAMPO STATUS", usuario);
                msg = "Cadastro realizado com sucesso!";

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                msg = error;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { string error1 = ex1.Message; }
            }
        }
    }

    public static List<PreQuimio> listaPreQuimio()
    {
        List<PreQuimio> preQuimios = new List<PreQuimio>();

        /*  ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


          HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://hspmonco.azurewebsites.net/tipo-pre-quimio/obter-todos-tipos-pre-quimio" );
          request.Method = "GET";
          request.PreAuthenticate = true;
          request.ContentType = "application/json";
          request.Headers.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImhlbnJpcXVlIiwicm9sZSI6IkFkbWluaXN0cmFkb3IiLCJJZCI6IjEiLCJuYmYiOjE2OTk4ODM2NDcsImV4cCI6MTY5OTg5MDg0NywiaWF0IjoxNjk5ODgzNjQ3fQ.JOMIbRy_ps2brWUNZZD3a3BgfGlcXM7_mfLCC3gJofs");
          try
          {
              WebResponse response = request.GetResponse();
              using (Stream responseStream = response.GetResponseStream())
              {
                  StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                  model = JsonConvert.DeserializeObject<List<PreQuimio>>(reader.ReadToEnd());

              }
          }
          catch (WebException ex)
          {
              WebResponse errorResponse = ex.Response;
              using (Stream responseStream = errorResponse.GetResponseStream())
              {
                  StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                  String errorText = reader.ReadToEnd();
                  // Log errorText
              }
              throw;
          }
           */

       
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT  [Id],[descricao],[status] FROM [hspmonco].[dbo].[PreQuimio] order by [descricao]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    PreQuimio itemLista = new PreQuimio();
                    itemLista.cod_pre_quimio = dr1.GetInt32(0);
                    itemLista.descricao = dr1.IsDBNull(1) ? "" : dr1.GetString(1);


                    preQuimios.Add(itemLista);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return preQuimios;



        
    }

    

   
    }