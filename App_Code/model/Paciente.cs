using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Paciente
/// </summary>
public class Paciente
{
    public Paciente()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string cd_prontuario { get; set; }
    public string nm_situacao { get; set; }
    public string nm_nome { get; set; }
    public string nm_nome_social { get; set; }
    public string nm_orgao { get; set; }
    public string cd_rf_matricula { get; set; }
    public string in_sexo { get; set; }
    public string dc_cor { get; set; }
    public string nm_mae { get; set; }
    public string dt_data_nascimento { get; set; }
    public string nr_idade { get; set; }
    public string nr_ddd_fone { get; set; }
    public string nr_fone { get; set; }
    public string nr_ddd_fone_recado { get; set; }
    public string nr_fone_recado { get; set; }
    public string cd_cep { get; set; }
    public string dc_logradouro { get; set; }
    public string nr_logradouro { get; set; }

    public string dc_complemento_logradouro { get; set; }
    public string dc_bairro { get; set; }
    public string nr_rg { get; set; }
    public string nr_cpf { get; set; }
    public string nr_cartao_saude { get; set; }
    public string email { get; set; }
    public string cidade { get; set; }
    public string rf { get; set; }
    public string nm_vinculo { get; set; }

}