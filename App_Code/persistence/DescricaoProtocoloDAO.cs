using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProtocoloDAO
/// </summary>
public class DescricaoProtocoloDAO
{
    public DescricaoProtocoloDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void GravaMedicamentosPorProtocolo(List<Medicamento_Amostra> medicamentos, int cod_protocolo)
    {

        string status = "A";
        string v = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        string _dtcadastro_bd = v;
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {

                foreach (Medicamento_Amostra medicamento in medicamentos)
                {
                    cmm.CommandText = "Insert into [Oncologia_Desenv].[dbo].[Protocolo_Medicamento] ([cod_protocolo],[cod_medicamento],[data_cadastro],[status])"
                    + " values ("
                                + cod_protocolo + ","
                                + medicamento.cod_medicamento + ",'"
                                
                                + _dtcadastro_bd + "','"
                                + status
                                + "');";
                    cmm.ExecuteNonQuery();


                }

                mt.Commit();
                mt.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                mt.Rollback();
            }
        }



    }

    public static void InativaMedicamentosPorProtocolo(int cod_protocolo)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {

                cmm.CommandText = "UPDATE [Oncologia_Desenv].[dbo].[Protocolo_Medicamento]" +
                 " SET status = @status " +
                 " WHERE  cod_protocolo = " + cod_protocolo;
                cmm.Parameters.Add(new SqlParameter("@status", "I"));

                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();


            }
            catch (Exception ex)
            {
                string error = ex.Message;

                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                {
                    string error1 = ex1.Message;

                }
            }
        }

    }

    public static List<DescricaoProtocolo> listaProtocolo()
    {
        var listaProtocolo = new List<DescricaoProtocolo>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [Id],[descricao] FROM [hspmonco].[dbo].[DescricaoProtocolo]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    DescricaoProtocolo protocolo = new DescricaoProtocolo();
                    protocolo.cod_protocolo = dr1.GetInt32(0);
                    protocolo.descricao = dr1.GetString(1);
                 
                    listaProtocolo.Add(protocolo);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return listaProtocolo;
    }
}
