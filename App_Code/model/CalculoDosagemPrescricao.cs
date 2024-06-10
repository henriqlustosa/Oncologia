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
    public string status { get; set; }
    public int porcentagemDiminuirDose { get; set; }

    public DateTime data_atualizacao { get; set; }

    public Decimal dose_alterada { get; set; }
    public string nome_Usuario { get; set; }
    public string nome_Usuario_Atualizacao { get; set; }





    public List<CalculoDosagemPrescricao> calcular(CalculoSuperficieCorporea calculo, List<Protocolos> protocolos, DateTime datacadastro, Prescricao prescricao, PacienteOncologia pacienteOncologia, string nome_Usuario)
    {
        List<CalculoDosagemPrescricao> calcDoses = new List<CalculoDosagemPrescricao>();

        foreach (Protocolos protocolo in protocolos)
        {
            CalculoDosagemPrescricao calcDose = new CalculoDosagemPrescricao
            {
                dataCadastro = datacadastro,
                cod_Protocolo = protocolo.cod_DescricaoProtocolo,
                cod_Id_Protocolo = protocolo.Id,
                cod_Prescricao = prescricao.cod_Prescricao,
                nome_Usuario = nome_Usuario
            };

            switch (protocolo.unidadeDose.Trim())
            {
                case "mg/m²":
                    calcDose.dose = calculo.BSA * protocolo.dose;
                    calcDose.unidade_dose = "mg";
                    break;
                case "mg":
                    calcDose.dose = protocolo.dose;
                    calcDose.unidade_dose = "mg";
                    break;
                case "mg/Kg":
                    calcDose.dose = protocolo.dose * Convert.ToDecimal(calculo.peso);
                    calcDose.unidade_dose = "mg";
                    break;
                case "mg/m² 12/12h":
                    calcDose.dose = calculo.BSA * protocolo.dose;
                    calcDose.unidade_dose = "mg 12/12h";
                    break;
                case "U":
                    calcDose.dose = protocolo.dose;
                    calcDose.unidade_dose = "U";
                    break;
                case "mcg":
                    calcDose.dose = protocolo.dose;
                    calcDose.unidade_dose = "mcg";
                    break;
                case "AUC":
                    decimal paramtroSexo = pacienteOncologia.sexo.Equals("Feminino") ? 0.85m : 1.00m;
                    calcDose.dose = protocolo.dose * ((paramtroSexo * ((140 - CalcularIdade(pacienteOncologia.data_nascimento)) / prescricao.creatinina) * (Convert.ToDecimal(calculo.peso) / 72m)) + 25);
                    calcDose.unidade_dose = "mg";
                    break;
                default:
                    calcDose.dose = 0;
                    calcDose.unidade_dose = "mg";
                    break;
            }

            calcDoses.Add(calcDose);
        }

        return calcDoses;
    }


    private static int CalcularIdade(DateTime dataNascimento)
    {
        int idade = DateTime.Now.Year - dataNascimento.Year;
        if(DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
        {
            idade = idade - 1;
        }
        return idade;
    }
}