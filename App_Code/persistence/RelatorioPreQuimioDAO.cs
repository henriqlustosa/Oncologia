using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioPreQuimioDAO
/// </summary>
public class RelatorioPreQuimioDAO
{
    public RelatorioPreQuimioDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<RelatorioPreQuimio> listaTodosPreQuimio()
    {
        List<RelatorioPreQuimio> relatorioPreQuimios = new List<RelatorioPreQuimio>();

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
            cmm.CommandText = "SELECT [Id],[desc_pre_quimio],[desc_medicacao_pre_quimio],[desc_quimio],[desc_via_de_administracao],[nome_Usuario],[quantidade],[unidadeQuantidade],[diluicao],[tempoDeInfusao],[unidadeTempoDeInfusao],[dataCadastro],[status] FROM [hspmonco].[dbo].[Vw_RelatorioPreQuimio]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    RelatorioPreQuimio itemLista = new RelatorioPreQuimio();
                    itemLista.Id = dr1.GetInt32(0);
                    itemLista.desc_pre_quimio = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    itemLista.desc_medicacao_pre_quimio = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    itemLista.desc_quimio = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    itemLista.desc_via_de_administracao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    itemLista.nome_Usuario = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    itemLista.quantidade = dr1.GetInt32(6);
                    itemLista.unidadeQuantidade = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    itemLista.diluicao = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    itemLista.tempoDeInfusao = dr1.GetInt32(9);
                    itemLista.unidadeTempoDeInfusao = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    itemLista.dataCadastro =  dr1.GetDateTime(11);


                    relatorioPreQuimios.Add(itemLista);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return relatorioPreQuimios;




    }
}
