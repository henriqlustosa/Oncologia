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





    public List<CalculoDosagemPrescricao> calcular(CalculoSuperficieCorporea calculo,List<Protocolos> protocolos, DateTime datacadastro, Prescricao prescricao, PacienteOncologia pacienteOncologia,string nome_Usuario)
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
                calcDose.cod_Prescricao = prescricao.cod_Prescricao;
            }
            else if (protocolo.unidadeDose.Equals("mg"))
            {
                calcDose.dose = protocolo.dose;
                calcDose.unidade_dose = "mg";
                calcDose.dataCadastro = datacadastro;
                calcDose.cod_Protocolo = protocolo.cod_DescricaoProtocolo;
                calcDose.cod_Id_Protocolo = protocolo.Id;
                calcDose.cod_Prescricao = prescricao.cod_Prescricao;
            }
            else if (protocolo.unidadeDose.Equals("mg/Kg "))
            {
                calcDose.dose = protocolo.dose*calculo.peso;
                calcDose.unidade_dose = "mg";
                calcDose.dataCadastro = datacadastro;
                calcDose.cod_Protocolo = protocolo.cod_DescricaoProtocolo;
                calcDose.cod_Id_Protocolo = protocolo.Id;
                calcDose.cod_Prescricao = prescricao.cod_Prescricao;
            }
            else if (protocolo.unidadeDose.Equals("mg/m² 12/12h "))
            {
                calcDose.dose = calculo.BSA * protocolo.dose;
                calcDose.unidade_dose = "mg 12/12h";
                calcDose.dataCadastro = datacadastro;
                calcDose.cod_Protocolo = protocolo.cod_DescricaoProtocolo;
                calcDose.cod_Id_Protocolo = protocolo.Id;
                calcDose.cod_Prescricao = prescricao.cod_Prescricao;
            }
            else if (protocolo.unidadeDose.Equals("U "))
            {
                calcDose.dose = protocolo.dose;
                calcDose.unidade_dose = "U";
                calcDose.dataCadastro = datacadastro;
                calcDose.cod_Protocolo = protocolo.cod_DescricaoProtocolo;
                calcDose.cod_Id_Protocolo = protocolo.Id;
                calcDose.cod_Prescricao = prescricao.cod_Prescricao;
            }
            else if (protocolo.unidadeDose.Equals("mcg "))
            {
                calcDose.dose = protocolo.dose;
                calcDose.unidade_dose = "mcg";
                calcDose.dataCadastro = datacadastro;
                calcDose.cod_Protocolo = protocolo.cod_DescricaoProtocolo;
                calcDose.cod_Id_Protocolo = protocolo.Id;
                calcDose.cod_Prescricao = prescricao.cod_Prescricao;
            }

            else if (protocolo.unidadeDose.Equals("AUC "))
            {
                Decimal paramtroSexo = 1.00m;
                if (pacienteOncologia.sexo.Equals("Feminino"))
                    paramtroSexo = 0.85m;
                calcDose.dose = protocolo.dose*((paramtroSexo*((140 - CalcularIdade(pacienteOncologia.data_nascimento)) / (prescricao.creatinina))* (Convert.ToDecimal(calculo.peso)/Convert.ToDecimal(72))) + 25);
                calcDose.unidade_dose = "mg";
                calcDose.dataCadastro = datacadastro;
                calcDose.cod_Protocolo = protocolo.cod_DescricaoProtocolo;
                calcDose.cod_Id_Protocolo = protocolo.Id;
                calcDose.cod_Prescricao = prescricao.cod_Prescricao;
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
            calcDose.nome_Usuario = nome_Usuario;
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