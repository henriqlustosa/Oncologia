using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuimioDAO
/// </summary>
public class QuimioDAO
{
    public QuimioDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static List<Quimio> listaQuimio()
    {
        List<Quimio> quimios = new List<Quimio>();

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
            cmm.CommandText = "SELECT  [Id],[descricao],[status] FROM [hspmonco].[dbo].[Quimio] order by [descricao]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    Quimio itemLista = new Quimio();
                    itemLista.cod_Quimio = dr1.GetInt32(0);
                    itemLista.descricao = dr1.IsDBNull(1) ? "" : dr1.GetString(1);


                    quimios.Add(itemLista);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return quimios;




    }
}