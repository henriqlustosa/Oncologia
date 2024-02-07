using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CalculoDosagemPrescricao
/// </summary>
public class CalculoDosagemPrescricao
{
    public CalculoDosagemPrescricao()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int cod_CalculoDosagem { get; set; }

    public int cod_Protocolo { get; set; }
    public int cod_Id_Protocolo { get; set; }
    public Decimal dose {  get; set; }

    public string unidade_dose { get; set; }
    public DateTime dataCadastro { get; set; }
    public int cod_Prescricao { get; set; }

    public List<CalculoDosagemPrescricao> calcular(CalculoSuperficieCorporea calculo,List<Protocolos> protocolos, DateTime datacadastro, int cod_Prescricao)
    {
        List<CalculoDosagemPrescricao> calcDoses = new List<CalculoDosagemPrescricao>();
        foreach (Protocolos protocolo in protocolos)
        {
            CalculoDosagemPrescricao calcDose = new CalculoDosagemPrescricao();
            if (protocolo.unidadeDose.Equals("mg/m² "))
            {
                calcDose.dose = calculo.BSA * protocolo.dose;
                calcDose.unidade_dose = "mg";
                calcDose.dataCadastro = datacadastro;
                calcDose.cod_Protocolo = protocolo.cod_DescricaoProtocolo ;
                calcDose.cod_Id_Protocolo = protocolo.Id;
                calcDose.cod_Prescricao = cod_Prescricao;
            }
            else
            {
                calcDose.dose = 0;
                calcDose.unidade_dose = "mg";
                calcDose.dataCadastro = datacadastro;
                calcDose.cod_Protocolo = protocolo.cod_DescricaoProtocolo;
                calcDose.cod_Id_Protocolo = protocolo.Id;
                calcDose.cod_Prescricao = cod_Prescricao;

            }
            calcDoses.Add(calcDose);
        }
        return calcDoses;
    }
}