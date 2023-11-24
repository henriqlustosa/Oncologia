using System;
using System.Collections.Generic;
using System.Configuration;
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



    public static List<CID_10> listaCID_10()
    {
        var listaCID_10 = new List<CID_10>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["oncoConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT  [SUBCAT],[CLASSIF],[RESTRSEXO],[CAUSAOBITO],[DESCRICAO],[DESCRABREV],[REFER],[EXCLUIDOS] FROM[hspmonco].[dbo].[CID_10_SUBCATEGORIAS]";

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
}