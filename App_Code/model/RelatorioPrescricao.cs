using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelatorioPrescricao
/// </summary>
public class RelatorioPrescricao
{
    public RelatorioPrescricao()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int cod_Prescricao { get; set; }

    public string desc_finalidade { get; set; }
    public string desc_vias_de_acesso { get; set; }
    public string nome_paciente { get; set; }
    public int altura { get; set; }
    public int peso { get; set; }
    public decimal BSA { get; set; }
    public int intervalo_dias { get; set; }
    public DateTime data_inicio { get; set; }
    public DateTime data_termino { get; set; }
    public string observacao { get; set; }
    public DateTime data_cadastro { get; set; }
    public char status { get; set; }
    public string desc_protocolo { get; set; }




    public string nome_Usuario { get; set; }

    public int cod_Paciente { get; set; }

    public int ddd_telefone { get; set; }


    public int telefone { get; set; }
    public string sexo { get; set; }
    public DateTime data_nascimento { get; set; }
    public int ciclos_provaveis { get; set; }

    public string desc_prequimio { get; set;}

    public int cod_prequimio { get; set; }
    public int cod_protocolo { get; set; }
    public decimal creatinina { get; set; }

    public string nome_profissional { get; set; }

    public int nr_conselho { get; set; }


}