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

/// <summary>
/// Summary description for impressora
/// </summary>
public class Impressora
{
    public int cod_impressora { get; set; }
  
    public string nome_impressora { get; set; }
    
    public string ip_computador { get; set; }

    public string nome_computador { get; set; }
}

