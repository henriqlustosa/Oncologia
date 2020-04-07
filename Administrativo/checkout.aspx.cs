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
            int _be = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta
            Response.Redirect("~/Administrativo/atualizabe.aspx?prontuario=" + _be);
        }

        if (e.CommandName.Equals("checkoutRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);
            int _be = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()); //id da consulta
            Response.Redirect("~/Administrativo/checkoutbe.aspx?prontuario=" + _be);
        }
    }
}
