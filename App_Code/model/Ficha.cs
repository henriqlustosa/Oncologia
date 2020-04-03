using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Ficha
/// </summary>
public class Ficha
{
    public int cod_ficha { get; set; }
    public DateTime dt_rh_be { get; set; }
    public int prontuario { get; set; }
    public string documento { get; set; }
    public string cns { get; set; }
    public int setor { get; set; }
    public string nome_paciente { get; set; }
    public DateTime dt_nascimento { get; set; }
    public int sexo { get; set; }
    public int raca { get; set; }
    public string endereco_rua { get; set; }
    public string numero_casa { get; set; }
    public string complemento { get; set; }
    public string bairro { get; set; }
    public string municipio { get; set; }
    public string uf { get; set; }
    public string cep { get; set; }
    public string nome_pai_mae { get; set; }
    public string responsavel { get; set; }
    public string telefone { get; set; }
    public string procedencia { get; set; }
    public string queixa { get; set; }
    public int caso_policial { get; set; }
    public int plano_saude { get; set; }
    public int trauma { get; set; }
    public int acidente_trabalho { get; set; }
    public int veio_ambulancia { get; set; }
    public string tipo_paciente { get; set; }
    public int usuario { get; set; }

}
