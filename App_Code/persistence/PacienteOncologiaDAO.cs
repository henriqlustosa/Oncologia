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
    public static string AtualizarPaciente(PacienteOncologia pacienteOncologia)
    {
        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cnn.Open();
                SqlTransaction mt = cnn.BeginTransaction();
                cmm.Transaction = mt;
                cmm.CommandText = "UPDATE [dbo].[Paciente] " +
  " SET [nome_paciente] = @nome_paciente" +
     " ,[data_nascimento] = @data_nascimento" +
     " ,[sexo] = @sexo" +
     " ,[nome_mae] = @nome_mae" +
     " ,[ddd_telefone] = @ddd_telefone" +
     " ,[telefone] = @telefone" +
    
     " ,[data_Ultima_Atualizacao] = @data_Ultima_Atualizacao" +
     " WHERE cod_Paciente = @cod_Paciente" ;


 








                cmm.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = pacienteOncologia.nome_paciente;
                cmm.Parameters.Add("@data_nascimento", SqlDbType.DateTime).Value = pacienteOncologia.data_nascimento;
                cmm.Parameters.Add("@sexo", SqlDbType.VarChar).Value = pacienteOncologia.sexo;
                cmm.Parameters.Add("@nome_mae", SqlDbType.VarChar).Value = pacienteOncologia.nome_mae;
                cmm.Parameters.Add("@ddd_telefone", SqlDbType.Int).Value = pacienteOncologia.ddd_telefone;
                cmm.Parameters.Add("@telefone", SqlDbType.Int).Value = pacienteOncologia.telefone;
               
                cmm.Parameters.Add("@data_Ultima_Atualizacao", SqlDbType.VarChar).Value = DateTime.Now;
                cmm.Parameters.Add("@cod_Paciente", SqlDbType.Int).Value = pacienteOncologia.cod_Paciente;




                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
                mensagem = "Cadastro com sucesso!";
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mensagem = error;
            }
        }

        return mensagem;
    }
    public static int BuscarPacienteOncologiaPorDataCadastro(DateTime dataCadastro)
    {
        int cod_Paciente = 0;
  
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Paciente] " +

   " FROM [dbo].[Paciente] where FORMAT(data_cadastro , 'dd/MM/yyyy HH:mm:ss') ='" + dataCadastro + "'";
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    cod_Paciente = dr1.GetInt32(0);
                    

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return cod_Paciente;
        }
    }
        public static int GravarPacienteOncologia(PacienteOncologia pacienteOncologia)
    {
       
        string mensagem = null;
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cnn.Open();
                SqlTransaction mt = cnn.BeginTransaction();
                cmm.Transaction = mt;
                cmm.CommandText = "INSERT INTO [dbo].[Paciente]" +
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
                cmm.Parameters.Add("@cod_paciente", SqlDbType.Int).Value = pacienteOncologia.cod_Paciente;
                cmm.Parameters.Add("@nome_paciente", SqlDbType.VarChar).Value = pacienteOncologia.nome_paciente;
                cmm.Parameters.Add("@data_nascimento", SqlDbType.DateTime).Value = pacienteOncologia.data_nascimento;
                cmm.Parameters.Add("@sexo", SqlDbType.VarChar).Value = pacienteOncologia.sexo;
                cmm.Parameters.Add("@nome_mae", SqlDbType.VarChar).Value = pacienteOncologia.nome_mae;
                cmm.Parameters.Add("@ddd_telefone", SqlDbType.Int).Value = pacienteOncologia.ddd_telefone;
                cmm.Parameters.Add("@telefone", SqlDbType.Int).Value = pacienteOncologia.telefone;
                cmm.Parameters.Add("@data_Cadastro", SqlDbType.VarChar).Value = pacienteOncologia.data_Cadastro;
               




                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
                mensagem = "Cadastro com sucesso!";
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mensagem = error;
            }
        }

        return BuscarPacienteOncologiaPorDataCadastro(pacienteOncologia.data_Cadastro);
    }




    public static bool VerificarPacientePorRh(int rh)
    {
        bool PacientePorRh = false;
  
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_Paciente] " +
     
   "FROM [dbo].[Paciente] where cod_Paciente = " + rh;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    PacientePorRh = true;
                 

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return PacientePorRh;
        }

    }
}