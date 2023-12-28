using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Protocolo
/// </summary>
public class Protocolos
{
    public Protocolos()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id { get; set; }
    public int cod_DescricaoProtocolo { get; set; }
    public int cod_Medicacao { get; set; }
    public int cod_PreQuimio { get; set; }
    public int cod_ViaDeAdministracao { get; set; }
    public string nome_Usuario { get; set; }
    public DateTime dataCadastro { get; set; }

    public string status { get; set; }


    public decimal dose { get; set; }
    public string unidadeDose { get; set; }
    public string diluicao { get; set; }
    public string tempoDeInfusao { get; set; }
    public string unidadeTempoDeInfusao { get; set; }
   
    
}