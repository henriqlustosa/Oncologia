using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net.NetworkInformation;
using Microsoft.Office.Interop.Excel;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System.Activities.Expressions;
using Serilog;
/// <summary>
/// Summary description for PacienteOncologiaDAO
/// </summary>
public class PacienteOncologiaDAO
{
    public PacienteOncologiaDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static PacienteOncologia ObterPacientePorRh(int rh)
    {
        PacienteOncologia pacienteOncologia = new PacienteOncologia();
  
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Paciente] " +
       ",[nome_paciente] " +
       ",[data_nascimento] " +
      " ,[sexo] " +
       ",[nome_mae] " +
       ",[ddd_telefone] " +
             ",[telefone] " +
      " ,[data_Cadastro] " +
       ",[data_Ultima_Atualizacao] " +
   "FROM [dbo].[Paciente] where cod_Paciente " + rh;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    pacienteOncologia.cod_Paciente = dr1.GetInt32(0);
                    pacienteOncologia.nome_paciente = dr1.GetString(1);
                    pacienteOncologia.data_nascimento = dr1.GetDateTime(2);
                    pacienteOncologia.sexo = dr1.GetString(3);
                    pacienteOncologia.nome_mae = dr1.GetString(4);
                    pacienteOncologia.ddd_telefone = dr1.GetInt32(5);

