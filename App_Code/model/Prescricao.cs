using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Prescricao
/// </summary>
public class Prescricao
{
    public Prescricao()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int cod_Prescricao { get; set; }
    public int cod_Paciente { get; set; }
    public int cod_Finalidade { get; set; }
    public int cod_Vias_De_Acesso { get; set; }
    public int cod_Protocolos { get; set; }

    public int cod_Calculo { get; set; }
    public int ciclos_provaveis { get; set; }
    public int intervalo_dias { get; set; }
    public DateTime data_inicio { get; set; }
    public DateTime data_termino { get; set; }

    public string observacao { get; set; }
    public DateTime data_cadastro { get; set; }
    public string status { get; set; }
    public string nome_Usuario { get; set; }

    public int cod_Prequimio { get; set; }



}