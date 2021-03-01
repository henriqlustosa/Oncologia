using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for ComputadorDAO
/// </summary>
public class ComputadorDAO
{
	public ComputadorDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Computador getInfoComputador(string _hostname)
    {
        Computador pc = new Computador();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT * FROM [hspmPs].[dbo].[vw_impressora_computador] WHERE nome_computador = '" + _hostname +"'";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    pc.id_computador = dr1.GetInt32(0);
                    pc.nome_computador = dr1.GetString(1);
                    pc.descricao_computador = dr1.GetString(2);
                    pc.ip_computador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    pc.id_impressora_fk = dr1.GetInt32(4);
                    pc.id_impressora = dr1.GetInt32(5);
                    pc.tipo = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    pc.nome_impressora = dr1.GetString(7);
                    pc.descricao_impressora = dr1.GetString(8);
                    pc.ip_impressora = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                }
                cnn.Close();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return pc;
    }

    public static List<Computador> ListaComputadores()
    {
        var lista = new List<Computador>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT * " +
                              " FROM [hspmPs].[dbo].[vw_impressora_computador]";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    Computador pc = new Computador();
                    pc.id_computador = dr1.GetInt32(0);
                    pc.nome_computador = dr1.GetString(1);
                    pc.descricao_computador = dr1.GetString(2);
                    pc.ip_computador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    pc.id_impressora_fk = dr1.GetInt32(4);
                    pc.id_impressora = dr1.GetInt32(5);
                    pc.tipo = dr1.GetString(6);
                    pc.nome_impressora = dr1.GetString(7);
                    pc.descricao_impressora = dr1.GetString(8);
                    pc.ip_impressora = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    lista.Add(pc);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;

    }
}
