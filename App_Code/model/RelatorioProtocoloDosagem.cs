﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioProtocoloDosagem
/// </summary>
public class RelatorioProtocoloDosagem
{
    public RelatorioProtocoloDosagem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Id { get; set; }
    public string desc_descricao_protocolo { get; set; }
    public string desc_medicacao { get; set; }
    public string desc_pre_quimio { get; set; }
    public string desc_via_de_administracao { get; set; }
    public string nome_Usuario { get; set; }
    public decimal dose { get; set; }
    public string unidadeDose { get; set; }
    public string diluicao { get; set; }
    public string tempoDeInfusao { get; set; }
    public string unidadeTempoDeInfusao { get; set; }
    public DateTime dataCadastro { get; set; }
    public char status { get; set; }
    public int cod_DescricaoProtocolo { get; set; }

    public int cod_CalculoDosagem { get; set; }
    public int cod_Prescricao { get; set; }
    public decimal dosagem { get; set; }

    public string unidade_dosagem{ get; set; }
    public decimal dose_alterada { get; set; }
}