using Microsoft.Identity.Client;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CID_10_DAO
/// </summary>
public class CID_10_DAO
{
    public CID_10_DAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void GravaCidsPorPrescricao(List<CID_10> lista_cid_10, int cod_Prescricao, DateTime dataCadastro)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            string status = "A";
           
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {

                foreach (CID_10 cid_10 in lista_cid_10)
                {
                    cmm.CommandText = "Insert into [dbo].[CID_PRESCRICAO] ([SUBCAT], [cod_Prescricao],data_cadastro,status)"
                    + " values ('"
                                + cid_10.SUBCAT + "',"
                                + cod_Prescricao + ",'"
                                + dataCadastro + "','"
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

    public static List<CID_10> listaCID_10()
    {
        var listaCID_10 = new List<CID_10>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT  [SUBCAT],[CLASSIF],[RESTRSEXO],[CAUSAOBITO],[DESCRICAO],[DESCRABREV],[REFER],[EXCLUIDOS] FROM[hspmoncohomologacao].[dbo].[CID_10_SUBCATEGORIAS]";

            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    CID_10 cid = new CID_10();
                    cid.SUBCAT = dr1.IsDBNull(0) ? "": dr1.GetString(0);
                    cid.CLASSIF = dr1.IsDBNull(1) ? "": dr1.GetString(1);
                    cid.RESTRSEXO = dr1.IsDBNull(2) ? "": dr1.GetString(2);
                    cid.CAUSAOBITO = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    cid.DESCRICAO = dr1.IsDBNull(4) ? "" :dr1.GetString(4);
                    cid.DESCRABREV = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    cid.REFER = dr1.IsDBNull(6) ? "":dr1.GetString(6);
                    cid.EXCLUIDOS = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                   
                    listaCID_10.Add(cid);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return listaCID_10;
    }

   

    public static List<CID_Prescricao> BuscarCIDsPorCodPrescricao(int cod_Prescricao)
    {
        List<CID_Prescricao> listaCid10 = new List<CID_Prescricao>() ;
     
 
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {

            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = "SELECT  [cod_Prescricao],[SUBCAT],[status],[data_cadastro],[data_atualizacao] FROM [hspmoncohomologacao].[dbo].[CID_PRESCRICAO] where status = 'A' and cod_Prescricao =" + cod_Prescricao;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    CID_Prescricao cid10 = new CID_Prescricao();
                    cid10.cod_Prescricao = dr1.GetInt32(0);
                    cid10.SUBCAT = dr1.GetString(1);
                   


                    listaCid10.Add(cid10);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return listaCid10;
        }
    }

    public static void DeletarCidsPorPrescricao(int cod_Prescricao, DateTime data_cadastro)
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
                cmm.CommandText = "UPDATE [dbo].[CID_PRESCRICAO] SET" +


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
}