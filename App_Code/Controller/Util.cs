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
/// Summary description for Util
/// </summary>
public class Util
{
    public static bool verificaAno(int _ano)
    {
        bool bissexto;
        int ano = Convert.ToInt32(_ano);

        if (((ano % 400) == 0) || (ano % 4 == 0 && ano % 100 != 0))
        {
            bissexto = true;
        }
        else
        {
            bissexto = false;
        }
        return bissexto;
    }



}
