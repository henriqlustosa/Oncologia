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

    public static void GravarAgenda(DateTime data_inicio, int cod_Prescricao, int ciclos_provaveis, int intervalo_dias, DateTime data_cadastro)
    {
        string mensagem = "";


        int posicao = 1;


        for (int i = 0; i < ciclos_provaveis; i++)
        {




          



            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
            {
                try
                {
                    SqlCommand cmm = new SqlCommand();
                    cmm.Connection = cnn;
                    cnn.Open();
                    SqlTransaction mt = cnn.BeginTransaction();
                    cmm.Transaction = mt;
                    cmm.CommandText = "INSERT INTO [dbo].[Agenda]" +
               "([cod_Prescricao]" +
               ", [data_agendada]" +
               ", [data_cadastro]" +
                ", [status]" +
                 ", [posicao]" +
               ", [total_posicoes])" +

         "VALUES" +
               "(@cod_Prescricao" +
               ",@data_agendada" +
               ",@data_cadastro" +
               ",@status" +
                ",@posicao" +
               ",@total_posicoes)";
                    cmm.Parameters.Add("@cod_Prescricao", SqlDbType.Int).Value = cod_Prescricao;
                    cmm.Parameters.Add("@data_agendada", SqlDbType.DateTime).Value = data_inicio;
                    cmm.Parameters.Add("@data_cadastro", SqlDbType.DateTime).Value = data_cadastro;
                    cmm.Parameters.Add("@status", SqlDbType.VarChar).Value = "A";
                    cmm.Parameters.Add("@posicao", SqlDbType.Int).Value = posicao;
                    cmm.Parameters.Add("@total_posicoes", SqlDbType.Int).Value = ciclos_provaveis;








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
            posicao += 1;
            data_inicio = data_inicio.AddDays(intervalo_dias );

       
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
}