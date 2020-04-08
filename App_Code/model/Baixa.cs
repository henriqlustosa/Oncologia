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
/// Summary description for Baixa
/// </summary>
public class Baixa
{
    public int cod_baixa { get; set; }
    public int cod_ficha { get; set; }
    public int cod_status { get; set; }
    public int cod_profissional { get; set; }
    public DateTime data_baixa { get; set; }
    public string obs { get; set; }
    public string usuario_baixa { get; set; }
}
