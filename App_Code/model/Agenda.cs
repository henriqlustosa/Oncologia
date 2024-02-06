using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Agenda
/// </summary>
public class Agenda
{
    public Agenda()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int cod_agenda { get; set; }
    public int cod_Prescricao { get; set; }

    public DateTime data_agendada { get; set; }

    public DateTime data_cadastro { get; set; }
    public string status { get; set; }

    public int posicao { get; set; }
    public int total_posicoes { get; set; }

}