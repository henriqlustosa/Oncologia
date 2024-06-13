using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

    public static PacienteOncologia BuscarPacientePorCodPaciente(int id)
    {
        PacienteOncologia paciente = new PacienteOncologia();

     
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Paciente] " +
      ",[nome_paciente] " +
      ",[data_nascimento] " +
      ",[sexo] " +
      ",[nome_mae] " +
      ",[ddd_telefone] " +
      ",[telefone] " +
      ",[data_Cadastro] " +
      ",[data_Ultima_Atualizacao] " +
  "FROM[dbo].[Paciente] where cod_Paciente = " + id;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                   
                    paciente.cod_Paciente = dr1.GetInt32(0);
                    paciente.nome_paciente = dr1.GetString(1);
                    paciente.data_nascimento = dr1.GetDateTime(2);
                    paciente.sexo = dr1.GetString(3);
                    paciente.nome_mae = dr1.GetString(4);

                    paciente.ddd_telefone = dr1.GetInt32(5);
                    paciente.telefone = dr1.GetInt32(6);
                    paciente.data_Cadastro = dr1.GetDateTime(7);
                    paciente.data_Ultima_Atualizacao = dr1.GetDateTime(8);
                 
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return paciente;
        }
    }

    public static PacienteOncologia BuscarPacientePorCodPrescricao(int cod_prescricao)
    {
        PacienteOncologia paciente = new PacienteOncologia();


        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT p.[cod_Paciente] " +
      ",[nome_paciente] " +
      ",[data_nascimento] " +
      ",[sexo] " +
      ",[nome_mae] " +
      ",[ddd_telefone] " +
      ",[telefone] " +
      ",p.[data_Cadastro] " +
      ",[data_Ultima_Atualizacao] " +
  "FROM [hspmonco].[dbo].[Paciente] as p inner join [hspmonco].[dbo].[Prescricao] as presc on p.cod_Paciente = presc.cod_Paciente where cod_prescricao = " + cod_prescricao;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {

                    paciente.cod_Paciente = dr1.GetInt32(0);
                    paciente.nome_paciente = dr1.GetString(1);
                    paciente.data_nascimento = dr1.GetDateTime(2);
                    paciente.sexo = dr1.GetString(3);
                    paciente.nome_mae = dr1.GetString(4);

                    paciente.ddd_telefone = dr1.GetInt32(5);
                    paciente.telefone = dr1.GetInt32(6);
                    paciente.data_Cadastro = dr1.GetDateTime(7);
                    paciente.data_Ultima_Atualizacao = dr1.GetDateTime(8);

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return paciente;
        }
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