                    pacienteOncologia.telefone = dr1.GetInt32(6);
                    pacienteOncologia.data_Cadastro = dr1.GetDateTime(7);
                    pacienteOncologia.data_Ultima_Atualizacao = dr1.GetDateTime(8);
                
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return pacienteOncologia;
        }

    }
    public static void AtualizarPaciente(PacienteOncologia pacienteOncologia)
    {
        string mensagem = "";

        string updateSql = "UPDATE [dbo].[Paciente] " +
        "  SET [nome_paciente] = @nome_paciente" +
        " ,[data_nascimento] = @data_nascimento" +
        " ,[sexo] = @sexo" +
        " ,[nome_mae] = @nome_mae" +
        " ,[ddd_telefone] = @ddd_telefone" +
        " ,[telefone] = @telefone" +
        " ,[data_Ultima_Atualizacao] = @data_Ultima_Atualizacao" +
        "  WHERE cod_Paciente = @cod_Paciente";

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {


                // Open the connection
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateSql, connection))
                {
                    // Define parameters and their values
                    command.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = pacienteOncologia.nome_paciente;
                    command.Parameters.Add("@data_nascimento", SqlDbType.DateTime).Value = pacienteOncologia.data_nascimento;
                    command.Parameters.Add("@sexo", SqlDbType.VarChar).Value = pacienteOncologia.sexo;
                    command.Parameters.Add("@nome_mae", SqlDbType.VarChar).Value = pacienteOncologia.nome_mae;
                    command.Parameters.Add("@ddd_telefone", SqlDbType.Int).Value = pacienteOncologia.ddd_telefone;
                    command.Parameters.Add("@telefone", SqlDbType.Int).Value = pacienteOncologia.telefone;
                    command.Parameters.Add("@data_Ultima_Atualizacao", SqlDbType.VarChar).Value = pacienteOncologia.data_Ultima_Atualizacao;
                    command.Parameters.Add("@cod_Paciente", SqlDbType.Int).Value = pacienteOncologia.cod_Paciente;
                    // Execute the command
                    int affectedRows = command.ExecuteNonQuery();
                   Log.Information(String.Format("{0} rows updated.", affectedRows));

                }
            }
            catch (Exception ex)
            {
                // Handle potential exceptions
               Log.Information("Error updating data: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }

        public static void GravarPacienteOncologia(PacienteOncologia pacienteOncologia)
    {
       
        string mensagem = null;

        string insertSql = "INSERT INTO [dbo].[Paciente]" +
           "([cod_Paciente]" +
           ",[nome_paciente]" +
           ", [data_nascimento] " +
           ", [sexo] " +
           ", [nome_mae] " +
           ", [ddd_telefone] " +
          " , [telefone] " +
           ", [data_Cadastro])" +
           "VALUES" +
           " ( @cod_Paciente," +
           " @nome_paciente, " +
             " @data_nascimento, " +
          " @sexo, " +
          " @nome_mae, " +
          " @ddd_telefone, " +
          " @telefone, " +
          "@data_Cadastro )";

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                // Open the connection
                connection.Open();

                // Create SqlCommand object
                using (SqlCommand command = new SqlCommand(insertSql, connection))
                {


                    command.Parameters.Add("@cod_paciente", SqlDbType.Int).Value = pacienteOncologia.cod_Paciente;
                    command.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = pacienteOncologia.nome_paciente;
                    command.Parameters.Add("@data_nascimento", SqlDbType.DateTime).Value = pacienteOncologia.data_nascimento;
                    command.Parameters.Add("@sexo", SqlDbType.VarChar).Value = pacienteOncologia.sexo;
                    command.Parameters.Add("@nome_mae", SqlDbType.VarChar).Value = pacienteOncologia.nome_mae;
                    command.Parameters.Add("@ddd_telefone", SqlDbType.Int).Value = pacienteOncologia.ddd_telefone;
                    command.Parameters.Add("@telefone", SqlDbType.Int).Value = pacienteOncologia.telefone;
                    command.Parameters.Add("@data_Cadastro", SqlDbType.VarChar).Value = pacienteOncologia.data_Cadastro;


                    // Execute the command
                    int affectedRows = command.ExecuteNonQuery();
                   Log.Information(String.Format("{0} rows updated.", affectedRows));
                }
            }
            catch (Exception ex)
            {
                // Handle potential exceptions
               Log.Information("Error updating data: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }




    public static bool VerificarPacientePorRh(int rh)
    {
        bool existePacientePorRh = false;
        string query = "SELECT [cod_Paciente] FROM [dbo].[Paciente] where cod_Paciente = " + rh;


        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                // Open the database connection
                connection.Open();

                // Create a SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the command and receive a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are rows to be read
                        if (reader.HasRows)
                        {
                            existePacientePorRh = true;
                        }
                        else
                        {
                           Log.Information("No rows found.");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                // Handle any errors that might have occurred
               Log.Information("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed when done
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return existePacientePorRh;
        }

    }

    public static string HandlePacienteOncologia(string prontuario, string nomePaciente, string nomeMae,
                                       string telefone, string ddd, string sexo, string nascimento,
                                       DateTime dataCadastro)
    {
        try
        {
            // Creating the PacienteOncologia object and initializing its properties
            PacienteOncologia pacienteOncologia = new PacienteOncologia
            {
                cod_Paciente = int.Parse(prontuario),
                nome_paciente = nomePaciente,
                nome_mae = nomeMae,
                telefone = int.Parse(telefone),
                ddd_telefone = int.Parse(ddd),
                sexo = sexo,
                data_nascimento = DateTime.Parse(nascimento),
                
            };

            // Verifying and updating or creating a patient record
            if (VerificarPacientePorRh(pacienteOncologia.cod_Paciente))
            {  
                pacienteOncologia.data_Ultima_Atualizacao = dataCadastro;
               AtualizarPaciente(pacienteOncologia);
                return String.Format("Updated patient registered with ID {0}.", pacienteOncologia.cod_Paciente);
            }
            else
            {
                pacienteOncologia.data_Cadastro = dataCadastro;
                GravarPacienteOncologia(pacienteOncologia);
                return String.Format("New patient registered with ID {0}.", pacienteOncologia.cod_Paciente);
            }
        }
        catch (FormatException fe)
        {
            // Handling format errors for integers and DateTime types
            return String.Format("Input format error: {0}", fe.Message);
        }
        catch (Exception ex)
        {
            // Handling other generic exceptions that could occur
            return String.Format("An unexpected error occurred: {0}", ex.Message);

        }
    }
}