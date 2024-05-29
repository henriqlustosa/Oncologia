using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CalculoDosagemPrescricaoPreQuimio
/// </summary>
public class CalculoDosagemPrescricaoPreQuimio
{
    public CalculoDosagemPrescricaoPreQuimio()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int cod_CalculoDosagem { get; set; }
    public Decimal dose { get; set; }

    public string unidade_dose { get; set; }

    public DateTime dataCadastro { get; set; }
    public int cod_Prequimio { get; set; }
    public int cod_Id_Prequimio { get; set; }
    public int cod_Prescricao { get; set; }
    public string status { get; set; }
    public DateTime data_atualizacao { get; set; }

    public int porcentagemDiminuirDose { get; set; }
    public Decimal dose_alterada { get; set; }
    public string nome_Usuario { get; set; }
    public string nome_Usuario_Atualizacao { get; set; }

    public List<CalculoDosagemPrescricaoPreQuimio> calcular(List<MedicacaoPreQuimioDetalhe> prequimios, DateTime dataCadastro, Prescricao prescricao, PacienteOncologia pacienteOncologia, string nome_Usuario)
    {
        List<CalculoDosagemPrescricaoPreQuimio> calcDoses = new List<CalculoDosagemPrescricaoPreQuimio>();
        foreach (MedicacaoPreQuimioDetalhe prequimio in prequimios)
        {
            CalculoDosagemPrescricaoPreQuimio calcDose = new CalculoDosagemPrescricaoPreQuimio();
           
                calcDose.dose = prequimio.quantidade;
                calcDose.unidade_dose = "mg";
                calcDose.dataCadastro = dataCadastro;
                calcDose.cod_Prequimio= prequimio.cod_PreQuimio;
                calcDose.cod_Id_Prequimio = prequimio.Id;
                calcDose.cod_Prescricao = prescricao.cod_Prescricao;
                calcDose.nome_Usuario = nome_Usuario;
                calcDoses.Add(calcDose);
        }
        return calcDoses;
    }
}