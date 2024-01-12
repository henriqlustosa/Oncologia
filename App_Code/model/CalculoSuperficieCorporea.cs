using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CalculoSuperficieCorporea
/// </summary>
public class CalculoSuperficieCorporea
{
    public CalculoSuperficieCorporea()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int cod_Calculo { get; set; }
    public int altura { get; set; }
    public int peso { get; set; }
    public Decimal BSA { get; set; }
    public DateTime dataCadastro { get; set; }

}