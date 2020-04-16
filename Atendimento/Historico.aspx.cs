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
using System.Drawing.Printing;

public partial class Historico_Historico : System.Web.UI.Page
{
    public string _nome_impressora { get; set; }
    
    public int _be { get; set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                {
                    ddlImpressora.Items.Add(strPrinter);
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
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
            
            _be = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());

            lbBE.Text = _be.ToString();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyModal", sb.ToString(), false);
        }
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        _nome_impressora = ddlImpressora.SelectedValue;
        _be = Convert.ToInt32(lbBE.Text);
        ImpressaoFicha.imprimirFicha(_be, _nome_impressora);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
}
