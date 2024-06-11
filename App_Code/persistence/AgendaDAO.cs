using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AgendaDAO
/// </summary>
public class AgendaDAO
{
    public AgendaDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void GravarAgenda(DateTime dataInicio, int codPrescricao, int ciclosProvaveis, int intervaloDias, DateTime dataCadastro)
    {
        string mensagem = "";
        int posicao = 1;

        for (int i = 0; i < ciclosProvaveis; i++)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
            {
                try
                {
                    cnn.Open();
                    using (SqlTransaction transaction = cnn.BeginTransaction())
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.Transaction = transaction;

                        cmd.CommandText = @"
                        INSERT INTO [dbo].[Agenda]
                        (
                            [cod_Prescricao], 
                            [data_agendada], 
                            [data_cadastro], 
                            [status], 
                            [posicao], 
                            [total_posicoes]
                        )
                        VALUES
                        (
                            @codPrescricao, 
                            @dataAgendada, 
                            @dataCadastro, 
                            @status, 
                            @posicao, 
                            @totalPosicoes
                        )";

                        cmd.Parameters.AddWithValue("@codPrescricao", codPrescricao);
                        cmd.Parameters.AddWithValue("@dataAgendada", dataInicio);
                        cmd.Parameters.AddWithValue("@dataCadastro", dataCadastro);
                        cmd.Parameters.AddWithValue("@status", "A");
                        cmd.Parameters.AddWithValue("@posicao", posicao);
                        cmd.Parameters.AddWithValue("@totalPosicoes", ciclosProvaveis);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }

                    mensagem = "Cadastro com sucesso!";
                }
                catch (Exception ex)
                {
                    mensagem = ex.Message;
                }
            }

            posicao++;
            dataInicio = dataInicio.AddDays(intervaloDias);
        }
    }

    public static List<Agenda> BuscarAgendasPorCodPrescricao(int cod_Prescricao)
    {
        List<Agenda> agendas = new List<Agenda>();

        string mensagem = "";
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT [cod_agenda],[cod_Prescricao],[data_agendada],[data_cadastro],[status],[posicao],[total_posicoes] FROM [hspmonco].[dbo].[Agenda] where status = 'A' and cod_Prescricao =" + cod_Prescricao;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    Agenda agenda = new Agenda();
                    agenda.cod_agenda = dr1.GetInt32(0);
                    agenda.cod_Prescricao = dr1.GetInt32(1);
                  
                    agenda.data_agendada = dr1.GetDateTime(2);
                    agenda.data_cadastro = dr1.GetDateTime(3);
                    agenda.status = dr1.GetString(4);
                    agenda.posicao = dr1.GetInt32(5);
                    agenda.total_posicoes = dr1.GetInt32(6);



                    agendas.Add(agenda);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return agendas;
        }
    }

    public static void DeletarAgendaTodos(int cod_Prescricao, DateTime data_cadastro)
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
                cmm.CommandText = "UPDATE [dbo].[agenda] SET" +


      " [status] = @status " +

      ",[data_atualizacao] = @data_atualizacao" +
 " WHERE cod_Prescricao = @cod_Prescricao and status = 'A'";






                cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = cod_Prescricao;
                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = data_cadastro;
                cmm.Parameters.Add("@status", SqlDbType.VarChar).Value = "I";




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
    }

    public static Agenda ApresentarDadosAgendamento(int idAgenda)
    {
        Agenda agenda = new Agenda();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT  [cod_agenda], [cod_Prescricao], [data_agendada],  [status], [posicao], [total_posicoes] FROM [hspmonco].[dbo].[agenda] where cod_agenda =" +
     + idAgenda;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    agenda.cod_agenda = dr1.GetInt32(0);
                    agenda.cod_Prescricao = dr1.GetInt32(1);
                    agenda.data_agendada = dr1.GetDateTime(2);
                   
                    agenda.status = dr1.GetString(3);

                    agenda.posicao = dr1.GetInt32(4);
                    agenda.total_posicoes = dr1.GetInt32(5);
                    
                 




                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return agenda;
        }
    }

    public static void DeletarAgendaIndividual(int cod_agenda, DateTime dataCadastro)
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
                cmm.CommandText = "UPDATE [hspmonco].[dbo].[agenda] SET" +


      " [status] = @status " +

      ",[data_atualizacao] = @data_atualizacao" +
 " WHERE cod_agenda = @cod_agenda and status = 'A'";






                cmm.Parameters.Add("@cod_agenda", SqlDbType.Int).Value = cod_agenda;
                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = dataCadastro;
                cmm.Parameters.Add("@status", SqlDbType.VarChar).Value = "I";




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
    }

    public static void AtualizarAgenda(int cod_Codigo_Agenda, DateTime dataCadastro, string usuario, DateTime dataAgendada)
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
                cmm.CommandText = "UPDATE [hspmonco].[dbo].[agenda] SET" +


      
       " [nome_Usuario_Atualizacao] = @nome_Usuario_Atualizacao " +
        ",[data_agendada] = @data_agendada" +
      ",[data_atualizacao] = @data_atualizacao" +
 " WHERE cod_agenda = @cod_agenda and status = 'A'";






                cmm.Parameters.Add("@cod_agenda", SqlDbType.Int).Value = cod_Codigo_Agenda;
                cmm.Parameters.Add("@data_atualizacao", SqlDbType.DateTime).Value = dataCadastro;
                cmm.Parameters.Add("@nome_Usuario_Atualizacao", SqlDbType.VarChar).Value = usuario;
           
                cmm.Parameters.Add("@data_agendada", SqlDbType.DateTime).Value = dataAgendada;




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
    }
}