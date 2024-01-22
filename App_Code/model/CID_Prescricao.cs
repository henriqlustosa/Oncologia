using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CID_Prescricao
/// </summary>
public class CID_Prescricao
{
    public CID_Prescricao()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int cod_Prescricao { get; set; }
    public string SUBCAT { get; set; }

    public string status { get; set; }
    public DateTime data_cadastro { get; set; }
    public DateTime data_atualizacao { get; set; }


}