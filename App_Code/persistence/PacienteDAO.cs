using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.MobileControls;
using Newtonsoft.Json;
/// <summary>
/// Summary description for PacienteDAO
/// </summary>
public class PacienteDAO
{
    public PacienteDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static Paciente GET(string prontuario)
    {
       Paciente model = new Paciente();

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://intranethspm:5003/hspmsgh-api/pacientes/paciente/" + prontuario);
        try
        {
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                model = JsonConvert.DeserializeObject<Paciente>(reader.ReadToEnd());
               
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


    public static List<Paciente> GETNOME(string nome)
    {

        List<Paciente> model = new List<Paciente>();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://intranethspm:5016/hspmsgh-api/assessor/paciente?_limit=20&nome=" + nome.ToUpper());
        try
        {
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                model = JsonConvert.DeserializeObject<List<Paciente>>(reader.ReadToEnd());

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