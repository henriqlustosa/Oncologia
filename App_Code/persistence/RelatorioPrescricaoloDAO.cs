using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioPrescricaoloDAO
/// </summary>
public class RelatorioPrescricaoloDAO
{
    public RelatorioPrescricaoloDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static List<RelatorioPrescricao> listaTodosProtocolos()
    {
        List<RelatorioPrescricao> relatorioPrexcricao = new List<RelatorioPrescricao>();

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
            cmm.CommandText = "SELECT [cod_Prescricao],[desc_finalidade],[desc_vias_de_acesso],[nome_paciente],[altura],[peso],[BSA],[intervalo_dias],[data_inicio],[data_termino],[observacao],[data_cadastro],[desc_protocolo] FROM [hspmonco].[dbo].[Vw_RelatorioPrescricao]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    RelatorioPrescricao itemLista = new RelatorioPrescricao();
                    itemLista.cod_Prescricao = dr1.GetInt32(0);
                    itemLista.desc_finalidade = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    itemLista.desc_vias_de_acesso = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    itemLista.nome_paciente = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    itemLista.altura = dr1.GetInt32(4);
                    itemLista.peso = dr1.GetInt32(5);

                    itemLista.BSA = dr1.GetDecimal(6);
                    itemLista.intervalo_dias = dr1.GetInt32(7);
                    itemLista.data_inicio = dr1.GetDateTime(8);
                    itemLista.data_termino = dr1.GetDateTime(9);
                    itemLista.observacao = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    itemLista.dataCadastro = dr1.GetDateTime(11);
                    itemLista.desc_protocolo = dr1.IsDBNull(12) ? "" : dr1.GetString(12);


                    relatorioPrexcricao.Add(itemLista);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return relatorioPrexcricao;




    }
}