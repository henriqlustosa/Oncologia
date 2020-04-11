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

public partial class testes_impressoras : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
