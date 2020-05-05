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
using System.Collections.Generic;

/// <summary>
/// Summary description for Chart2
/// </summary>
///  Usado com dados de porcentagem
public class Chart2
{
    public string[] labels { get; set; }
    public List<Datasets2> datasets { get; set; }
}

public class Datasets2
{
    public string label { get; set; }
    public string[] backgroundColor { get; set; }
    public string[] borderColor { get; set; }
    public string borderWidth { get; set; }
    public decimal[] data { get; set; }
    public string[] pointBorderColor { get; set; }
    public string[] pointBackgroundColor { get; set; }
    public string[] pointHoverBackgroundColor { get; set; }
    public string[] pointHoverBorderColor { get; set; }
    public string pointBorderWidth { get; set; }
}
