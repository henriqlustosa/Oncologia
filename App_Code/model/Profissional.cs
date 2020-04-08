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
/// Summary description for Profissional
/// </summary>
public class Profissional : Conselho
{
	public Profissional()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int cod_profissional { get; set; }
    public string nome_profissional { get; set; }
    public int conselho { get; set; }
    public int nr_conselho { get; set; }
    public int status_profissional { get; set; }

}
