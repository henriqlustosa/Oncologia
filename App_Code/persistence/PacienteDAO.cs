using System;
using System.IO;
using System.Net;
using System.Text;
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
}