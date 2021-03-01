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
/// Summary description for Computador
/// </summary>
public class Computador : Impressora
{
    public int id_computador { get; set; }
    public string nome_computador { get; set; }
    public string descricao_computador { get; set; }
    public string ip_computador { get; set; }
    public int id_impressora_fk { get; set; }
}
