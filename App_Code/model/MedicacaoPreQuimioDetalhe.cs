using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MedicacaoPreQuimioDetalhe
/// </summary>
public class MedicacaoPreQuimioDetalhe
{
    public MedicacaoPreQuimioDetalhe()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Id { get; set; }
    public int cod_PreQuimio { get; set; }
    public int cod_Medicacao { get; set; }
    public int cod_Quimio { get; set; }
    public int cod_ViaDeAdministracao { get; set; }
    public string nome_Usuario { get; set; }
    public int quantidade { get; set; }
    public string unidadeQuantidade { get; set; }
    public string diluicao { get; set; }
    public int tempoDeInfusao { get; set; }
    public string unidadeTempoDeInfusao { get; set; }
    public DateTime dataCadastro { get; set; }
    public string status { get; set; }
}