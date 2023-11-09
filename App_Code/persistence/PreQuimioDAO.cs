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
    public static List<PreQuimio> listaPreQuimio()
    {
        List<PreQuimio> model = new List<PreQuimio>();
        WebRequest request = (HttpWebRequest)WebRequest.Create("https://hspmonco.azurewebsites.net/tipo-pre-quimio/obter-todos-tipos-pre-quimio");
        request.Method = "Get";

        request.Headers.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImhlbnJpcXVlIiwicm9sZSI6IkFkbWluaXN0cmFkb3IiLCJJZCI6IjEiLCJuYmYiOjE2OTk1NDE1NTAsImV4cCI6MTY5OTU0ODc1MCwiaWF0IjoxNjk5NTQxNTUwfQ.qY3wFcNKKigbbosFwm4K7c41662mzyHvQJ-5Aml8_mo");


        try
        {
            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseContent = reader.ReadToEnd();
                model = JsonConvert.DeserializeObject<List<PreQuimio>>(responseContent);
                return model;
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
        return model;

    }
}