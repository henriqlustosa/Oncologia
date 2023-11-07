using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Medicamento_Amostra
/// </summary>
public class Medicamento_Amostra
{
    public Medicamento_Amostra()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int cod_medicamento { get; set; }
    public string droga { get; set; }
    public string via { get; set; }
    public string nome_comercial { get; set; }
    public string concentracao { get; set; }
    public string volume_de_diluicao_para_infusao { get; set; }
    public string estabilidade { get; set; }
    public string tempo_de_infusao { get; set; }
    public string equipos { get; set; }


}