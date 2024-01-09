using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PacienteOncologia
/// </summary>
public class PacienteOncologia
{
    public PacienteOncologia()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string cod_Paciente { get; set; }
    public string nome_paciente { get; set; }
    public DateTime data_nascimento { get; set; }
    public string sexo { get; set; }
    public string nome_mae { get; set; }
    public int ddd_telefone { get; set; }
    public int telefone { get; set; }

    public DateTime dataCadastro { get; set; }
}