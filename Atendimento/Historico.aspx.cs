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

public partial class Historico_Historico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        //int _nr_be = Convert.ToInt32(txbBE.Text);

        GridView1.DataSource = FichaDAO.GetListaFicha(txbNome.Text);
        GridView1.DataBind();
    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index;

        if (e.CommandName.Equals("printFicha"))
        {
            index = Convert.ToInt32(e.CommandArgument);
            int _be = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());
            ImpressaoFicha.imprimirFicha(_be);
            //int _status =  ImpressaoFicha.imprimirFicha(_be);
        }
    }
}
