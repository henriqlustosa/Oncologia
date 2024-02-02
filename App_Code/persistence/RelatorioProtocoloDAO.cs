using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioProtocoloDAO
/// </summary>
public class RelatorioProtocoloDAO
{
    public RelatorioProtocoloDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<RelatorioProtocolo> listaTodosProtocolos()
    {
        List<RelatorioProtocolo> relatorioProtocolo = new List<RelatorioProtocolo>();

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
            cmm.CommandText = "SELECT [Id],[desc_descricao_protocolo],[desc_medicacao],[desc_pre_quimio],[desc_via_de_administracao],[nome_Usuario],[dose],[unidadeDose],[diluicao],[tempoDeInfusao],[unidadeTempoDeInfusao],[dataCadastro] FROM [hspmonco].[dbo].[Vw_RelatorioProtocolo]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    RelatorioProtocolo itemLista = new RelatorioProtocolo();
                    itemLista.Id = dr1.GetInt32(0);
                    itemLista.desc_descricao_protocolo = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    itemLista.desc_medicacao = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    itemLista.desc_pre_quimio = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    itemLista.desc_via_de_administracao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    itemLista.nome_Usuario = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    itemLista.dose = dr1.GetDecimal(6);
                    itemLista.unidadeDose = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    itemLista.diluicao = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    itemLista.tempoDeInfusao = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    itemLista.unidadeTempoDeInfusao = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    itemLista.dataCadastro = dr1.GetDateTime(11);


                    relatorioProtocolo.Add(itemLista);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return relatorioProtocolo;




    }

    
        public static List<RelatorioProtocolo> BuscarProtocolosPorCodPrescricao(int cod_protocolo)
        {
            List<RelatorioProtocolo> protocolos = new List<RelatorioProtocolo>();

            string mensagem = "";
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
            {

                SqlCommand cmm = cnn.CreateCommand();

                string sqlConsulta = "SELECT [Id] " +
     " ,[desc_descricao_protocolo] " +
    "  ,[desc_medicacao] " +
     " ,[desc_pre_quimio] " +
     " ,[desc_via_de_administracao] " +
     " ,[nome_Usuario] " +
      " ,[dose] " +
     " ,[unidadeDose] " +
     " ,[diluicao] " +
     " ,[tempoDeInfusao] " +
     ",[unidadeTempoDeInfusao] " +
     " ,[dataCadastro] " +
    "  ,[cod_DescricaoProtocolo] " +
  " FROM[dbo].[Vw_RelatorioProtocolo] where cod_DescricaoProtocolo = " + cod_protocolo;
                cmm.CommandText = sqlConsulta;
                try
                {
                    cnn.Open();
                    SqlDataReader dr1 = cmm.ExecuteReader();
                    while (dr1.Read())
                    {
                    RelatorioProtocolo protocolo = new RelatorioProtocolo();
                        protocolo.Id = dr1.GetInt32(0);
                        protocolo.desc_descricao_protocolo = dr1.GetString(1);
                        protocolo.desc_medicacao = dr1.GetString(2);
                        protocolo.desc_pre_quimio = dr1.GetString(3);
                        protocolo.desc_via_de_administracao = dr1.GetString(4);

                        protocolo.nome_Usuario = dr1.GetString(5);
                    protocolo.dose = dr1.GetDecimal(6);
                
                       
                        protocolo.unidadeDose = dr1.GetString(7);
                        protocolo.diluicao = dr1.GetString(8);
                        protocolo.tempoDeInfusao = dr1.GetString(9);
                        protocolo.unidadeTempoDeInfusao = dr1.GetString(10);
                    protocolo.dataCadastro = dr1.GetDateTime(11);
                    protocolo.cod_DescricaoProtocolo = dr1.GetInt32(12);
                    protocolos.Add(protocolo);
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
                return protocolos;
            }
        }
    
}