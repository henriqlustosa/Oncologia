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
/// Summary description for Conselho
/// </summary>
public class Conselho
{
    public int cod_conselho { get; set; }
    public string sigla_conselho { get; set; }
    public string desricao_conselho { get; set; }
}
