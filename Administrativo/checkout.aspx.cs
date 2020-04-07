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
using System.Data.SqlClient;

public partial class Administrativo_checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        int _nr_be = Convert.ToInt32(txbBE.Text);

        GridView1.DataSource = FichaDAO.GetBE(_nr_be);
        GridView1.DataBind();
    }


    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        int index;

        if (e.CommandName.Equals("editRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);
            int _be = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); 

            Response.Redirect("~/Administrativo/atualizabe.aspx?be=" + _be);
        }

        if (e.CommandName.Equals("checkoutRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);
            int _be = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());
            int _status = getStatusFicha(_be);
            
            if (_status == 0)
            {
                Response.Redirect("~/Administrativo/checkoutbe.aspx?be=" + _be);
            }
            if(_status == 1)
            {
                string mensagem = "Ficha com status: " + _status + " - ALTA ";
                Msg.Text = mensagem;
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mensagem + "');", true);
            }
            
        }
    }

    public int status;
    protected int getStatusFicha(int _nr_be)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["psConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT status_ficha FROM [hspmPs].[dbo].[ficha] WHERE cod_ficha = " + _nr_be;
            try
            {
                cnn.Open();

                SqlDataReader dr1 = cmm.ExecuteReader();

                if (dr1.Read())
                {
                    status = dr1.GetInt32(0);
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return status;
    }


}
