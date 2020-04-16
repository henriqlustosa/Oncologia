using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class Controle_ConsolidadoMes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        int _mes = Convert.ToInt32(txbData.Text.Substring(0,2));
        int _ano = Convert.ToInt32(txbData.Text.Substring(3,4));

        GridView1.DataSource = GetListaDados(_mes, _ano);
        GridView1.DataBind();
    }

    public List<ConsolidadoMesTipoPaciente> GetListaDados(int mes, int ano)
    {

        
        
        var lista = new List<ConsolidadoMesTipoPaciente>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [tipo_paciente] " + 
                          ",[BE_MONTH] "+
                          ",[BE_YEAR] "+
                          ",[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14] ,[15],[16],[17] ,[18],[19],[20]"+
                          ",[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31],[TOTAL] "+
                      " FROM [hspmPs].[dbo].[vw_con_be_tipo_pac_mes]" +
                      " WHERE BE_MONTH =" + mes + " AND BE_YEAR =" +ano;
            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    ConsolidadoMesTipoPaciente consolidado = new ConsolidadoMesTipoPaciente();
                    if(dr1.GetString(0) == "F"){
                        consolidado.tipo_paciente = "FUNCIONÁRIO";
                    }
                    if (dr1.GetString(0) == "M")
                    {
                        consolidado.tipo_paciente = "MUNÍCIPE";
                    }
                    consolidado.mes = dr1.GetInt32(1);
                    consolidado.ano = dr1.GetInt32(2);

                    consolidado.dia1 = dr1.GetInt32(3);
                    consolidado.dia2 = dr1.GetInt32(4);
                    consolidado.dia3 = dr1.GetInt32(5);
                    consolidado.dia4 = dr1.GetInt32(6);
                    consolidado.dia5 = dr1.GetInt32(7);
                    consolidado.dia6 = dr1.GetInt32(8);
                    consolidado.dia7 = dr1.GetInt32(9);
                    consolidado.dia8 = dr1.GetInt32(10);
                    consolidado.dia9 = dr1.GetInt32(11);
                    consolidado.dia10 = dr1.GetInt32(12);
                    consolidado.dia11 = dr1.GetInt32(13);
                    consolidado.dia12 = dr1.GetInt32(14);
                    consolidado.dia13 = dr1.GetInt32(15);
                    consolidado.dia14 = dr1.GetInt32(16);
                    consolidado.dia15 = dr1.GetInt32(17);
                    consolidado.dia16 = dr1.GetInt32(18);
                    consolidado.dia17 = dr1.GetInt32(19);
                    consolidado.dia18 = dr1.GetInt32(20);
                    consolidado.dia19 = dr1.GetInt32(21);
                    consolidado.dia20 = dr1.GetInt32(22);
                    consolidado.dia21 = dr1.GetInt32(23);
                    consolidado.dia22 = dr1.GetInt32(24);
                    consolidado.dia23 = dr1.GetInt32(25);
                    consolidado.dia24 = dr1.GetInt32(26);
                    consolidado.dia25 = dr1.GetInt32(27);
                    consolidado.dia26 = dr1.GetInt32(28);
                    consolidado.dia27 = dr1.GetInt32(29);
                    consolidado.dia28 = dr1.GetInt32(30);
                    consolidado.dia29 = dr1.GetInt32(31);
                    consolidado.dia30 = dr1.GetInt32(32);
                    consolidado.dia31 = dr1.GetInt32(33);
                    consolidado.total = dr1.GetInt32(34);

                    lista.Add(consolidado);
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
