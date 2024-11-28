using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViasDeAcesso_Prescricao
/// </summary>
public class ViasDeAcesso_Prescricao
{
    public ViasDeAcesso_Prescricao()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int cod_Prescricao { get; set; }
    public int cod_vias_de_acesso{ get; set; }
    public string descr_vias_de_acesso { get; set; }
    public string status { get; set; }
    public DateTime data_cadastro { get; set; }
    public DateTime data_atualizacao { get; set; }
}