using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioPreQuimioDosagem
/// </summary>
public class RelatorioPreQuimioDosagem
{
    public RelatorioPreQuimioDosagem()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id { get; set; }
    public string desc_pre_quimio { get; set; }
    public string desc_medicacao { get; set; }
    public string desc_quimio { get; set; }
    public string desc_via_de_administracao { get; set; }
    public string nome_Usuario { get; set; }
    public decimal quantidade { get; set; }
    public string unidade_dose { get; set; }
    public string diluicao { get; set; }
    public int tempoDeInfusao { get; set; }
    public string unidadeTempoDeInfusao { get; set; }
    public DateTime dataCadastro { get; set; }
    public string status { get; set; }
    public int cod_Prequimio { get; set; }
    public int cod_CalculoDosagemPreQuimio { get; set; }
    public decimal dose_alterada { get; set; }
}