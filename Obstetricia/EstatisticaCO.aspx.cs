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
using System.Drawing;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class Obstetricia_EstatisticaCO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void gvAplicaCor_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // quando montar as linhas do tipo DADOS
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string project = DataBinder.Eval(e.Row.DataItem, "#").ToString();

            // cores para aprovação
            if (project == "TOTAL")
                e.Row.BackColor = Color.FromArgb(168, 227, 215);

        }
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        int _mes = Convert.ToInt32(txbData.Text.Substring(0, 2));
        int _ano = Convert.ToInt32(txbData.Text.Substring(3, 4));

        gvObstetricia.DataSource = ConsolidadosDAO.GetListaDadosSetor(_mes, _ano, "Obstetrícia");
        gvObstetricia.DataBind();

        gvQuantitativo.DataSource = GetDadosBeStatus(_mes, _ano);
        gvQuantitativo.DataBind();

        gvBeAbertos.DataSource = getListaBeAberto(_mes, _ano);
        gvBeAbertos.DataBind();
    }

    private static List<Ficha> getListaBeAberto(int mes, int ano)
    {
        var dados = new List<Ficha>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT cod_ficha, dt_hr_be, nome_paciente, tipo_paciente " +
                               " FROM Oncologia_Desenv.dbo.ficha " +
                               " WHERE setor = 'Obstetrícia' AND MONTH(dt_hr_be) = " + mes + " and YEAR(dt_hr_be) = " + ano + " " +
                               " AND setor='Obstetrícia' AND status_ficha = 0 " +
                               " ORDER BY dt_hr_be DESC";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    Ficha f = new Ficha();

                    f.cod_ficha = dr1.GetInt32(0);
                    f.dt_rh_be = dr1.GetDateTime(1);
                    f.nome_paciente = dr1.GetString(2);

                    if (dr1.GetString(3) == "F")
                    {
                        f.tipo_paciente = "FUNCIONÁRIO";
                    }
                    if (dr1.GetString(3) == "M")
                    {
                        f.tipo_paciente = "MUNÍCIPE";
                    }

                    dados.Add(f);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return dados;
    }

    private static List<BeStatus> GetDadosBeStatus(int mes, int ano)
    {
        var dados = new List<BeStatus>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            cmm.CommandText = "SELECT COUNT(s.descricao_status) AS qtd_status, s.descricao_status, " +
                               " cast((count(f.status_ficha)*100.0)/(select COUNT(*) FROM Oncologia_Desenv.dbo.ficha f INNER JOIN Oncologia_Desenv.dbo.status_ficha s ON f.status_ficha = s.cod_status " +
                               " WHERE MONTH(f.dt_hr_be) =" + mes + " and YEAR(f.dt_hr_be) = " + ano + ")as decimal(5,2)) as porcentagem " +
                               " FROM Oncologia_Desenv.dbo.ficha f INNER JOIN Oncologia_Desenv.dbo.status_ficha s ON f.status_ficha = s.cod_status " +
                               " WHERE setor = 'Obstetrícia' AND MONTH(f.dt_hr_be) = " + mes + " and YEAR(f.dt_hr_be) = " + ano + " " +
                               " GROUP BY s.descricao_status " +
                               " ORDER BY qtd_status DESC";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                //char[] ponto = { '.', ' ' };
                while (dr1.Read())
                {
                    BeStatus call = new BeStatus();

                    call.quantidade = dr1.GetInt32(0);
                    call.descricao = dr1.GetString(1);
                    call.porcentagem = Convert.ToString(dr1.GetDecimal(2)) + "%";
                    dados.Add(call);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return dados;


    }


}
